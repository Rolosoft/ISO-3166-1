// <copyright file="RepositoryContracts.cs" company="Rolosoft Ltd">
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
namespace Rsft.Net.ISO3166_1.Interfaces.Contracts
{
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Threading;
    using System.Threading.Tasks;
    using JetBrains.Annotations;

    /// <summary>
    /// Code contracts.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TOut">The type of the out.</typeparam>
    /// <seealso cref="Interfaces.IRepository{TKey, TOut}" />
    [ContractClassFor(typeof(IRepository<,>))]
    internal abstract class RepositoryContracts<TKey, TOut>
        : IRepository<TKey, TOut>
    {
        /// <inheritdoc />
        public virtual Task<IEnumerable<TOut>> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}