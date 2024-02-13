// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Server Capabilities for a <see cref="SignatureHelpRequest" />.
    /// </summary>
    [DataContract]
    public record SignatureHelpOptions
    {
        [JsonConstructor]
        public SignatureHelpOptions(
            ImmutableArray<string> triggerCharacters = default!,
            ImmutableArray<string> retriggerCharacters = default!,
            bool? workDoneProgress = null
        )
        {
            TriggerCharacters = triggerCharacters;
            RetriggerCharacters = retriggerCharacters;
            WorkDoneProgress = workDoneProgress;
        }
        /// <summary>
        /// List of characters that trigger signature help automatically.
        /// </summary>
        [JsonConverter(typeof(CustomArrayConverter<string>))]
        [DataMember(Name = "triggerCharacters")]
        public ImmutableArray<string> TriggerCharacters { get; init; }
        /// <summary>
        /// List of characters that re-trigger signature help.
        /// 
        /// These trigger characters are only active when signature help is already showing. All trigger characters
        /// are also counted as re-trigger characters.
        /// 
        /// </summary>
        [Since("3.15.0")]
        [JsonConverter(typeof(CustomArrayConverter<string>))]
        [DataMember(Name = "retriggerCharacters")]
        public ImmutableArray<string> RetriggerCharacters { get; init; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "workDoneProgress")]
        public bool? WorkDoneProgress { get; init; }
    }

}