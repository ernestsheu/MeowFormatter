// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// The `workspace/didChangeWorkspaceFolders` notification is sent from the client to the server when the workspace
    /// folder configuration changes.
    /// </summary>
    [Direction(MessageDirection.ServerToClient)]
    [DataContract]
    public record WorkspaceDidChangeWorkspaceFoldersNotification: INotification<DidChangeWorkspaceFoldersParams>
    {
        [JsonConstructor]
        public WorkspaceDidChangeWorkspaceFoldersNotification(
            string method,
            DidChangeWorkspaceFoldersParams paramsValue,
            string jsonrpc = "2.0"
        )
        {
            JsonRPC = jsonrpc;
            Method = method;
            Params = paramsValue;
        }
        /// <summary>
        /// The jsonrpc version.
        /// </summary>
        [DataMember(Name = "jsonrpc")]
        public string JsonRPC { get; init; } = "2.0";
        /// <summary>
        /// The Notification method.
        /// </summary>
        [DataMember(Name = "method")]
        public string Method { get; init; }
        /// <summary>
        /// The Notification parameters.
        /// </summary>
        [DataMember(Name = "params")]
        public DidChangeWorkspaceFoldersParams Params { get; init; }
    }

}
