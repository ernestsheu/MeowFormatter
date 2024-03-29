// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// A request to resolve the type definition locations of a symbol at a given text
    /// document position. The request's parameter is of type <see cref="TextDocumentPositionParams" />
    /// the response is of type <see cref="Definition" /> or a Thenable that resolves to such.
    /// </summary>
    [Direction(MessageDirection.ClientToServer)]
    [LSPRequest("textDocument/typeDefinition", typeof(TextDocumentTypeDefinitionResponse), typeof(OrType<ImmutableArray<Location>, ImmutableArray<DefinitionLink>>))]
    [DataContract]
    public record TextDocumentTypeDefinitionRequest: IRequest<TypeDefinitionParams>
    {
        [JsonConstructor]
        public TextDocumentTypeDefinitionRequest(
            OrType<string, int> id,
            string method,
            TypeDefinitionParams paramsValue,
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
        public TypeDefinitionParams Params { get; init; }
    }

}
