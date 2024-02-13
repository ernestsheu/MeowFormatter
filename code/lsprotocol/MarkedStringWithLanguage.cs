// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// </summary>
    [Obsolete("use MarkupContent instead.")]
    [Proposed]
    [Since("3.18.0")]
    [DataContract]
    public record MarkedStringWithLanguage
    {
        [JsonConstructor]
        public MarkedStringWithLanguage(
            string language,
            string value
        )
        {
            Language = language;
            Value = value;
        }
        [DataMember(Name = "language")]
        public string Language { get; init; }
        [DataMember(Name = "value")]
        public string Value { get; init; }
    }

}