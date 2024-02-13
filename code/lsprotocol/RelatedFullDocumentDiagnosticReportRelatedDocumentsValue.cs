// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Microsoft.LanguageServer.Protocol {
    [JsonConverter(typeof(RelatedFullDocumentDiagnosticReportRelatedDocumentsValueConverter))]
    [DataContract]
    public record RelatedFullDocumentDiagnosticReportRelatedDocumentsValue: OrType<FullDocumentDiagnosticReport, UnchangedDocumentDiagnosticReport>
    {
        public RelatedFullDocumentDiagnosticReportRelatedDocumentsValue(FullDocumentDiagnosticReport FullDocumentDiagnosticReport): base(FullDocumentDiagnosticReport) {}
        public RelatedFullDocumentDiagnosticReportRelatedDocumentsValue(UnchangedDocumentDiagnosticReport UnchangedDocumentDiagnosticReport): base(UnchangedDocumentDiagnosticReport) {}
    }

}
