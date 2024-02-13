// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Client capabilities specific to inline completions.
    /// 
    /// </summary>
    [Proposed]
    [Since("3.18.0")]
    [DataContract]
    public record InlineCompletionClientCapabilities
    {
        [JsonConstructor]
        public InlineCompletionClientCapabilities(
            bool? dynamicRegistration = null
        )
        {
            DynamicRegistration = dynamicRegistration;
        }
        /// <summary>
        /// Whether implementation supports dynamic registration for inline completion providers.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "dynamicRegistration")]
        public bool? DynamicRegistration { get; init; }
    }

}