// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.DataLake.Store.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Describes the Resource Usage.
    /// </summary>
    public partial class Usage
    {
        /// <summary>
        /// Initializes a new instance of the Usage class.
        /// </summary>
        public Usage()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Usage class.
        /// </summary>
        /// <param name="unit">Gets the unit of measurement. Possible values
        /// include: 'Count', 'Bytes', 'Seconds', 'Percent', 'CountsPerSecond',
        /// 'BytesPerSecond'</param>
        /// <param name="id">Resource identifier.</param>
        /// <param name="currentValue">Gets the current count of the allocated
        /// resources in the subscription.</param>
        /// <param name="limit">Gets the maximum count of the resources that
        /// can be allocated in the subscription.</param>
        /// <param name="name">Gets the name of the type of usage.</param>
        public Usage(UsageUnit? unit = default(UsageUnit?), string id = default(string), int? currentValue = default(int?), int? limit = default(int?), UsageName name = default(UsageName))
        {
            Unit = unit;
            Id = id;
            CurrentValue = currentValue;
            Limit = limit;
            Name = name;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets the unit of measurement. Possible values include: 'Count',
        /// 'Bytes', 'Seconds', 'Percent', 'CountsPerSecond', 'BytesPerSecond'
        /// </summary>
        [JsonProperty(PropertyName = "unit")]
        public UsageUnit? Unit { get; private set; }

        /// <summary>
        /// Gets resource identifier.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; private set; }

        /// <summary>
        /// Gets the current count of the allocated resources in the
        /// subscription.
        /// </summary>
        [JsonProperty(PropertyName = "currentValue")]
        public int? CurrentValue { get; private set; }

        /// <summary>
        /// Gets the maximum count of the resources that can be allocated in
        /// the subscription.
        /// </summary>
        [JsonProperty(PropertyName = "limit")]
        public int? Limit { get; private set; }

        /// <summary>
        /// Gets the name of the type of usage.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public UsageName Name { get; private set; }

    }
}