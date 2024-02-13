// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// The parameters of a configuration request.
    /// </summary>
    [DataContract]
    public record ConfigurationParams
    {
        [JsonConstructor]
        public ConfigurationParams(
            ImmutableArray<ConfigurationItem> items
        )
        {
            Items = items;
        }
        [JsonConverter(typeof(CustomArrayConverter<ConfigurationItem>))]
        [DataMember(Name = "items")]
        public ImmutableArray<ConfigurationItem> Items { get; init; }
    }

}