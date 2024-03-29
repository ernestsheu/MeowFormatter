// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    [DataContract]
    public record DidChangeWatchedFilesClientCapabilities
    {
        [JsonConstructor]
        public DidChangeWatchedFilesClientCapabilities(
            bool? dynamicRegistration = null,
            bool? relativePatternSupport = null
        )
        {
            DynamicRegistration = dynamicRegistration;
            RelativePatternSupport = relativePatternSupport;
        }
        /// <summary>
        /// Did change watched files notification supports dynamic registration. Please note
        /// that the current protocol doesn't support static configuration for file changes
        /// from the server side.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "dynamicRegistration")]
        public bool? DynamicRegistration { get; init; }
        /// <summary>
        /// Whether the client has support for <see cref="RelativePattern">relative pattern</see>
        /// or not.
        /// 
        /// </summary>
        [Since("3.17.0")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "relativePatternSupport")]
        public bool? RelativePatternSupport { get; init; }
    }

}
