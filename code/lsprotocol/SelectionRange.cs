// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// A selection range represents a part of a selection hierarchy. A selection range
    /// may have a parent selection range that contains it.
    /// </summary>
    [DataContract]
    public record SelectionRange
    {
        [JsonConstructor]
        public SelectionRange(
            Range range,
            SelectionRange? parent = null
        )
        {
            Range = range;
            Parent = parent;
        }
        /// <summary>
        /// The <see cref="Range">range</see> of this selection range.
        /// </summary>
        [DataMember(Name = "range")]
        public Range Range { get; init; }
        /// <summary>
        /// The parent selection range containing this range. Therefore `parent.range` must contain `this.range`.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "parent")]
        public SelectionRange? Parent { get; init; }
    }

}
