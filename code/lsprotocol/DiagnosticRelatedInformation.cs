// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Represents a related message and source code location for a diagnostic. This should be
    /// used to point to code locations that cause or related to a diagnostics, e.g when duplicating
    /// a symbol in a scope.
    /// </summary>
    [DataContract]
    public record DiagnosticRelatedInformation
    {
        [JsonConstructor]
        public DiagnosticRelatedInformation(
            Location location,
            string message
        )
        {
            Location = location;
            Message = message;
        }
        /// <summary>
        /// The location of this related diagnostic information.
        /// </summary>
        [DataMember(Name = "location")]
        public Location Location { get; init; }
        /// <summary>
        /// The message of this related diagnostic information.
        /// </summary>
        [DataMember(Name = "message")]
        public string Message { get; init; }
    }

}
