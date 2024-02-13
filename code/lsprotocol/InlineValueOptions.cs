// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Inline value options used during static registration.
    /// 
    /// </summary>
    [Since("3.17.0")]
    [DataContract]
    public record InlineValueOptions
    {
        [JsonConstructor]
        public InlineValueOptions(
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