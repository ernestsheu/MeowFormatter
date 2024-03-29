// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// </summary>
    [Proposed]
    [Since("3.18.0")]
    [DataContract]
    public record NotebookDocumentFilterWithCells
    {
        [JsonConstructor]
        public NotebookDocumentFilterWithCells(
            ImmutableArray<NotebookCellLanguage> cells,
            OrType<string, NotebookDocumentFilter>? notebook = null
        )
        {
            Notebook = notebook;
            Cells = cells;
        }
        /// <summary>
        /// The notebook to be synced If a string
        /// value is provided it matches against the
        /// notebook type. '*' matches every notebook.
        /// </summary>
        [JsonConverter(typeof(OrTypeConverter<string, NotebookDocumentFilter>))]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "notebook")]
        public OrType<string, NotebookDocumentFilter>? Notebook { get; init; }
        /// <summary>
        /// The cells of the matching notebook to be synced.
        /// </summary>
        [JsonConverter(typeof(CustomArrayConverter<NotebookCellLanguage>))]
        [DataMember(Name = "cells")]
        public ImmutableArray<NotebookCellLanguage> Cells { get; init; }
    }

}
