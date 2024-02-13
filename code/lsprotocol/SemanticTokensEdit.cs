// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    /// <summary>
    /// </summary>
    [Since("3.16.0")]
    [DataContract]
    public record SemanticTokensEdit
    {
        [JsonConstructor]
        public SemanticTokensEdit(
            long start,
            long deleteCount,
            ImmutableArray<long> data = default!
        )
        {
            Start = start;
            DeleteCount = deleteCount;
            Data = data;
        }
        /// <summary>
        /// The start offset of the edit.
        /// </summary>
        [DataMember(Name = "start")]
        public long Start { get => start; set => start = Validators.validUInteger(value); }
        private long start;
        /// <summary>
        /// The count of elements to remove.
        /// </summary>
        [DataMember(Name = "deleteCount")]
        public long DeleteCount { get => deleteCount; set => deleteCount = Validators.validUInteger(value); }
        private long deleteCount;
        /// <summary>
        /// The elements to insert.
        /// </summary>
        [JsonConverter(typeof(CustomArrayConverter<long>))]
        [DataMember(Name = "data")]
        public ImmutableArray<long> Data { get; init; }
    }

}