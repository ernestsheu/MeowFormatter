// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// A request to provide code lens for the given text document.
    /// </summary>
    [LSPResponse(typeof(TextDocumentCodeLensRequest))]
    [DataContract]
    public record TextDocumentCodeLensResponse: IResponse<ImmutableArray<CodeLens>>
    {
        [JsonConstructor]
        public TextDocumentCodeLensResponse(
            OrType<string, int> id,
            string jsonrpc = "2.0",
            ImmutableArray<CodeLens> result = default!,
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
        [JsonConverter(typeof(CustomArrayConverter<CodeLens>))]
        [DataMember(Name = "result")]
        public ImmutableArray<CodeLens> Result { get; init; }
        /// <summary>
        /// Error while handling the request.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "error")]
        public ResponseError? Error { get; init; }
    }

}
