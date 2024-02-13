// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    [JsonConverter(typeof(CustomObjectConverter<InitializedParams>))]
    [DataContract]
    public class InitializedParams: Dictionary<string, object?>
    {
        public InitializedParams(Dictionary<string, object?> value):base(value){}
    }

}