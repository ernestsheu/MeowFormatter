// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// The document save notification is sent from the client to the server when
    /// the document got saved in the client.
    /// </summary>
    [Direction(MessageDirection.ServerToClient)]
    [DataContract]
    public record TextDocumentDidSaveNotification: INotification<DidSaveTextDocumentParams>
    {
        [JsonConstructor]
        public TextDocumentDidSaveNotification(
            string method,
            DidSaveTextDocumentParams paramsValue,
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
        public DidSaveTextDocumentParams Params { get; init; }
    }

}
