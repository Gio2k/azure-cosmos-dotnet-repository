﻿// Copyright (c) IEvangelist. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.Cosmos;

namespace Microsoft.Azure.CosmosRepository.Options
{
    /// <summary>
    /// A repository options class, representing 
    /// various Azure Cosmos DB configuration settings.
    /// </summary>
    public class RepositoryOptions
    {
        /// <summary>
        /// Gets or sets the cosmos connection string. Primary or secondary connection strings are valid.
        /// </summary>
        public string CosmosConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the name identifier for the cosmos database.
        /// </summary>
        /// <remarks>
        /// Defaults to "database", unless otherwise specified.
        /// </remarks>
        public string DatabaseId { get; set; } = "database";

        /// <summary>
        /// Gets or sets the name identifier for the cosmos container that corresponds to the <see cref="DatabaseId"/>.
        /// </summary>
        /// <remarks>
        /// Defaults to "container", unless otherwise specified.
        /// </remarks>
        public string ContainerId { get; set; } = "container";

        /// <summary>
        /// Gets or sets whether to optimize bandwidth.
        /// When false, the <see cref="ItemRequestOptions.EnableContentResponseOnWrite"/> is set to false and only
        /// headers and status code in the Cosmos DB response for write item operation like Create, Upsert,
        /// Patch and Replace. This reduces networking and CPU load by not sending the resource back over the
        /// network and serializing it on the client.
        /// </summary>
        /// <remarks>
        /// Defaults to true, see: https://devblogs.microsoft.com/cosmosdb/enable-content-response-on-write
        /// </remarks>
        public bool OptimizeBandwidth { get; set; } = true;
    }
}