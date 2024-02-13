// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Represents information on a file/folder create.
    /// 
    /// </summary>
    [Since("3.16.0")]
    [DataContract]
    public record FileCreate
    {
        [JsonConstructor]
        public FileCreate(
            string uri
        )
        {
            Uri = uri;
        }
        /// <summary>
        /// A file:// URI for the location of the file/folder being created.
        /// </summary>
        [DataMember(Name = "uri")]
        public string Uri { get; init; }
    }

}