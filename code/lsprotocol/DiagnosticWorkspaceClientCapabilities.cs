// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Workspace client capabilities specific to diagnostic pull requests.
    /// 
    /// </summary>
    [Since("3.17.0")]
    [DataContract]
    public record DiagnosticWorkspaceClientCapabilities
    {
        [JsonConstructor]
        public DiagnosticWorkspaceClientCapabilities(
            bool? refreshSupport = null
        )
        {
            RefreshSupport = refreshSupport;
        }
        /// <summary>
        /// Whether the client implementation supports a refresh request sent from
        /// the server to the client.
        /// 
        /// Note that this event is global and will force the client to refresh all
        /// pulled diagnostics currently shown. It should be used with absolute care and
        /// is useful for situation where a server for example detects a project wide
        /// change that requires such a calculation.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "refreshSupport")]
        public bool? RefreshSupport { get; init; }
    }

}
