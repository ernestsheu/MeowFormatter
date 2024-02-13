// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Provider options for a <see cref="DocumentLinkRequest" />.
    /// </summary>
    [DataContract]
    public record DocumentLinkOptions
    {
        [JsonConstructor]
        public DocumentLinkOptions(
            bool? resolveProvider = null,
            bool? workDoneProgress = null
        )
        {
            ResolveProvider = resolveProvider;
            WorkDoneProgress = workDoneProgress;
        }
        /// <summary>
        /// Document links have a resolve provider as well.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "resolveProvider")]
        public bool? ResolveProvider { get; init; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "workDoneProgress")]
        public bool? WorkDoneProgress { get; init; }
    }

}
