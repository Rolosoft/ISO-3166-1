// <copyright file="DataOkfnRepo.cs" company="Rolosoft Ltd">
// (c) 2017, Rolosoft Ltd
// </copyright>

// Copyright 2017 Rolosoft Ltd
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
namespace Rsft.Net.ISO3166_1.Logic.Repo
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Entities;
    using Interfaces;
    using JetBrains.Annotations;
    using Microsoft.Extensions.Caching.Memory;

    /// <summary>
    /// Data.okfn.org data source repo.
    /// </summary>
    /// <seealso cref="ISOCountry" />
    internal sealed class DataOkfnRepo : IRepository<string, ISOCountry>
    {
        /// <summary>
        /// The repo URL.
        /// </summary>
        private const string RepoUrl = @"https://raw.githubusercontent.com/datasets/country-list/master/data.csv";

        /// <summary>
        /// The cache key
        /// </summary>
        private const string CacheKey = @"35E6639F-049B-4618-8DF7-34325BA8B381";

        /// <summary>
        /// The memory cache
        /// </summary>
        private static readonly IMemoryCache MemoryCache = new MemoryCache(new MemoryCacheOptions());

        /// <summary>
        /// The parser
        /// </summary>
        [NotNull]
        private readonly IParser<string, IEnumerable<ISOCountry>> parser;

        /// <summary>
        /// The cache policy configuration
        /// </summary>
        [NotNull]
        private readonly IConfiguration<CachePolicyConfiguration> cachePolicyConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataOkfnRepo" /> class.
        /// </summary>
        /// <param name="parser">The parser.</param>
        /// <param name="cachePolicyConfiguration">The cache policy configuration.</param>
        public DataOkfnRepo([NotNull] IParser<string, IEnumerable<ISOCountry>> parser, [NotNull] IConfiguration<CachePolicyConfiguration> cachePolicyConfiguration)
        {
            Contract.Requires(parser != null);
            Contract.Requires(cachePolicyConfiguration != null);

            this.parser = parser;
            this.cachePolicyConfiguration = cachePolicyConfiguration;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ISOCountry>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await this.GetOrAddExistingAsync(CacheKey).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the or add existing asynchronous.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        private async Task<IEnumerable<ISOCountry>> GetOrAddExistingAsync(string key)
        {
            IEnumerable<ISOCountry> value = await MemoryCache.GetOrCreateAsync(key, async entry =>
            {
                if (entry.Value != null)
                {
                    var isoCountries = (IEnumerable<ISOCountry>)entry.Value;

                    return isoCountries;
                }

                using (var client = new HttpClient())
                {
                    var s = await client.GetStringAsync(RepoUrl).ConfigureAwait(false);

                    var isoCountries = this.parser.Parse(s);

                    entry.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(this.cachePolicyConfiguration.Configuration.CacheTimeoutSeconds);

                    entry.Value = isoCountries;

                    return isoCountries;
                }
            }).ConfigureAwait(false);

            return value;
        }
    }
}