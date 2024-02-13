// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// 
// THIS FILE IS AUTOGENERATED, DO NOT MODIFY IT

using Newtonsoft.Json;

namespace Microsoft.LanguageServer.Protocol {
    public class InlineValueConverter : JsonConverter<InlineValue>
    {
    private OrTypeConverter<InlineValueText,InlineValueVariableLookup,InlineValueEvaluatableExpression> _orType;
    public InlineValueConverter()
    {
    _orType = new OrTypeConverter<InlineValueText,InlineValueVariableLookup,InlineValueEvaluatableExpression>();
    }
    public override InlineValue? ReadJson(JsonReader reader, Type objectType, InlineValue? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
    reader = reader ?? throw new ArgumentNullException(nameof(reader));
    if (reader.TokenType == JsonToken.Null) { return null; }
    var o = _orType.ReadJson(reader, objectType, existingValue, serializer);
    if (o is OrType<InlineValueText,InlineValueVariableLookup,InlineValueEvaluatableExpression> orType)
    {
    if (orType.Value?.GetType() == typeof(InlineValueText))
    {
    return new InlineValue((InlineValueText)orType.Value);
    }
    if (orType.Value?.GetType() == typeof(InlineValueVariableLookup))
    {
    return new InlineValue((InlineValueVariableLookup)orType.Value);
    }
    if (orType.Value?.GetType() == typeof(InlineValueEvaluatableExpression))
    {
    return new InlineValue((InlineValueEvaluatableExpression)orType.Value);
    }
    }
    throw new JsonSerializationException($"Unexpected token type.");
    }
    public override void WriteJson(JsonWriter writer, InlineValue? value, JsonSerializer serializer)
    {
    _orType.WriteJson(writer, value, serializer);
    }
    }
}