﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TradeZeroApp;

/// <summary>
/// This converter reads non-string tokens as strings.
/// </summary>
public class StringJsonConverter : JsonConverter<string>
{
	public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		switch (reader.TokenType)
		{
			case JsonTokenType.Number:
				var stringValue = reader.GetInt32();
				return stringValue.ToString(CultureInfo.InvariantCulture);

			case JsonTokenType.String:
				return reader.GetString();

			default:
				throw new JsonException($"The token type {reader.TokenType} is not supported by {nameof(StringJsonConverter)}.");
		}
	}

	public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
	{
		writer.WriteStringValue(value);
	}
}
