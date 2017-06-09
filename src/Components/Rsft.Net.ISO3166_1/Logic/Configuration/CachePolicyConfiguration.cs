// <copyright file="CachePolicyConfiguration.cs" company="Rolosoft Ltd">
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
namespace Rsft.Net.ISO3166_1.Logic.Configuration
{
    using System.Threading;
    using Interfaces;

    /// <summary>
    /// Cache Policy Configuration
    /// </summary>
    /// <seealso cref="Entities.CachePolicyConfiguration" />
    internal sealed class CachePolicyConfiguration : IConfiguration<Entities.CachePolicyConfiguration>
    {
        /// <summary>
        /// The read writer locker slim cache poilcy
        /// </summary>
        private static readonly ReaderWriterLockSlim ReadWriterLockerSlimCachePoilcy = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

        /// <summary>
        /// The cache policy configuration local
        /// </summary>
        private static Entities.CachePolicyConfiguration cachePolicyConfigLocal = new Entities.CachePolicyConfiguration();

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public Entities.CachePolicyConfiguration Configuration
        {
            get
            {
                ReadWriterLockerSlimCachePoilcy.EnterReadLock();

                var rtn = cachePolicyConfigLocal;

                ReadWriterLockerSlimCachePoilcy.ExitReadLock();

                return rtn;
            }

            set
            {
                ReadWriterLockerSlimCachePoilcy.EnterWriteLock();

                cachePolicyConfigLocal = value;

                ReadWriterLockerSlimCachePoilcy.ExitWriteLock();
            }
        }
    }
}