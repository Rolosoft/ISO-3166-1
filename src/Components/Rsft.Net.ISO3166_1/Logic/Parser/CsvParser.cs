﻿// <copyright file="CsvParser.cs" company="Rolosoft Ltd">
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
namespace Rsft.Net.ISO3166_1.Logic.Parser
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using CsvHelper;
    using Entities;
    using Interfaces;

    /// <summary>
    /// CSV Parser
    /// </summary>
    /// <seealso cref="ISOCountry" />
    internal sealed class CsvParser : IParser<string, IEnumerable<ISOCountry>>
    {
        /// <inheritdoc />
        public IEnumerable<ISOCountry> Parse(string input)
        {
            IEnumerable<ISOCountry> isoCountries;

            using (var sr = new StringReader(input))
            {
                var csv = new CsvReader(sr);

                isoCountries = csv.GetRecords<ISOCountry>().ToList();
            }

            return isoCountries;
        }
    }
}