// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Capabilities relating to events from file operations by the user in the client.
    /// 
    /// These events do not come from the file system, they come from user operations
    /// like renaming a file in the UI.
    /// 
    /// </summary>
    [Since("3.16.0")]
    [DataContract]
    public record FileOperationClientCapabilities
    {
        [JsonConstructor]
        public FileOperationClientCapabilities(
            bool? dynamicRegistration = null,
            bool? didCreate = null,
            bool? willCreate = null,
            bool? didRename = null,
            bool? willRename = null,
            bool? didDelete = null,
            bool? willDelete = null
        )
        {
            DynamicRegistration = dynamicRegistration;
            DidCreate = didCreate;
            WillCreate = willCreate;
            DidRename = didRename;
            WillRename = willRename;
            DidDelete = didDelete;
            WillDelete = willDelete;
        }
        /// <summary>
        /// Whether the client supports dynamic registration for file requests/notifications.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "dynamicRegistration")]
        public bool? DynamicRegistration { get; init; }
        /// <summary>
        /// The client has support for sending didCreateFiles notifications.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "didCreate")]
        public bool? DidCreate { get; init; }
        /// <summary>
        /// The client has support for sending willCreateFiles requests.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "willCreate")]
        public bool? WillCreate { get; init; }
        /// <summary>
        /// The client has support for sending didRenameFiles notifications.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "didRename")]
        public bool? DidRename { get; init; }
        /// <summary>
        /// The client has support for sending willRenameFiles requests.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "willRename")]
        public bool? WillRename { get; init; }
        /// <summary>
        /// The client has support for sending didDeleteFiles notifications.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "didDelete")]
        public bool? DidDelete { get; init; }
        /// <summary>
        /// The client has support for sending willDeleteFiles requests.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "willDelete")]
        public bool? WillDelete { get; init; }
    }

}