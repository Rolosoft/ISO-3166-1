// <copyright file="IParser.cs" company="Rolosoft Ltd">
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
namespace Rsft.Net.ISO3166_1.Interfaces
{
    using System.Diagnostics.Contracts;
    using Contracts;

    /// <summary>
    /// Parser interface.
    /// </summary>
    /// <typeparam name="TIn">The type of the in.</typeparam>
    /// <typeparam name="TOut">The type of the out.</typeparam>
    [ContractClass(typeof(ParserContracts<,>))]
    internal interface IParser<in TIn, out TOut>
    {
        /// <summary>
        /// Parses the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The parsed content.</returns>
        TOut Parse(TIn input);
    }
}