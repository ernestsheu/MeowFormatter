// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// A document filter describes a top level text document or
    /// a notebook cell document.
    /// 
    /// </summary>
    [Since("3.17.0 - proposed support for NotebookCellTextDocumentFilter.")]
    [JsonConverter(typeof(DocumentFilterConverter))]
    [DataContract]
    public record DocumentFilter: OrType<TextDocumentFilter, NotebookCellTextDocumentFilter>
    {
        public DocumentFilter(TextDocumentFilter TextDocumentFilter): base(TextDocumentFilter) {}
        public DocumentFilter(NotebookCellTextDocumentFilter NotebookCellTextDocumentFilter): base(NotebookCellTextDocumentFilter) {}
    }

}
