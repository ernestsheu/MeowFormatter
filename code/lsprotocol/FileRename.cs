// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Represents information on a file/folder rename.
    /// 
    /// </summary>
    [Since("3.16.0")]
    [DataContract]
    public record FileRename
    {
        [JsonConstructor]
        public FileRename(
            string oldUri,
            string newUri
        )
        {
            OldUri = oldUri;
            NewUri = newUri;
        }
        /// <summary>
        /// A file:// URI for the original location of the file/folder being renamed.
        /// </summary>
        [DataMember(Name = "oldUri")]
        public string OldUri { get; init; }
        /// <summary>
        /// A file:// URI for the new location of the file/folder being renamed.
        /// </summary>
        [DataMember(Name = "newUri")]
        public string NewUri { get; init; }
    }

}
