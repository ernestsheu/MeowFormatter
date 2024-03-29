// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// A request to result a `TypeHierarchyItem` in a document at a given position.
    /// Can be used as an input to a subtypes or supertypes type hierarchy.
    /// 
    /// </summary>
    [Since("3.17.0")]
    [LSPResponse(typeof(TextDocumentPrepareTypeHierarchyRequest))]
    [DataContract]
    public record TextDocumentPrepareTypeHierarchyResponse: IResponse<ImmutableArray<TypeHierarchyItem>>
    {
        [JsonConstructor]
        public TextDocumentPrepareTypeHierarchyResponse(
            OrType<string, int> id,
            string jsonrpc = "2.0",
            ImmutableArray<TypeHierarchyItem> result = default!,
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
        [JsonConverter(typeof(CustomArrayConverter<TypeHierarchyItem>))]
        [DataMember(Name = "result")]
        public ImmutableArray<TypeHierarchyItem> Result { get; init; }
        /// <summary>
        /// Error while handling the request.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "error")]
        public ResponseError? Error { get; init; }
    }

}
