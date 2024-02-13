// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// The client capabilities  of a <see cref="CodeLensRequest" />.
    /// </summary>
    [DataContract]
    public record CodeLensClientCapabilities
    {
        [JsonConstructor]
        public CodeLensClientCapabilities(
            bool? dynamicRegistration = null
        )
        {
            DynamicRegistration = dynamicRegistration;
        }
        /// <summary>
        /// Whether code lens supports dynamic registration.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "dynamicRegistration")]
        public bool? DynamicRegistration { get; init; }
    }

}