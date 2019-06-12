// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Graph.RBAC.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Request parameters for the GetObjectsByObjectIds API.
    /// </summary>
    public partial class GetObjectsParameters
    {
        /// <summary>
        /// Initializes a new instance of the GetObjectsParameters class.
        /// </summary>
        public GetObjectsParameters()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the GetObjectsParameters class.
        /// </summary>
        /// <param name="additionalProperties">Unmatched properties from the
        /// message are deserialized this collection</param>
        /// <param name="objectIds">The requested object IDs.</param>
        /// <param name="types">The requested object types.</param>
        /// <param name="includeDirectoryObjectReferences">If true, also
        /// searches for object IDs in the partner tenant.</param>
        public GetObjectsParameters(IDictionary<string, object> additionalProperties = default(IDictionary<string, object>), IList<string> objectIds = default(IList<string>), IList<string> types = default(IList<string>), bool? includeDirectoryObjectReferences = default(bool?))
        {
            AdditionalProperties = additionalProperties;
            ObjectIds = objectIds;
            Types = types;
            IncludeDirectoryObjectReferences = includeDirectoryObjectReferences;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets unmatched properties from the message are deserialized
        /// this collection
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties { get; set; }

        /// <summary>
        /// Gets or sets the requested object IDs.
        /// </summary>
        [JsonProperty(PropertyName = "objectIds")]
        public IList<string> ObjectIds { get; set; }

        /// <summary>
        /// Gets or sets the requested object types.
        /// </summary>
        [JsonProperty(PropertyName = "types")]
        public IList<string> Types { get; set; }

        /// <summary>
        /// Gets or sets if true, also searches for object IDs in the partner
        /// tenant.
        /// </summary>
        [JsonProperty(PropertyName = "includeDirectoryObjectReferences")]
        public bool? IncludeDirectoryObjectReferences { get; set; }

    }
}