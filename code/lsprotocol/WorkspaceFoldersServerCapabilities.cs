// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    [DataContract]
    public record WorkspaceFoldersServerCapabilities
    {
        [JsonConstructor]
        public WorkspaceFoldersServerCapabilities(
            bool? supported = null,
            OrType<string, bool>? changeNotifications = null
        )
        {
            Supported = supported;
            ChangeNotifications = changeNotifications;
        }
        /// <summary>
        /// The server has support for workspace folders
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "supported")]
        public bool? Supported { get; init; }
        /// <summary>
        /// Whether the server wants to receive workspace folder
        /// change notifications.
        /// 
        /// If a string is provided the string is treated as an ID
        /// under which the notification is registered on the client
        /// side. The ID can be used to unregister for these events
        /// using the `client/unregisterCapability` request.
        /// </summary>
        [JsonConverter(typeof(OrTypeConverter<string, bool>))]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "changeNotifications")]
        public OrType<string, bool>? ChangeNotifications { get; init; }
    }

}