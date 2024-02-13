// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// A shutdown request is sent from the client to the server.
    /// It is sent once when the client decides to shutdown the
    /// server. The only notification that is sent after a shutdown request
    /// is the exit event.
    /// </summary>
    [LSPResponse(typeof(ShutdownRequest))]
    [DataContract]
    public record ShutdownResponse: IResponse<object>
    {
        [JsonConstructor]
        public ShutdownResponse(
            OrType<string, int> id,
            string jsonrpc = "2.0",
            object? result = null,
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
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "result")]
        public object? Result { get; init; }
        /// <summary>
        /// Error while handling the request.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "error")]
        public ResponseError? Error { get; init; }
    }

}
