// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// A request to format a whole document.
    /// </summary>
    [LSPResponse(typeof(TextDocumentFormattingRequest))]
    [DataContract]
    public record TextDocumentFormattingResponse: IResponse<ImmutableArray<TextEdit>>
    {
        [JsonConstructor]
        public TextDocumentFormattingResponse(
            OrType<string, int> id,
            string jsonrpc = "2.0",
            ImmutableArray<TextEdit> result = default!,
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
        [JsonConverter(typeof(CustomArrayConverter<TextEdit>))]
        [DataMember(Name = "result")]
        public ImmutableArray<TextEdit> Result { get; init; }
        /// <summary>
        /// Error while handling the request.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "error")]
        public ResponseError? Error { get; init; }
    }

}
