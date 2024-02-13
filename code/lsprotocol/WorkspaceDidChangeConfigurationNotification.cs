// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// The configuration change notification is sent from the client to the server
    /// when the client's configuration has changed. The notification contains
    /// the changed configuration as defined by the language client.
    /// </summary>
    [Direction(MessageDirection.ServerToClient)]
    [DataContract]
    public record WorkspaceDidChangeConfigurationNotification: INotification<DidChangeConfigurationParams>
    {
        [JsonConstructor]
        public WorkspaceDidChangeConfigurationNotification(
            string method,
            DidChangeConfigurationParams paramsValue,
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
        public DidChangeConfigurationParams Params { get; init; }
    }

}