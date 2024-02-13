// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    [DataContract]
    public record LogTraceParams
    {
        [JsonConstructor]
        public LogTraceParams(
            string message,
            string? verbose = null
        )
        {
            Message = message;
            Verbose = verbose;
        }
        [DataMember(Name = "message")]
        public string Message { get; init; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "verbose")]
        public string? Verbose { get; init; }
    }

}