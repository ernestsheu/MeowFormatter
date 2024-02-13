// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Represents an incoming call, e.g. a caller of a method or constructor.
    /// 
    /// </summary>
    [Since("3.16.0")]
    [DataContract]
    public record CallHierarchyIncomingCall
    {
        [JsonConstructor]
        public CallHierarchyIncomingCall(
            CallHierarchyItem from,
            ImmutableArray<Range> fromRanges
        )
        {
            From = from;
            FromRanges = fromRanges;
        }
        /// <summary>
        /// The item that makes the call.
        /// </summary>
        [DataMember(Name = "from")]
        public CallHierarchyItem From { get; init; }
        /// <summary>
        /// The ranges at which the calls appear. This is relative to the caller
        /// denoted by <see cref="CallHierarchyIncomingCall.from">`this.from`</see>.
        /// </summary>
        [JsonConverter(typeof(CustomArrayConverter<Range>))]
        [DataMember(Name = "fromRanges")]
        public ImmutableArray<Range> FromRanges { get; init; }
    }

}
