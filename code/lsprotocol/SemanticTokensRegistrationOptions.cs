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
    public record SemanticTokensRegistrationOptions
    {
        [JsonConstructor]
        public SemanticTokensRegistrationOptions(
            SemanticTokensLegend legend,
            DocumentSelector? documentSelector = null,
            OrType<bool, LSPObject>? range = null,
            OrType<bool, SemanticTokensFullDelta>? full = null,
            bool? workDoneProgress = null,
            string? id = null
        )
        {
            DocumentSelector = documentSelector;
            Legend = legend;
            Range = range;
            Full = full;
            WorkDoneProgress = workDoneProgress;
            Id = id;
        }
        /// <summary>
        /// A document selector to identify the scope of the registration. If set to null
        /// the document selector provided on the client side will be used.
        /// </summary>
        [JsonConverter(typeof(DocumentSelectorConverter))]
        [DataMember(Name = "documentSelector")]
        public DocumentSelector? DocumentSelector { get; init; }
        /// <summary>
        /// The legend used by the server
        /// </summary>
        [DataMember(Name = "legend")]
        public SemanticTokensLegend Legend { get; init; }
        /// <summary>
        /// Server supports providing semantic tokens for a specific range
        /// of a document.
        /// </summary>
        [JsonConverter(typeof(OrTypeConverter<bool, LSPObject>))]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "range")]
        public OrType<bool, LSPObject>? Range { get; init; }
        /// <summary>
        /// Server supports providing semantic tokens for a full document.
        /// </summary>
        [JsonConverter(typeof(OrTypeConverter<bool, SemanticTokensFullDelta>))]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "full")]
        public OrType<bool, SemanticTokensFullDelta>? Full { get; init; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "workDoneProgress")]
        public bool? WorkDoneProgress { get; init; }
        /// <summary>
        /// The id used to register the request. The id can be used to deregister
        /// the request again. See also Registration#id.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "id")]
        public string? Id { get; init; }
    }

}