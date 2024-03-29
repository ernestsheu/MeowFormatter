// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;

namespace Microsoft.LanguageServer.Protocol {
    public class WorkspaceDocumentDiagnosticReportConverter : JsonConverter<WorkspaceDocumentDiagnosticReport>
    {
    private OrTypeConverter<WorkspaceFullDocumentDiagnosticReport,WorkspaceUnchangedDocumentDiagnosticReport> _orType;
    public WorkspaceDocumentDiagnosticReportConverter()
    {
    _orType = new OrTypeConverter<WorkspaceFullDocumentDiagnosticReport,WorkspaceUnchangedDocumentDiagnosticReport>();
    }
    public override WorkspaceDocumentDiagnosticReport? ReadJson(JsonReader reader, Type objectType, WorkspaceDocumentDiagnosticReport? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
    reader = reader ?? throw new ArgumentNullException(nameof(reader));
    if (reader.TokenType == JsonToken.Null) { return null; }
    var o = _orType.ReadJson(reader, objectType, existingValue, serializer);
    if (o is OrType<WorkspaceFullDocumentDiagnosticReport,WorkspaceUnchangedDocumentDiagnosticReport> orType)
    {
    if (orType.Value?.GetType() == typeof(WorkspaceFullDocumentDiagnosticReport))
    {
    return new WorkspaceDocumentDiagnosticReport((WorkspaceFullDocumentDiagnosticReport)orType.Value);
    }
    if (orType.Value?.GetType() == typeof(WorkspaceUnchangedDocumentDiagnosticReport))
    {
    return new WorkspaceDocumentDiagnosticReport((WorkspaceUnchangedDocumentDiagnosticReport)orType.Value);
    }
    }
    throw new JsonSerializationException($"Unexpected token type.");
    }
    public override void WriteJson(JsonWriter writer, WorkspaceDocumentDiagnosticReport? value, JsonSerializer serializer)
    {
    _orType.WriteJson(writer, value, serializer);
    }
    }
}
