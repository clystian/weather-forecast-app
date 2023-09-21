using System.Text.Json;
using System.Text.Json.Serialization;

internal class UnitCodeConverter : JsonConverter<UnitCode>
    {
        public override bool CanConvert(Type t) => t == typeof(UnitCode);

        public override UnitCode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            switch (value)
            {
                case "wmoUnit:degC":
                    return UnitCode.WmoUnitDegC;
                case "wmoUnit:m":
                    return UnitCode.WmoUnitM;
                case "wmoUnit:percent":
                    return UnitCode.WmoUnitPercent;
            }
            throw new Exception("Cannot unmarshal type UnitCode");
        }

        public override void Write(Utf8JsonWriter writer, UnitCode value, JsonSerializerOptions options)
        {
            switch (value)
            {
                case UnitCode.WmoUnitDegC:
                    JsonSerializer.Serialize(writer, "wmoUnit:degC", options);
                    return;
                case UnitCode.WmoUnitM:
                    JsonSerializer.Serialize(writer, "wmoUnit:m", options);
                    return;
                case UnitCode.WmoUnitPercent:
                    JsonSerializer.Serialize(writer, "wmoUnit:percent", options);
                    return;
            }
            throw new Exception("Cannot marshal type UnitCode");
        }

        public static readonly UnitCodeConverter Singleton = new UnitCodeConverter();
    }
    