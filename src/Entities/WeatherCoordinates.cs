namespace OpenWeatherMap.Entities
{
    using System.Globalization;
    using Newtonsoft.Json;

    /// <summary>
    ///     Represents coordinates.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class WeatherCoordinates
    {
        /// <summary>
        ///     Gets the latitude degree.
        /// </summary>
        [JsonRequired, JsonProperty("lat")]
        public double Latitude { get; internal set; }

        /// <summary>
        ///     Gets the longitude degree.
        /// </summary>
        [JsonRequired, JsonProperty("lon")]
        public double Longitude { get; internal set; }

        /// <summary>
        ///     Builds a string representation of the object.
        /// </summary>
        /// <returns>the string representation</returns>
        public override string ToString() => $"lat: {Latitude.ToString(CultureInfo.InvariantCulture)}, lon: {Longitude.ToString(CultureInfo.InvariantCulture)}";
    }
}