// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// The parameters sent in notifications/requests for user-initiated deletes of
    /// files.
    /// 
    /// </summary>
    [Since("3.16.0")]
    [DataContract]
    public record DeleteFilesParams
    {
        [JsonConstructor]
        public DeleteFilesParams(
            ImmutableArray<FileDelete> files
        )
        {
            Files = files;
        }
        /// <summary>
        /// An array of all files/folders deleted in this operation.
        /// </summary>
        [JsonConverter(typeof(CustomArrayConverter<FileDelete>))]
        [DataMember(Name = "files")]
        public ImmutableArray<FileDelete> Files { get; init; }
    }

}