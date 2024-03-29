// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// A relative pattern is a helper to construct glob patterns that are matched
    /// relatively to a base URI. The common value for a `baseUri` is a workspace
    /// folder root, but it can be another absolute URI as well.
    /// 
    /// </summary>
    [Since("3.17.0")]
    [DataContract]
    public record RelativePattern
    {
        [JsonConstructor]
        public RelativePattern(
            OrType<WorkspaceFolder, Uri> baseUri,
            Pattern pattern
        )
        {
            BaseUri = baseUri;
            Pattern = pattern;
        }
        /// <summary>
        /// A workspace folder or a base URI to which this pattern will be matched
        /// against relatively.
        /// </summary>
        [JsonConverter(typeof(OrTypeConverter<WorkspaceFolder, Uri>))]
        [DataMember(Name = "baseUri")]
        public OrType<WorkspaceFolder, Uri> BaseUri { get; init; }
        /// <summary>
        /// The actual glob pattern;
        /// </summary>
        [JsonConverter(typeof(CustomStringConverter<Pattern>))]
        [DataMember(Name = "pattern")]
        public Pattern Pattern { get; init; }
    }

}
