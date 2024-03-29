// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Request to resolve a <see cref="DocumentHighlight" /> for a given
    /// text document position. The request's parameter is of type <see cref="TextDocumentPosition" />
    /// the request response is an array of type <see cref="DocumentHighlight" />
    /// or a Thenable that resolves to such.
    /// </summary>
    [LSPResponse(typeof(TextDocumentDocumentHighlightRequest))]
    [DataContract]
    public record TextDocumentDocumentHighlightResponse: IResponse<ImmutableArray<DocumentHighlight>>
    {
        [JsonConstructor]
        public TextDocumentDocumentHighlightResponse(
            OrType<string, int> id,
            string jsonrpc = "2.0",
            ImmutableArray<DocumentHighlight> result = default!,
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
        [JsonConverter(typeof(CustomArrayConverter<DocumentHighlight>))]
        [DataMember(Name = "result")]
        public ImmutableArray<DocumentHighlight> Result { get; init; }
        /// <summary>
        /// Error while handling the request.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "error")]
        public ResponseError? Error { get; init; }
    }

}
