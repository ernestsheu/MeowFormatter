// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// An event describing a file change.
    /// </summary>
    [DataContract]
    public record FileEvent
    {
        [JsonConstructor]
        public FileEvent(
            Uri uri,
            FileChangeType type
        )
        {
            Uri = uri;
            Type = type;
        }
        /// <summary>
        /// The file's uri.
        /// </summary>
        [JsonConverter(typeof(CustomStringConverter<Uri>))]
        [DataMember(Name = "uri")]
        public Uri Uri { get; init; }
        /// <summary>
        /// The change type.
        /// </summary>
        [DataMember(Name = "type")]
        public FileChangeType Type { get; init; }
    }

}
