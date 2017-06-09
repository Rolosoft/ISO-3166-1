// <copyright file="DataOkfnRepoTests.cs" company="Rolosoft Ltd">
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
namespace Rsft.Net.ISO3166_1.Tests.Integration.Logic.Repo
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    using Entities;
    using Interfaces;
    using ISO3166_1.Logic.Parser;
    using JetBrains.Annotations;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// Data Ok fn Repo Tests
    /// </summary>
    /// <seealso cref="TestBase" />
    public class DataOkfnRepoTests : TestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataOkfnRepoTests"/> class.
        /// </summary>
        /// <param name="outHelper">The out helper.</param>
        public DataOkfnRepoTests([NotNull] ITestOutputHelper outHelper)
            : base(outHelper)
        {
        }

        /// <summary>
        /// Gets all asynchronous test.
        /// </summary>
        [Fact]
        public void GetAllAsync_Test()
        {
            // Arrange
            IParser<string, IEnumerable<ISOCountry>> parser = new CsvParser();

            IConfiguration<Entities.CachePolicyConfiguration> cachePolicyConfig = new ISO3166_1.Logic.Configuration.CachePolicyConfiguration();

            var dataOkfnRepo = new ISO3166_1.Logic.Repo.DataOkfnRepo(parser, cachePolicyConfig);

            for (int i = 0; i < 10; i++)
            {
                // Act
                var stopwatch = Stopwatch.StartNew();
                var isoCountries = dataOkfnRepo.GetAllAsync(CancellationToken.None).Result;
                stopwatch.Stop();

                // Assert
                Assert.True(isoCountries.Count() > 1);
                this.WriteTimeElapsed(stopwatch.ElapsedMilliseconds);
            }
        }
    }
}