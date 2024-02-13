// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Rename file options
    /// </summary>
    [DataContract]
    public record RenameFileOptions
    {
        [JsonConstructor]
        public RenameFileOptions(
            bool? overwrite = null,
            bool? ignoreIfExists = null
        )
        {
            Overwrite = overwrite;
            IgnoreIfExists = ignoreIfExists;
        }
        /// <summary>
        /// Overwrite target if existing. Overwrite wins over `ignoreIfExists`
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "overwrite")]
        public bool? Overwrite { get; init; }
        /// <summary>
        /// Ignores if target exists.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "ignoreIfExists")]
        public bool? IgnoreIfExists { get; init; }
    }

}
