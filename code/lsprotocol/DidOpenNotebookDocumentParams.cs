// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// The params sent in an open notebook document notification.
    /// 
    /// </summary>
    [Since("3.17.0")]
    [DataContract]
    public record DidOpenNotebookDocumentParams
    {
        [JsonConstructor]
        public DidOpenNotebookDocumentParams(
            NotebookDocument notebookDocument,
            ImmutableArray<TextDocumentItem> cellTextDocuments
        )
        {
            NotebookDocument = notebookDocument;
            CellTextDocuments = cellTextDocuments;
        }
        /// <summary>
        /// The notebook document that got opened.
        /// </summary>
        [DataMember(Name = "notebookDocument")]
        public NotebookDocument NotebookDocument { get; init; }
        /// <summary>
        /// The text documents that represent the content
        /// of a notebook cell.
        /// </summary>
        [JsonConverter(typeof(CustomArrayConverter<TextDocumentItem>))]
        [DataMember(Name = "cellTextDocuments")]
        public ImmutableArray<TextDocumentItem> CellTextDocuments { get; init; }
    }

}