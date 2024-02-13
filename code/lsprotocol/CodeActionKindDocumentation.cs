// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Documentation for a class of code actions.
    /// 
    /// </summary>
    [Proposed]
    [Since("3.18.0")]
    [DataContract]
    public record CodeActionKindDocumentation
    {
        [JsonConstructor]
        public CodeActionKindDocumentation(
            string kind,
            CommandAction command
        )
        {
            Kind = kind;
            Command = command;
        }
        /// <summary>
        /// The kind of the code action being documented.
        /// 
        /// If the kind is generic, such as `CodeActionKind.Refactor`, the documentation will be shown whenever any
        /// refactorings are returned. If the kind if more specific, such as `CodeActionKind.RefactorExtract`, the
        /// documentation will only be shown when extract refactoring code actions are returned.
        /// </summary>
        [DataMember(Name = "kind")]
        public string Kind { get; init; }
        /// <summary>
        /// Command that is ued to display the documentation to the user.
        /// 
        /// The title of this documentation code action is taken from {@linkcode Command.title}
        /// </summary>
        [DataMember(Name = "command")]
        public CommandAction Command { get; init; }
    }

}
