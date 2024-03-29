// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// </summary>
    [Proposed]
    [Since("3.18.0")]
    [DataContract]
    public record PrepareRenameDefaultBehavior
    {
        [JsonConstructor]
        public PrepareRenameDefaultBehavior(
            bool defaultBehavior
        )
        {
            DefaultBehavior = defaultBehavior;
        }
        [DataMember(Name = "defaultBehavior")]
        public bool DefaultBehavior { get; init; }
    }

}
