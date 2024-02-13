// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// The params sent in a save notebook document notification.
    /// 
    /// </summary>
    [Since("3.17.0")]
    [DataContract]
    public record DidSaveNotebookDocumentParams
    {
        [JsonConstructor]
        public DidSaveNotebookDocumentParams(
            NotebookDocumentIdentifier notebookDocument
        )
        {
            NotebookDocument = notebookDocument;
        }
        /// <summary>
        /// The notebook document that got saved.
        /// </summary>
        [DataMember(Name = "notebookDocument")]
        public NotebookDocumentIdentifier NotebookDocument { get; init; }
    }

}