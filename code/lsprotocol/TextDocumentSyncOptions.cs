// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    [DataContract]
    public record TextDocumentSyncOptions
    {
        [JsonConstructor]
        public TextDocumentSyncOptions(
            bool? openClose = null,
            TextDocumentSyncKind? change = null,
            bool? willSave = null,
            bool? willSaveWaitUntil = null,
            OrType<bool, SaveOptions>? save = null
        )
        {
            OpenClose = openClose;
            Change = change;
            WillSave = willSave;
            WillSaveWaitUntil = willSaveWaitUntil;
            Save = save;
        }
        /// <summary>
        /// Open and close notifications are sent to the server. If omitted open close notification should not
        /// be sent.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "openClose")]
        public bool? OpenClose { get; init; }
        /// <summary>
        /// Change notifications are sent to the server. See TextDocumentSyncKind.None, TextDocumentSyncKind.Full
        /// and TextDocumentSyncKind.Incremental. If omitted it defaults to TextDocumentSyncKind.None.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "change")]
        public TextDocumentSyncKind? Change { get; init; }
        /// <summary>
        /// If present will save notifications are sent to the server. If omitted the notification should not be
        /// sent.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "willSave")]
        public bool? WillSave { get; init; }
        /// <summary>
        /// If present will save wait until requests are sent to the server. If omitted the request should not be
        /// sent.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "willSaveWaitUntil")]
        public bool? WillSaveWaitUntil { get; init; }
        /// <summary>
        /// If present save notifications are sent to the server. If omitted the notification should not be
        /// sent.
        /// </summary>
        [JsonConverter(typeof(OrTypeConverter<bool, SaveOptions>))]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "save")]
        public OrType<bool, SaveOptions>? Save { get; init; }
    }

}
