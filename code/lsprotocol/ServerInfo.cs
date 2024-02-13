// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Information about the server
    /// 
    /// </summary>
    [Proposed]
    [Since("3.18.0 ServerInfo type name added.")]
    [DataContract]
    public record ServerInfo
    {
        [JsonConstructor]
        public ServerInfo(
            string name,
            string? version = null
        )
        {
            Name = name;
            Version = version;
        }
        /// <summary>
        /// The name of the server as defined by the server.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; init; }
        /// <summary>
        /// The server's version as defined by the server.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "version")]
        public string? Version { get; init; }
    }

}