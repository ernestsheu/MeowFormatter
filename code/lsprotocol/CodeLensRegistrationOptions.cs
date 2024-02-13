// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Registration options for a <see cref="CodeLensRequest" />.
    /// </summary>
    [DataContract]
    public record CodeLensRegistrationOptions
    {
        [JsonConstructor]
        public CodeLensRegistrationOptions(
            DocumentSelector? documentSelector = null,
            bool? resolveProvider = null,
            bool? workDoneProgress = null
        )
        {
            DocumentSelector = documentSelector;
            ResolveProvider = resolveProvider;
            WorkDoneProgress = workDoneProgress;
        }
        /// <summary>
        /// A document selector to identify the scope of the registration. If set to null
        /// the document selector provided on the client side will be used.
        /// </summary>
        [JsonConverter(typeof(DocumentSelectorConverter))]
        [DataMember(Name = "documentSelector")]
        public DocumentSelector? DocumentSelector { get; init; }
        /// <summary>
        /// Code lens has a resolve provider as well.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "resolveProvider")]
        public bool? ResolveProvider { get; init; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "workDoneProgress")]
        public bool? WorkDoneProgress { get; init; }
    }

}
