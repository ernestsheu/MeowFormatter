// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// A request to list all presentation for a color. The request's
    /// parameter is of type <see cref="ColorPresentationParams" /> the
    /// response is of type {@link ColorInformation ColorInformation[]} or a Thenable
    /// that resolves to such.
    /// </summary>
    [LSPResponse(typeof(TextDocumentColorPresentationRequest))]
    [DataContract]
    public record TextDocumentColorPresentationResponse: IResponse<ImmutableArray<ColorPresentation>>
    {
        [JsonConstructor]
        public TextDocumentColorPresentationResponse(
            OrType<string, int> id,
            string jsonrpc = "2.0",
            ImmutableArray<ColorPresentation> result = default!,
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
        [JsonConverter(typeof(CustomArrayConverter<ColorPresentation>))]
        [DataMember(Name = "result")]
        public ImmutableArray<ColorPresentation> Result { get; init; }
        /// <summary>
        /// Error while handling the request.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "error")]
        public ResponseError? Error { get; init; }
    }

}