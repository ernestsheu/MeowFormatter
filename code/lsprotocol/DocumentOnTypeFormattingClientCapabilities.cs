// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Client capabilities of a <see cref="DocumentOnTypeFormattingRequest" />.
    /// </summary>
    [DataContract]
    public record DocumentOnTypeFormattingClientCapabilities
    {
        [JsonConstructor]
        public DocumentOnTypeFormattingClientCapabilities(
            bool? dynamicRegistration = null
        )
        {
            DynamicRegistration = dynamicRegistration;
        }
        /// <summary>
        /// Whether on type formatting supports dynamic registration.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "dynamicRegistration")]
        public bool? DynamicRegistration { get; init; }
    }

}
