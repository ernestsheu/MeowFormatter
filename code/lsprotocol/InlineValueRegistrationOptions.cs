// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Inline value options used during static or dynamic registration.
    /// 
    /// </summary>
    [Since("3.17.0")]
    [DataContract]
    public record InlineValueRegistrationOptions
    {
        [JsonConstructor]
        public InlineValueRegistrationOptions(
            bool? workDoneProgress = null,
            DocumentSelector? documentSelector = null,
            string? id = null
        )
        {
            WorkDoneProgress = workDoneProgress;
            DocumentSelector = documentSelector;
            Id = id;
        }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "workDoneProgress")]
        public bool? WorkDoneProgress { get; init; }
        /// <summary>
        /// A document selector to identify the scope of the registration. If set to null
        /// the document selector provided on the client side will be used.
        /// </summary>
        [JsonConverter(typeof(DocumentSelectorConverter))]
        [DataMember(Name = "documentSelector")]
        public DocumentSelector? DocumentSelector { get; init; }
        /// <summary>
        /// The id used to register the request. The id can be used to deregister
        /// the request again. See also Registration#id.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember(Name = "id")]
        public string? Id { get; init; }
    }

}