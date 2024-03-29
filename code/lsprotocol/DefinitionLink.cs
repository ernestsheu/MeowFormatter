// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// Information about where a symbol is defined.
    /// 
    /// Provides additional metadata over normal <see cref="Location">location</see> definitions, including the range of
    /// the defining symbol
    /// </summary>
    [DataContract]
    public record DefinitionLink: LocationLink
    {
        public DefinitionLink(Uri targetUri,Range targetRange,Range targetSelectionRange,Range? originSelectionRange = null): base(targetUri,targetRange,targetSelectionRange,originSelectionRange) {}
    }

}
