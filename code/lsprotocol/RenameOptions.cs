// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Provider options for a <see cref="RenameRequest" />.
    /// </summary>
    [DataContract]
    public record RenameOptions
    {
        [JsonConstructor]
        public RenameOptions(
            bool? prepareProvider = null,
            bool? workDoneProgress = null
        )
        {
            PrepareProvider = prepareProvider;
            WorkDoneProgress = workDoneProgress;
        }
        /// <summary>
        /// Renames should be checked and tested before being executed.
        /// 
        /// </summary>
        [Since("version 3.12.0")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "prepareProvider")]
        public bool? PrepareProvider { get; init; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "workDoneProgress")]
        public bool? WorkDoneProgress { get; init; }
    }

}