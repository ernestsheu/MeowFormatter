// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Client capabilities for the showDocument request.
    /// 
    /// </summary>
    [Since("3.16.0")]
    [DataContract]
    public record ShowDocumentClientCapabilities
    {
        [JsonConstructor]
        public ShowDocumentClientCapabilities(
            bool support
        )
        {
            Support = support;
        }
        /// <summary>
        /// The client has support for the showDocument
        /// request.
        /// </summary>
        [DataMember(Name = "support")]
        public bool Support { get; init; }
    }

}