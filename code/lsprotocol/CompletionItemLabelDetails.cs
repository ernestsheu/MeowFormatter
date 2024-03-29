// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Additional details for a completion item label.
    /// 
    /// </summary>
    [Since("3.17.0")]
    [DataContract]
    public record CompletionItemLabelDetails
    {
        [JsonConstructor]
        public CompletionItemLabelDetails(
            string? detail = null,
            string? description = null
        )
        {
            Detail = detail;
            Description = description;
        }
        /// <summary>
        /// An optional string which is rendered less prominently directly after <see cref="CompletionItem.label">label</see>,
        /// without any spacing. Should be used for function signatures and type annotations.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "detail")]
        public string? Detail { get; init; }
        /// <summary>
        /// An optional string which is rendered less prominently after <see cref="CompletionItem.detail" />. Should be used
        /// for fully qualified names and file paths.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "description")]
        public string? Description { get; init; }
    }

}
