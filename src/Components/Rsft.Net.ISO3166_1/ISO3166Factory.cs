// <copyright file="ISO3166Factory.cs" company="Rolosoft Ltd">
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
namespace Rsft.Net.ISO3166_1
{
    using System;
    using System.Collections.Generic;
    using Entities;
    using Interfaces;
    using Logic.Parser;
    using Logic.Repo;

    /// <summary>
    /// ISO3166 Factory
    /// </summary>
    public static class ISO3166Factory
    {
        /// <summary>
        /// The parser
        /// </summary>
        private static readonly IParser<string, IEnumerable<ISOCountry>> Parser = new CsvParser();

        /// <summary>
        /// The default configuration
        /// </summary>
        private static readonly IConfiguration<CachePolicyConfiguration> DefaultConfiguration = new Logic.Configuration.CachePolicyConfiguration();

        /// <summary>
        /// The lazy repo
        /// </summary>
        private static Lazy<IRepository<string, ISOCountry>> lazyRepo;

        /// <summary>
        /// Creates ISO3166-1 repository.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns>The <see cref="IRepository&lt;string, ISOCountry&gt;"/></returns>
        public static IRepository<string, ISOCountry> Create(IConfiguration<CachePolicyConfiguration> configuration = null)
        {
            if (configuration == null)
            {
                configuration = DefaultConfiguration;
            }

            if (lazyRepo != null)
            {
                return lazyRepo.Value;
            }

            lazyRepo = new Lazy<IRepository<string, ISOCountry>>(() => new DataOkfnRepo(Parser, configuration));

            return lazyRepo.Value;
        }
    }
}