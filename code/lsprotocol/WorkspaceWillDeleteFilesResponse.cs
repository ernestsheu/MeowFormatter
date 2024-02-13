// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// The did delete files notification is sent from the client to the server when
    /// files were deleted from within the client.
    /// 
    /// </summary>
    [Since("3.16.0")]
    [LSPResponse(typeof(WorkspaceWillDeleteFilesRequest))]
    [DataContract]
    public record WorkspaceWillDeleteFilesResponse: IResponse<WorkspaceEdit>
    {
        [JsonConstructor]
        public WorkspaceWillDeleteFilesResponse(
            OrType<string, int> id,
            string jsonrpc = "2.0",
            WorkspaceEdit? result = null,
            ResponseError? error = null
        )
        {
            JsonRPC = jsonrpc;
            Id = id;
            Result = result;
            Error = error;
        }
        /// <summary>
        /// The jsonrpc version.
        /// </summary>
        [DataMember(Name = "jsonrpc")]
        public string JsonRPC { get; init; } = "2.0";
        /// <summary>
        /// The Request id.
        /// </summary>
        [JsonConverter(typeof(OrTypeConverter<string, int>))]
        [DataMember(Name = "id")]
        public OrType<string, int> Id { get; init; }
        /// <summary>
        /// Results for the request.
        /// </summary>
        [DataMember(Name = "result")]
        public WorkspaceEdit? Result { get; init; }
        /// <summary>
        /// Error while handling the request.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "error")]
        public ResponseError? Error { get; init; }
    }

}
