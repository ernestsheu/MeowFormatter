// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// General parameters to unregister a request or notification.
    /// </summary>
    [DataContract]
    public record Unregistration
    {
        [JsonConstructor]
        public Unregistration(
            string id,
            string method
        )
        {
            Id = id;
            Method = method;
        }
        /// <summary>
        /// The id used to unregister the request or notification. Usually an id
        /// provided during the register request.
        /// </summary>
        [DataMember(Name = "id")]
        public string Id { get; init; }
        /// <summary>
        /// The method to unregister for.
        /// </summary>
        [DataMember(Name = "method")]
        public string Method { get; init; }
    }

}
