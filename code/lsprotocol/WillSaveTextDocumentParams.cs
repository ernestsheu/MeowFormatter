// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// The parameters sent in a will save text document notification.
    /// </summary>
    [DataContract]
    public record WillSaveTextDocumentParams
    {
        [JsonConstructor]
        public WillSaveTextDocumentParams(
            TextDocumentIdentifier textDocument,
            TextDocumentSaveReason reason
        )
        {
            TextDocument = textDocument;
            Reason = reason;
        }
        /// <summary>
        /// The document that will be saved.
        /// </summary>
        [DataMember(Name = "textDocument")]
        public TextDocumentIdentifier TextDocument { get; init; }
        /// <summary>
        /// The 'TextDocumentSaveReason'.
        /// </summary>
        [DataMember(Name = "reason")]
        public TextDocumentSaveReason Reason { get; init; }
    }

}