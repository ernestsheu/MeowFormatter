// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// </summary>
    [Since("3.16.0")]
    [DataContract]
    public record SemanticTokensParams
    {
        [JsonConstructor]
        public SemanticTokensParams(
            TextDocumentIdentifier textDocument,
            ProgressToken? workDoneToken = null,
            ProgressToken? partialResultToken = null
        )
        {
            TextDocument = textDocument;
            WorkDoneToken = workDoneToken;
            PartialResultToken = partialResultToken;
        }
        /// <summary>
        /// The text document.
        /// </summary>
        [DataMember(Name = "textDocument")]
        public TextDocumentIdentifier TextDocument { get; init; }
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
