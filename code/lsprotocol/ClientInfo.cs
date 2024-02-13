// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Information about the client
    /// 
    /// </summary>
    [Proposed]
    [Since("3.18.0 ClientInfo type name added.")]
    [DataContract]
    public record ClientInfo
    {
        [JsonConstructor]
        public ClientInfo(
            string name,
            string? version = null
        )
        {
            Name = name;
            Version = version;
        }
        /// <summary>
        /// The name of the client as defined by the client.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; init; }
        /// <summary>
        /// The client's version as defined by the client.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "version")]
        public string? Version { get; init; }
    }

}
