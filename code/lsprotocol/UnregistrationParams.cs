// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    [DataContract]
    public record UnregistrationParams
    {
        [JsonConstructor]
        public UnregistrationParams(
            ImmutableArray<Unregistration> unregisterations
        )
        {
            Unregisterations = unregisterations;
        }
        [JsonConverter(typeof(CustomArrayConverter<Unregistration>))]
        [DataMember(Name = "unregisterations")]
        public ImmutableArray<Unregistration> Unregisterations { get; init; }
    }

}
