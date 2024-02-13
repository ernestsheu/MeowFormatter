// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Represents a collection of <see cref="CompletionItem">completion items</see> to be presented
    /// in the editor.
    /// </summary>
    [DataContract]
    public record CompletionList
    {
        [JsonConstructor]
        public CompletionList(
            bool isIncomplete,
            ImmutableArray<CompletionItem> items,
            CompletionItemDefaults? itemDefaults = null
        )
        {
            IsIncomplete = isIncomplete;
            ItemDefaults = itemDefaults;
            Items = items;
        }
        /// <summary>
        /// This list it not complete. Further typing results in recomputing this list.
        /// 
        /// Recomputed lists have all their items replaced (not appended) in the
        /// incomplete completion sessions.
        /// </summary>
        [DataMember(Name = "isIncomplete")]
        public bool IsIncomplete { get; init; }
        /// <summary>
        /// In many cases the items of an actual completion result share the same
        /// value for properties like `commitCharacters` or the range of a text
        /// edit. A completion list can therefore define item defaults which will
        /// be used if a completion item itself doesn't specify the value.
        /// 
        /// If a completion list specifies a default value and a completion item
        /// also specifies a corresponding value the one from the item is used.
        /// 
        /// Servers are only allowed to return default values if the client
        /// signals support for this via the `completionList.itemDefaults`
        /// capability.
        /// 
        /// </summary>
        [Since("3.17.0")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "itemDefaults")]
        public CompletionItemDefaults? ItemDefaults { get; init; }
        /// <summary>
        /// The completion items.
        /// </summary>
        [JsonConverter(typeof(CustomArrayConverter<CompletionItem>))]
        [DataMember(Name = "items")]
        public ImmutableArray<CompletionItem> Items { get; init; }
    }

}