// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Represents a reference to a command. Provides a title which
    /// will be used to represent a command in the UI and, optionally,
    /// an array of arguments which will be passed to the command handler
    /// function when invoked.
    /// </summary>
    [DataContract]
    public record CommandAction
    {
        [JsonConstructor]
        public CommandAction(
            string title,
            string command,
            string? tooltip = null,
            ImmutableArray<LSPAny> arguments = default!
        )
        {
            Title = title;
            Tooltip = tooltip;
            Command = command;
            Arguments = arguments;
        }
        /// <summary>
        /// Title of the command, like `save`.
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; init; }
        /// <summary>
        /// An optional tooltip.
        /// 
        /// </summary>
        [Proposed]
        [Since("3.18.0")]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "tooltip")]
        public string? Tooltip { get; init; }
        /// <summary>
        /// The identifier of the actual command handler.
        /// </summary>
        [DataMember(Name = "command")]
        public string Command { get; init; }
        /// <summary>
        /// Arguments that the command handler should be
        /// invoked with.
        /// </summary>
        [JsonConverter(typeof(CustomArrayConverter<LSPAny>))]
        [DataMember(Name = "arguments")]
        public ImmutableArray<LSPAny> Arguments { get; init; }
    }

}
