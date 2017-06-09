// <copyright file="IRepository.cs" company="Rolosoft Ltd">
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
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;
    using Contracts;

    /// <summary>
    /// Read only repo interface.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TOut">The type of the out.</typeparam>
    [ContractClass(typeof(RepositoryContracts<,>))]
    public interface IRepository<in TKey, TOut>
    {
        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<IEnumerable<TOut>> GetAllAsync(CancellationToken cancellationToken);
    }
}