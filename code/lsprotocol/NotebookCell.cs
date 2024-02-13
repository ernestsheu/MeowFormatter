// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// A notebook cell.
    /// 
    /// A cell's document URI must be unique across ALL notebook
    /// cells and can therefore be used to uniquely identify a
    /// notebook cell or the cell's text document.
    /// 
    /// </summary>
    [Since("3.17.0")]
    [DataContract]
    public record NotebookCell
    {
        [JsonConstructor]
        public NotebookCell(
            NotebookCellKind kind,
            Uri document,
            LSPObject? metadata = null,
            ExecutionSummary? executionSummary = null
        )
        {
            Kind = kind;
            Document = document;
            Metadata = metadata;
            ExecutionSummary = executionSummary;
        }
        /// <summary>
        /// The cell's kind
        /// </summary>
        [DataMember(Name = "kind")]
        public NotebookCellKind Kind { get; init; }
        /// <summary>
        /// The URI of the cell's text document
        /// content.
        /// </summary>
        [JsonConverter(typeof(CustomStringConverter<Uri>))]
        [DataMember(Name = "document")]
        public Uri Document { get; init; }
        /// <summary>
        /// Additional metadata stored with the cell.
        /// 
        /// Note: should always be an object literal (e.g. LSPObject)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "metadata")]
        public LSPObject? Metadata { get; init; }
        /// <summary>
        /// Additional execution summary information
        /// if supported by the client.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "executionSummary")]
        public ExecutionSummary? ExecutionSummary { get; init; }
    }

}
