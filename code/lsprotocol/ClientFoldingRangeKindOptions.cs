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
    public record ClientFoldingRangeKindOptions
    {
        [JsonConstructor]
        public ClientFoldingRangeKindOptions(
            ImmutableArray<string> valueSet = default!
        )
        {
            ValueSet = valueSet;
        }
        /// <summary>
        /// The folding range kind values the client supports. When this
        /// property exists the client also guarantees that it will
        /// handle values outside its set gracefully and falls back
        /// to a default value when unknown.
        /// </summary>
        [JsonConverter(typeof(CustomArrayConverter<string>))]
        [DataMember(Name = "valueSet")]
        public ImmutableArray<string> ValueSet { get; init; }
    }

}
