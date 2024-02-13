// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// The parameters of a <see cref="RenameRequest" />.
    /// </summary>
    [DataContract]
    public record RenameParams
    {
        [JsonConstructor]
        public RenameParams(
            TextDocumentIdentifier textDocument,
            Position position,
            string newName,
            ProgressToken? workDoneToken = null
        )
        {
            TextDocument = textDocument;
            Position = position;
            NewName = newName;
            WorkDoneToken = workDoneToken;
        }
        /// <summary>
        /// The document to rename.
        /// </summary>
        [DataMember(Name = "textDocument")]
        public TextDocumentIdentifier TextDocument { get; init; }
        /// <summary>
        /// The position at which this request was sent.
        /// </summary>
        [DataMember(Name = "position")]
        public Position Position { get; init; }
        /// <summary>
        /// The new name of the symbol. If the given name is not valid the
        /// request must return a <see cref="ResponseError" /> with an
        /// appropriate message set.
        /// </summary>
        [DataMember(Name = "newName")]
        public string NewName { get; init; }
        /// <summary>
        /// An optional token that a server can use to report work done progress.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "workDoneToken")]
        public ProgressToken? WorkDoneToken { get; init; }
    }

}