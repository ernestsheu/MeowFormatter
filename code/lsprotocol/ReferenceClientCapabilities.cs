// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Client Capabilities for a <see cref="ReferencesRequest" />.
    /// </summary>
    [DataContract]
    public record ReferenceClientCapabilities
    {
        [JsonConstructor]
        public ReferenceClientCapabilities(
            bool? dynamicRegistration = null
        )
        {
            DynamicRegistration = dynamicRegistration;
        }
        /// <summary>
        /// Whether references supports dynamic registration.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "dynamicRegistration")]
        public bool? DynamicRegistration { get; init; }
    }

}
