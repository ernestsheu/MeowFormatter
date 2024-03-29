// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Inline completion options used during static registration.
    /// 
    /// </summary>
    [Proposed]
    [Since("3.18.0")]
    [DataContract]
    public record InlineCompletionOptions
    {
        [JsonConstructor]
        public InlineCompletionOptions(
            bool? workDoneProgress = null
        )
        {
            WorkDoneProgress = workDoneProgress;
        }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "workDoneProgress")]
        public bool? WorkDoneProgress { get; init; }
    }

}
