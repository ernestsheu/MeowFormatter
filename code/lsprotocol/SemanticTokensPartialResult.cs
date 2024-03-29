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
    [Since("3.16.0")]
    [DataContract]
    public record SemanticTokensPartialResult
    {
        [JsonConstructor]
        public SemanticTokensPartialResult(
            ImmutableArray<long> data
        )
        {
            Data = data;
        }
        [JsonConverter(typeof(CustomArrayConverter<long>))]
        [DataMember(Name = "data")]
        public ImmutableArray<long> Data { get; init; }
    }

}
