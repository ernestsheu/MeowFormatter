// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Client capabilities specific to the moniker request.
    /// 
    /// </summary>
    [Since("3.16.0")]
    [DataContract]
    public record MonikerClientCapabilities
    {
        [JsonConstructor]
        public MonikerClientCapabilities(
            bool? dynamicRegistration = null
        )
        {
            DynamicRegistration = dynamicRegistration;
        }
        /// <summary>
        /// Whether moniker supports dynamic registration. If this is set to `true`
        /// the client supports the new `MonikerRegistrationOptions` return value
        /// for the corresponding server capability as well.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "dynamicRegistration")]
        public bool? DynamicRegistration { get; init; }
    }

}
