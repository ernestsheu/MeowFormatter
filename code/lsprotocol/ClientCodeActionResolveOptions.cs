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
    public record ClientCodeActionResolveOptions
    {
        [JsonConstructor]
        public ClientCodeActionResolveOptions(
            ImmutableArray<string> properties
        )
        {
            Properties = properties;
        }
        /// <summary>
        /// The properties that a client can resolve lazily.
        /// </summary>
        [JsonConverter(typeof(CustomArrayConverter<string>))]
        [DataMember(Name = "properties")]
        public ImmutableArray<string> Properties { get; init; }
    }

}
