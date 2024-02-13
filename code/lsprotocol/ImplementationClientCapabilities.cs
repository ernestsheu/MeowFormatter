// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// </summary>
    [Since("3.6.0")]
    [DataContract]
    public record ImplementationClientCapabilities
    {
        [JsonConstructor]
        public ImplementationClientCapabilities(
            bool? dynamicRegistration = null,
            bool? linkSupport = null
        )
        {
            DynamicRegistration = dynamicRegistration;
            LinkSupport = linkSupport;
        }
        /// <summary>
        /// Whether implementation supports dynamic registration. If this is set to `true`
        /// the client supports the new `ImplementationRegistrationOptions` return value
        /// for the corresponding server capability as well.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "dynamicRegistration")]
        public bool? DynamicRegistration { get; init; }
        /// <summary>
        /// The client supports additional metadata in the form of definition links.
        /// 
        /// </summary>
        [Since("3.14.0")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "linkSupport")]
        public bool? LinkSupport { get; init; }
    }

}
