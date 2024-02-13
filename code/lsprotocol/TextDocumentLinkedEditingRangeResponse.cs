// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// A request to provide ranges that can be edited together.
    /// 
    /// </summary>
    [Since("3.16.0")]
    [LSPResponse(typeof(TextDocumentLinkedEditingRangeRequest))]
    [DataContract]
    public record TextDocumentLinkedEditingRangeResponse: IResponse<LinkedEditingRanges>
    {
        [JsonConstructor]
        public TextDocumentLinkedEditingRangeResponse(
            OrType<string, int> id,
            string jsonrpc = "2.0",
            LinkedEditingRanges? result = null,
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
        [DataMember(Name = "result")]
        public LinkedEditingRanges? Result { get; init; }
        /// <summary>
        /// Error while handling the request.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "error")]
        public ResponseError? Error { get; init; }
    }

}