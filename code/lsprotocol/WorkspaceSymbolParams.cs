// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// The parameters of a <see cref="WorkspaceSymbolRequest" />.
    /// </summary>
    [DataContract]
    public record WorkspaceSymbolParams
    {
        [JsonConstructor]
        public WorkspaceSymbolParams(
            string query,
            ProgressToken? workDoneToken = null,
            ProgressToken? partialResultToken = null
        )
        {
            Query = query;
            WorkDoneToken = workDoneToken;
            PartialResultToken = partialResultToken;
        }
        /// <summary>
        /// A query string to filter symbols by. Clients may send an empty
        /// string here to request all symbols.
        /// </summary>
        [DataMember(Name = "query")]
        public string Query { get; init; }
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