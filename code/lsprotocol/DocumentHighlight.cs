// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// A document highlight is a range inside a text document which deserves
    /// special attention. Usually a document highlight is visualized by changing
    /// the background color of its range.
    /// </summary>
    [DataContract]
    public record DocumentHighlight
    {
        [JsonConstructor]
        public DocumentHighlight(
            Range range,
            DocumentHighlightKind? kind = null
        )
        {
            Range = range;
            Kind = kind;
        }
        /// <summary>
        /// The range this highlight applies to.
        /// </summary>
        [DataMember(Name = "range")]
        public Range Range { get; init; }
        /// <summary>
        /// The highlight kind, default is <see cref="DocumentHighlightKind.Text">text</see>.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "kind")]
        public DocumentHighlightKind? Kind { get; init; }
    }

}
