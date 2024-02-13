// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// A request to rename a symbol.
    /// </summary>
    [Direction(MessageDirection.ClientToServer)]
    [LSPRequest("textDocument/rename", typeof(TextDocumentRenameResponse))]
    [DataContract]
    public record TextDocumentRenameRequest: IRequest<RenameParams>
    {
        [JsonConstructor]
        public TextDocumentRenameRequest(
            OrType<string, int> id,
            string method,
            RenameParams paramsValue,
            string jsonrpc = "2.0"
        )
        {
            JsonRPC = jsonrpc;
            Id = id;
            Method = method;
            Params = paramsValue;
        }
        /// <summary>
        /// The jsonrpc version.
        /// </summary>
        [DataMember(Name = "jsonrpc")]
        public string JsonRPC { get; init; } = "2.0";
        /// <summary>
        /// The Request id.
        /// </summary>
        [JsonConverter(typeof(OrTypeConverter<string, int>))]
        [DataMember(Name = "id")]
        public OrType<string, int> Id { get; init; }
        /// <summary>
        /// The Request method.
        /// </summary>
        [DataMember(Name = "method")]
        public string Method { get; init; }
        /// <summary>
        /// The Request parameters.
        /// </summary>
        [DataMember(Name = "params")]
        public RenameParams Params { get; init; }
    }

}
