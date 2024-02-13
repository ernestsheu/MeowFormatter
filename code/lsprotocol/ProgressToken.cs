// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    [JsonConverter(typeof(ProgressTokenConverter))]
    [DataContract]
    public record ProgressToken: OrType<int, string>
    {
        public ProgressToken(int intValue): base(intValue) {}
        public ProgressToken(string stringValue): base(stringValue) {}
    }

}
