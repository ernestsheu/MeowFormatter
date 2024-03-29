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
    public record ClientCompletionItemInsertTextModeOptions
    {
        [JsonConstructor]
        public ClientCompletionItemInsertTextModeOptions(
            ImmutableArray<InsertTextMode> valueSet
        )
        {
            ValueSet = valueSet;
        }
        [JsonConverter(typeof(CustomArrayConverter<InsertTextMode>))]
        [DataMember(Name = "valueSet")]
        public ImmutableArray<InsertTextMode> ValueSet { get; init; }
    }

}
