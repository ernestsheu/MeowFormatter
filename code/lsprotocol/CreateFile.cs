// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Create file operation.
    /// </summary>
    [DataContract]
    public record CreateFile
    {
        [JsonConstructor]
        public CreateFile(
            string kind,
            Uri uri,
            CreateFileOptions? options = null,
            ChangeAnnotationIdentifier? annotationId = null
        )
        {
            Kind = kind;
            Uri = uri;
            Options = options;
            AnnotationId = annotationId;
        }
        /// <summary>
        /// A create
        /// </summary>
        [DataMember(Name = "kind")]
        public string Kind { get; init; } = "create";
        /// <summary>
        /// The resource to create.
        /// </summary>
        [JsonConverter(typeof(CustomStringConverter<Uri>))]
        [DataMember(Name = "uri")]
        public Uri Uri { get; init; }
        /// <summary>
        /// Additional options
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "options")]
        public CreateFileOptions? Options { get; init; }
        /// <summary>
        /// An optional annotation identifier describing the operation.
        /// 
        /// </summary>
        [Since("3.16.0")]
        [JsonConverter(typeof(CustomStringConverter<ChangeAnnotationIdentifier>))]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "annotationId")]
        public ChangeAnnotationIdentifier? AnnotationId { get; init; }
    }

}
