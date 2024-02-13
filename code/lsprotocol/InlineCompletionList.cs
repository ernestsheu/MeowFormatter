// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Represents a collection of <see cref="InlineCompletionItem">inline completion items</see> to be presented in the editor.
    /// 
    /// </summary>
    [Proposed]
    [Since("3.18.0")]
    [DataContract]
    public record InlineCompletionList
    {
        [JsonConstructor]
        public InlineCompletionList(
            ImmutableArray<InlineCompletionItem> items
        )
        {
            Items = items;
        }
        /// <summary>
        /// The inline completion items
        /// </summary>
        [JsonConverter(typeof(CustomArrayConverter<InlineCompletionItem>))]
        [DataMember(Name = "items")]
        public ImmutableArray<InlineCompletionItem> Items { get; init; }
    }

}
