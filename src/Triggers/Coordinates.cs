namespace OpenWeatherMap.Triggers
{
    using System;
    using Newtonsoft.Json;
    using OpenWeatherMap.Converters;

    [JsonConverter(typeof(CoordinatesArrayJsonConverter))]
    public readonly struct Coordinates
    {
        public Coordinates(int[] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length != 2)
            {
                throw new InvalidOperationException("Expected exactly 2 coordinates in array.");
            }

            Longitude = array[0];
            Latitude = array[1];
        }

        [JsonConstructor]
        public Coordinates([JsonProperty("lon")] int longitude, [JsonProperty("lat")] int latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }

        public int Latitude { get; }

        public int Longitude { get; }

        public int[] AsArray() => new[] { Longitude, Latitude };
    }
}