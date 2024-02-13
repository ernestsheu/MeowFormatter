// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// A versioned notebook document identifier.
    /// 
    /// </summary>
    [Since("3.17.0")]
    [DataContract]
    public record VersionedNotebookDocumentIdentifier
    {
        [JsonConstructor]
        public VersionedNotebookDocumentIdentifier(
            int version,
            Uri uri
        )
        {
            Version = version;
            Uri = uri;
        }
        /// <summary>
        /// The version number of this notebook document.
        /// </summary>
        [DataMember(Name = "version")]
        public int Version { get; init; }
        /// <summary>
        /// The notebook document's uri.
        /// </summary>
        [JsonConverter(typeof(CustomStringConverter<Uri>))]
        [DataMember(Name = "uri")]
        public Uri Uri { get; init; }
    }

}
