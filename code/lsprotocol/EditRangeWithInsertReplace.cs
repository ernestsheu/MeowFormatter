// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Edit range variant that includes ranges for insert and replace operations.
    /// 
    /// </summary>
    [Proposed]
    [Since("3.18.0")]
    [DataContract]
    public record EditRangeWithInsertReplace
    {
        [JsonConstructor]
        public EditRangeWithInsertReplace(
            Range insert,
            Range replace
        )
        {
            Insert = insert;
            Replace = replace;
        }
        [DataMember(Name = "insert")]
        public Range Insert { get; init; }
        [DataMember(Name = "replace")]
        public Range Replace { get; init; }
    }

}