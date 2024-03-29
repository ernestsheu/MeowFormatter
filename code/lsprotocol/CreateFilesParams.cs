// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// The parameters sent in notifications/requests for user-initiated creation of
    /// files.
    /// 
    /// </summary>
    [Since("3.16.0")]
    [DataContract]
    public record CreateFilesParams
    {
        [JsonConstructor]
        public CreateFilesParams(
            ImmutableArray<FileCreate> files
        )
        {
            Files = files;
        }
        /// <summary>
        /// An array of all files/folders created in this operation.
        /// </summary>
        [JsonConverter(typeof(CustomArrayConverter<FileCreate>))]
        [DataMember(Name = "files")]
        public ImmutableArray<FileCreate> Files { get; init; }
    }

}
