// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    [JsonConverter(typeof(PrepareRenameResultConverter))]
    [DataContract]
    public record PrepareRenameResult: OrType<Range, PrepareRenamePlaceholder, PrepareRenameDefaultBehavior>
    {
        public PrepareRenameResult(Range Range): base(Range) {}
        public PrepareRenameResult(PrepareRenamePlaceholder PrepareRenamePlaceholder): base(PrepareRenamePlaceholder) {}
        public PrepareRenameResult(PrepareRenameDefaultBehavior PrepareRenameDefaultBehavior): base(PrepareRenameDefaultBehavior) {}
    }

}
