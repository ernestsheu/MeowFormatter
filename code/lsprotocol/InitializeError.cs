// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// The data type of the ResponseError if the
    /// initialize request fails.
    /// </summary>
    [DataContract]
    public record InitializeError
    {
        [JsonConstructor]
        public InitializeError(
            bool retry
        )
        {
            Retry = retry;
        }
        /// <summary>
        /// Indicates whether the client execute the following retry logic:
        /// (1) show the message provided by the ResponseError to the user
        /// (2) user selects retry or cancel
        /// (3) if user selected retry the initialize method is sent again.
        /// </summary>
        [DataMember(Name = "retry")]
        public bool Retry { get; init; }
    }

}