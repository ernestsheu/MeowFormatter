// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// </summary>
    [Proposed]
    [Since("3.18.0")]
    [DataContract]
    public record ClientFoldingRangeOptions
    {
        [JsonConstructor]
        public ClientFoldingRangeOptions(
            bool? collapsedText = null
        )
        {
            CollapsedText = collapsedText;
        }
        /// <summary>
        /// If set, the client signals that it supports setting collapsedText on
        /// folding ranges to display custom labels instead of the default text.
        /// 
        /// </summary>
        [Since("3.17.0")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "collapsedText")]
        public bool? CollapsedText { get; init; }
    }

}
