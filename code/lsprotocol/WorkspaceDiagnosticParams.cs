// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Parameters of the workspace diagnostic request.
    /// 
    /// </summary>
    [Since("3.17.0")]
    [DataContract]
    public record WorkspaceDiagnosticParams
    {
        [JsonConstructor]
        public WorkspaceDiagnosticParams(
            ImmutableArray<PreviousResultId> previousResultIds,
            string? identifier = null,
            ProgressToken? workDoneToken = null,
            ProgressToken? partialResultToken = null
        )
        {
            Identifier = identifier;
            PreviousResultIds = previousResultIds;
            WorkDoneToken = workDoneToken;
            PartialResultToken = partialResultToken;
        }
        /// <summary>
        /// The additional identifier provided during registration.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "identifier")]
        public string? Identifier { get; init; }
        /// <summary>
        /// The currently known diagnostic reports with their
        /// previous result ids.
        /// </summary>
        [JsonConverter(typeof(CustomArrayConverter<PreviousResultId>))]
        [DataMember(Name = "previousResultIds")]
        public ImmutableArray<PreviousResultId> PreviousResultIds { get; init; }
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
