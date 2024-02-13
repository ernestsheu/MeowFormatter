// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Capabilities specific to the notebook document support.
    /// 
    /// </summary>
    [Since("3.17.0")]
    [DataContract]
    public record NotebookDocumentClientCapabilities
    {
        [JsonConstructor]
        public NotebookDocumentClientCapabilities(
            NotebookDocumentSyncClientCapabilities synchronization
        )
        {
            Synchronization = synchronization;
        }
        /// <summary>
        /// Capabilities specific to notebook document synchronization
        /// 
        /// </summary>
        [Since("3.17.0")]
        [DataMember(Name = "synchronization")]
        public NotebookDocumentSyncClientCapabilities Synchronization { get; init; }
    }

}
