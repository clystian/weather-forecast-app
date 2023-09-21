using System.Text.Json;
using System.Text.Json.Serialization;

internal class TemperatureUnitConverter : JsonConverter<TemperatureUnit>
    {
        public override bool CanConvert(Type t) => t == typeof(TemperatureUnit);

        public override TemperatureUnit Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            if (value == "F")
            {
                return TemperatureUnit.F;
            }
            throw new Exception("Cannot unmarshal type TemperatureUnit");
        }

        public override void Write(Utf8JsonWriter writer, TemperatureUnit value, JsonSerializerOptions options)
        {
            if (value == TemperatureUnit.F)
            {
                JsonSerializer.Serialize(writer, "F", options);
                return;
            }
            throw new Exception("Cannot marshal type TemperatureUnit");
        }

        public static readonly TemperatureUnitConverter Singleton = new TemperatureUnitConverter();
    }
    