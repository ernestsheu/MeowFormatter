// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// A special text edit with an additional change annotation.
    /// 
    /// </summary>
    [Since("3.16.0.")]
    [DataContract]
    public record AnnotatedTextEdit
    {
        [JsonConstructor]
        public AnnotatedTextEdit(
            ChangeAnnotationIdentifier annotationId,
            Range range,
            string newText
        )
        {
            AnnotationId = annotationId;
            Range = range;
            NewText = newText;
        }
        /// <summary>
        /// The actual identifier of the change annotation
        /// </summary>
        [JsonConverter(typeof(CustomStringConverter<ChangeAnnotationIdentifier>))]
        [DataMember(Name = "annotationId")]
        public ChangeAnnotationIdentifier AnnotationId { get; init; }
        /// <summary>
        /// The range of the text document to be manipulated. To insert
        /// text into a document create a range where start === end.
        /// </summary>
        [DataMember(Name = "range")]
        public Range Range { get; init; }
        /// <summary>
        /// The string to be inserted. For delete operations use an
        /// empty string.
        /// </summary>
        [DataMember(Name = "newText")]
        public string NewText { get; init; }
    }

}
