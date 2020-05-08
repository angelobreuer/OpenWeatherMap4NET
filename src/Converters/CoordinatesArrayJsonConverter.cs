namespace OpenWeatherMap.Converters
{
    using System;
    using Newtonsoft.Json;
    using OpenWeatherMap.Triggers;

    internal sealed class CoordinatesArrayJsonConverter : JsonConverter
    {
        /// <inheritdoc/>
        public override bool CanConvert(Type objectType) => true;

        /// <inheritdoc/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var coordinates = serializer.Deserialize<int[]>(reader);
            return new Coordinates(coordinates);
        }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((Coordinates)value).AsArray());
        }
    }
}