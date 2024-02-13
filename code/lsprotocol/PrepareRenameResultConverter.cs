// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;

namespace Microsoft.LanguageServer.Protocol {
    public class PrepareRenameResultConverter : JsonConverter<PrepareRenameResult>
    {
    private OrTypeConverter<Range,PrepareRenamePlaceholder,PrepareRenameDefaultBehavior> _orType;
    public PrepareRenameResultConverter()
    {
    _orType = new OrTypeConverter<Range,PrepareRenamePlaceholder,PrepareRenameDefaultBehavior>();
    }
    public override PrepareRenameResult? ReadJson(JsonReader reader, Type objectType, PrepareRenameResult? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
    reader = reader ?? throw new ArgumentNullException(nameof(reader));
    if (reader.TokenType == JsonToken.Null) { return null; }
    var o = _orType.ReadJson(reader, objectType, existingValue, serializer);
    if (o is OrType<Range,PrepareRenamePlaceholder,PrepareRenameDefaultBehavior> orType)
    {
    if (orType.Value?.GetType() == typeof(Range))
    {
    return new PrepareRenameResult((Range)orType.Value);
    }
    if (orType.Value?.GetType() == typeof(PrepareRenamePlaceholder))
    {
    return new PrepareRenameResult((PrepareRenamePlaceholder)orType.Value);
    }
    if (orType.Value?.GetType() == typeof(PrepareRenameDefaultBehavior))
    {
    return new PrepareRenameResult((PrepareRenameDefaultBehavior)orType.Value);
    }
    }
    throw new JsonSerializationException($"Unexpected token type.");
    }
    public override void WriteJson(JsonWriter writer, PrepareRenameResult? value, JsonSerializer serializer)
    {
    _orType.WriteJson(writer, value, serializer);
    }
    }
}