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
    public record SemanticTokensDelta
    {
        [JsonConstructor]
        public SemanticTokensDelta(
            ImmutableArray<SemanticTokensEdit> edits,
            string? resultId = null
        )
        {
            ResultId = resultId;
            Edits = edits;
        }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "resultId")]
        public string? ResultId { get; init; }
        /// <summary>
        /// The semantic token edits to transform a previous result into a new result.
        /// </summary>
        [JsonConverter(typeof(CustomArrayConverter<SemanticTokensEdit>))]
        [DataMember(Name = "edits")]
        public ImmutableArray<SemanticTokensEdit> Edits { get; init; }
    }

}