// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Completion parameters
    /// </summary>
    [DataContract]
    public record CompletionParams
    {
        [JsonConstructor]
        public CompletionParams(
            TextDocumentIdentifier textDocument,
            Position position,
            CompletionContext? context = null,
            ProgressToken? workDoneToken = null,
            ProgressToken? partialResultToken = null
        )
        {
            Context = context;
            TextDocument = textDocument;
            Position = position;
            WorkDoneToken = workDoneToken;
            PartialResultToken = partialResultToken;
        }
        /// <summary>
        /// The completion context. This is only available it the client specifies
        /// to send this using the client capability `textDocument.completion.contextSupport === true`
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "context")]
        public CompletionContext? Context { get; init; }
        /// <summary>
        /// The text document.
        /// </summary>
        [DataMember(Name = "textDocument")]
        public TextDocumentIdentifier TextDocument { get; init; }
        /// <summary>
        /// The position inside the text document.
        /// </summary>
        [DataMember(Name = "position")]
        public Position Position { get; init; }
        /// <summary>
        /// An optional token that a server can use to report work done progress.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "workDoneToken")]
        public ProgressToken? WorkDoneToken { get; init; }
        /// <summary>
        /// An optional token that a server can use to report partial results (e.g. streaming) to
        /// the client.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "partialResultToken")]
        public ProgressToken? PartialResultToken { get; init; }
    }

}