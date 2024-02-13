// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// The parameters passed via an apply workspace edit request.
    /// </summary>
    [DataContract]
    public record ApplyWorkspaceEditParams
    {
        [JsonConstructor]
        public ApplyWorkspaceEditParams(
            WorkspaceEdit edit,
            string? label = null
        )
        {
            Label = label;
            Edit = edit;
        }
        /// <summary>
        /// An optional label of the workspace edit. This label is
        /// presented in the user interface for example on an undo
        /// stack to undo the workspace edit.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "label")]
        public string? Label { get; init; }
        /// <summary>
        /// The edits to apply.
        /// </summary>
        [DataMember(Name = "edit")]
        public WorkspaceEdit Edit { get; init; }
    }

}