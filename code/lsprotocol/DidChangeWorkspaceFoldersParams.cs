// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// The parameters of a `workspace/didChangeWorkspaceFolders` notification.
    /// </summary>
    [DataContract]
    public record DidChangeWorkspaceFoldersParams
    {
        [JsonConstructor]
        public DidChangeWorkspaceFoldersParams(
            WorkspaceFoldersChangeEvent eventArgs
        )
        {
            Event = eventArgs;
        }
        /// <summary>
        /// The actual workspace folder change event.
        /// </summary>
        [DataMember(Name = "event")]
        public WorkspaceFoldersChangeEvent Event { get; init; }
    }

}
