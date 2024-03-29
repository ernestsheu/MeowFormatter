// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// </summary>
    [Proposed]
    [Since("3.18.0")]
    [DataContract]
    public record CompletionItemTagOptions
    {
        [JsonConstructor]
        public CompletionItemTagOptions(
            ImmutableArray<CompletionItemTag> valueSet
        )
        {
            ValueSet = valueSet;
        }
        /// <summary>
        /// The tags supported by the client.
        /// </summary>
        [JsonConverter(typeof(CustomArrayConverter<CompletionItemTag>))]
        [DataMember(Name = "valueSet")]
        public ImmutableArray<CompletionItemTag> ValueSet { get; init; }
    }

}
