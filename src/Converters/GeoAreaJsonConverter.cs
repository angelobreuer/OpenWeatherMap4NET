namespace OpenWeatherMap.Converters
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using OpenWeatherMap.Triggers.Area;

    internal sealed class GeoAreaJsonConverter : JsonConverter
    {
        /// <inheritdoc/>
        public override bool CanWrite => false;

        /// <inheritdoc/>
        public override bool CanConvert(Type objectType) => true;

        /// <inheritdoc/>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var data = JObject.Load(reader);
            var type = data["type"].ToObject<GeoAreaType>(serializer);
            var area = FromType(type);

            using (var tokenReader = data.CreateReader())
            {
                serializer.Populate(tokenReader, area);
            }

            return area;
        }

        /// <inheritdoc/>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        private static IGeoArea FromType(GeoAreaType type)
        {
            switch (type)
            {
                case GeoAreaType.Point: return new Point();
                case GeoAreaType.MultiPoint: return new MultiPoint();
                case GeoAreaType.Polygon: return new Polygon();
                case GeoAreaType.MultiPolygon: return new MultiPolygon();
            }

            throw new ArgumentOutOfRangeException(nameof(type), type,
                "The specified type is not defined in the GeoAreaType enumeration.");
        }
    }
}