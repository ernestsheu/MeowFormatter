// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// A text document identifier to optionally denote a specific version of a text document.
    /// </summary>
    [DataContract]
    public record OptionalVersionedTextDocumentIdentifier
    {
        [JsonConstructor]
        public OptionalVersionedTextDocumentIdentifier(
            Uri uri,
            int? version = null
        )
        {
            Version = version;
            Uri = uri;
        }
        /// <summary>
        /// The version number of this document. If a versioned text document identifier
        /// is sent from the server to the client and the file is not open in the editor
        /// (the server has not received an open notification before) the server can send
        /// `null` to indicate that the version is unknown and the content on disk is the
        /// truth (as specified with document content ownership).
        /// </summary>
        [DataMember(Name = "version")]
        public int? Version { get; init; }
        /// <summary>
        /// The text document's uri.
        /// </summary>
        [JsonConverter(typeof(CustomStringConverter<Uri>))]
        [DataMember(Name = "uri")]
        public Uri Uri { get; init; }
    }

}
