// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Parameters for a <see cref="ColorPresentationRequest" />.
    /// </summary>
    [DataContract]
    public record ColorPresentationParams
    {
        [JsonConstructor]
        public ColorPresentationParams(
            TextDocumentIdentifier textDocument,
            Color color,
            Range range,
            ProgressToken? workDoneToken = null,
            ProgressToken? partialResultToken = null
        )
        {
            TextDocument = textDocument;
            Color = color;
            Range = range;
            WorkDoneToken = workDoneToken;
            PartialResultToken = partialResultToken;
        }
        /// <summary>
        /// The text document.
        /// </summary>
        [DataMember(Name = "textDocument")]
        public TextDocumentIdentifier TextDocument { get; init; }
        /// <summary>
        /// The color to request presentations for.
        /// </summary>
        [DataMember(Name = "color")]
        public Color Color { get; init; }
        /// <summary>
        /// The range where the color would be inserted. Serves as a context.
        /// </summary>
        [DataMember(Name = "range")]
        public Range Range { get; init; }
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