// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// A string value used as a snippet is a template which allows to insert text
    /// and to control the editor cursor when insertion happens.
    /// 
    /// A snippet can define tab stops and placeholders with `$1`, `$2`
    /// and `${3:foo}`. `$0` defines the final tab stop, it defaults to
    /// the end of the snippet. Variables are defined with `$name` and
    /// `${name:default value}`.
    /// 
    /// </summary>
    [Proposed]
    [Since("3.18.0")]
    [DataContract]
    public record StringValue
    {
        [JsonConstructor]
        public StringValue(
            string kind,
            string value
        )
        {
            Kind = kind;
            Value = value;
        }
        /// <summary>
        /// The kind of string value.
        /// </summary>
        [DataMember(Name = "kind")]
        public string Kind { get; init; } = "snippet";
        /// <summary>
        /// The snippet string.
        /// </summary>
        [DataMember(Name = "value")]
        public string Value { get; init; }
    }

}
