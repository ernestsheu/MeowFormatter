// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// A notebook document filter where `scheme` is required field.
    /// 
    /// </summary>
    [Proposed]
    [Since("3.18.0")]
    [DataContract]
    public record NotebookDocumentFilterScheme
    {
        [JsonConstructor]
        public NotebookDocumentFilterScheme(
            string scheme,
            string? notebookType = null,
            string? pattern = null
        )
        {
            NotebookType = notebookType;
            Scheme = scheme;
            Pattern = pattern;
        }
        /// <summary>
        /// The type of the enclosing notebook.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "notebookType")]
        public string? NotebookType { get; init; }
        /// <summary>
        /// A Uri <see cref="Uri.scheme">scheme</see>, like `file` or `untitled`.
        /// </summary>
        [DataMember(Name = "scheme")]
        public string Scheme { get; init; }
        /// <summary>
        /// A glob pattern.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "pattern")]
        public string? Pattern { get; init; }
    }

}
