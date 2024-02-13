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
    [LSPResponse(typeof(DocumentLinkResolveRequest))]
    [DataContract]
    public record DocumentLinkResolveResponse: IResponse<DocumentLink>
    {
        [JsonConstructor]
        public DocumentLinkResolveResponse(
            OrType<string, int> id,
            string jsonrpc = "2.0",
            DocumentLink? result = null,
            ResponseError? error = null
        )
        {
            JsonRPC = jsonrpc;
            Id = id;
            Result = result;
            Error = error;
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
        /// Results for the request.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "result")]
        public DocumentLink? Result { get; init; }
        /// <summary>
        /// Error while handling the request.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "error")]
        public ResponseError? Error { get; init; }
    }

}
