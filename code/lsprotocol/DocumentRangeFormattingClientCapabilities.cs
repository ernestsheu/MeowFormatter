// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Client capabilities of a <see cref="DocumentRangeFormattingRequest" />.
    /// </summary>
    [DataContract]
    public record DocumentRangeFormattingClientCapabilities
    {
        [JsonConstructor]
        public DocumentRangeFormattingClientCapabilities(
            bool? dynamicRegistration = null,
            bool? rangesSupport = null
        )
        {
            DynamicRegistration = dynamicRegistration;
            RangesSupport = rangesSupport;
        }
        /// <summary>
        /// Whether range formatting supports dynamic registration.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "dynamicRegistration")]
        public bool? DynamicRegistration { get; init; }
        /// <summary>
        /// Whether the client supports formatting multiple ranges at once.
        /// 
        /// </summary>
        [Proposed]
        [Since("3.18.0")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "rangesSupport")]
        public bool? RangesSupport { get; init; }
    }

}
