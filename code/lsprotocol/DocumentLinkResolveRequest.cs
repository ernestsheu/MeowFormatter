// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Request to resolve additional information for a given document link. The request's
    /// parameter is of type <see cref="DocumentLink" /> the response
    /// is of type <see cref="DocumentLink" /> or a Thenable that resolves to such.
    /// </summary>
    [Direction(MessageDirection.ClientToServer)]
    [LSPRequest("documentLink/resolve", typeof(DocumentLinkResolveResponse))]
    [DataContract]
    public record DocumentLinkResolveRequest: IRequest<DocumentLink>
    {
        [JsonConstructor]
        public DocumentLinkResolveRequest(
            OrType<string, int> id,
            string method,
            DocumentLink paramsValue,
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
        public DocumentLink Params { get; init; }
    }

}
