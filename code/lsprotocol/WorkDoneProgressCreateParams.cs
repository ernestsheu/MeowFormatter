// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    [DataContract]
    public record WorkDoneProgressCreateParams
    {
        [JsonConstructor]
        public WorkDoneProgressCreateParams(
            ProgressToken token
        )
        {
            Token = token;
        }
        /// <summary>
        /// The token to be used to report progress.
        /// </summary>
        [DataMember(Name = "token")]
        public ProgressToken Token { get; init; }
    }

}
