// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// The parameters of a <see cref="ExecuteCommandRequest" />.
    /// </summary>
    [DataContract]
    public record ExecuteCommandParams
    {
        [JsonConstructor]
        public ExecuteCommandParams(
            string command,
            ImmutableArray<LSPAny> arguments = default!,
            ProgressToken? workDoneToken = null
        )
        {
            Command = command;
            Arguments = arguments;
            WorkDoneToken = workDoneToken;
        }
        /// <summary>
        /// The identifier of the actual command handler.
        /// </summary>
        [DataMember(Name = "command")]
        public string Command { get; init; }
        /// <summary>
        /// Arguments that the command should be invoked with.
        /// </summary>
        [JsonConverter(typeof(CustomArrayConverter<LSPAny>))]
        [DataMember(Name = "arguments")]
        public ImmutableArray<LSPAny> Arguments { get; init; }
        /// <summary>
        /// An optional token that a server can use to report work done progress.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "workDoneToken")]
        public ProgressToken? WorkDoneToken { get; init; }
    }

}
