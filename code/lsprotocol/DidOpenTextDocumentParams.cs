// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// The parameters sent in an open text document notification
    /// </summary>
    [DataContract]
    public record DidOpenTextDocumentParams
    {
        [JsonConstructor]
        public DidOpenTextDocumentParams(
            TextDocumentItem textDocument
        )
        {
            TextDocument = textDocument;
        }
        /// <summary>
        /// The document that was opened.
        /// </summary>
        [DataMember(Name = "textDocument")]
        public TextDocumentItem TextDocument { get; init; }
    }

}