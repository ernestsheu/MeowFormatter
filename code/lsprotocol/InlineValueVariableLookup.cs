// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Provide inline value through a variable lookup.
    /// If only a range is specified, the variable name will be extracted from the underlying document.
    /// An optional variable name can be used to override the extracted name.
    /// 
    /// </summary>
    [Since("3.17.0")]
    [DataContract]
    public record InlineValueVariableLookup
    {
        [JsonConstructor]
        public InlineValueVariableLookup(
            Range range,
            bool caseSensitiveLookup,
            string? variableName = null
        )
        {
            Range = range;
            VariableName = variableName;
            CaseSensitiveLookup = caseSensitiveLookup;
        }
        /// <summary>
        /// The document range for which the inline value applies.
        /// The range is used to extract the variable name from the underlying document.
        /// </summary>
        [DataMember(Name = "range")]
        public Range Range { get; init; }
        /// <summary>
        /// If specified the name of the variable to look up.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "variableName")]
        public string? VariableName { get; init; }
        /// <summary>
        /// How to perform the lookup.
        /// </summary>
        [DataMember(Name = "caseSensitiveLookup")]
        public bool CaseSensitiveLookup { get; init; }
    }

}
