// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// The moniker kind.
    /// 
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MonikerKind
    {
        /// <summary>
        /// The moniker represent a symbol that is imported into a project
        /// </summary>
        [EnumMember(Value = "import")]Import,

        /// <summary>
        /// The moniker represents a symbol that is exported from a project
        /// </summary>
        [EnumMember(Value = "export")]Export,

        /// <summary>
        /// The moniker represents a symbol that is local to a project (e.g. a local
        /// variable of a function, a class not visible outside the project, ...)
        /// </summary>
        [EnumMember(Value = "local")]Local,

    }
}
