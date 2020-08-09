namespace OpenWeatherMap.Util
{
    using System;
    using Newtonsoft.Json;

    internal sealed class UnixTimeConverter : JsonConverter<DateTimeOffset>
    {
        /// <inheritdoc/>
        public override DateTimeOffset ReadJson(JsonReader reader, Type objectType, DateTimeOffset existingValue, bool hasExistingValue, JsonSerializer serializer)
            => DateTimeOffset.FromUnixTimeSeconds((long)reader.Value);

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, DateTimeOffset value, JsonSerializer serializer)
            => writer.WriteValue(value.ToUnixTimeSeconds());
    }
}
