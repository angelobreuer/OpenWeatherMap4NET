namespace OpenWeatherMap.Entities
{
    using Newtonsoft.Json;

    /// <summary>
    ///     The strongly-typed representation of a JSON-object providing temperature info from a
    ///     specific weather station.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class TemperatureInfo
    {
        /// <summary>
        ///     Gets the temperature.
        /// </summary>
        [JsonRequired, JsonProperty("temp")]
        public double Value { get; internal set; }

        /// <summary>
        ///     Gets the pressure.
        /// </summary>
        [JsonRequired, JsonProperty("pressure")]
        public double Pressure { get; internal set; }

        /// <summary>
        ///     Gets the humidity.
        /// </summary>
        [JsonRequired, JsonProperty("humidity")]
        public double Humidity { get; internal set; }

        /// <summary>
        ///     Gets the minimum temperature.
        /// </summary>
        [JsonProperty("temp_min")]
        public double? MinimumTemperature { get; internal set; }

        /// <summary>
        ///     Gets the maximum temperature.
        /// </summary>
        [JsonProperty("temp_max")]
        public double? MaximumTemperature { get; internal set; }

        /// <summary>
        ///     Gets the atmospheric pressure on the sea level (in hPa).
        /// </summary>
        [JsonProperty("sea_level")]
        public double? SeaLevel { get; internal set; }

        /// <summary>
        ///     Gets the atmospheric pressure on the ground level (in hPa).
        /// </summary>
        [JsonProperty("grnd_level")]
        public double? GroundLevel { get; internal set; }

        /// <summary>
        ///     Builds a string representation of the object.
        /// </summary>
        /// <returns>the string representation</returns>
        public override string ToString() => $"temp: {Value}, min: {MinimumTemperature}, max: {MaximumTemperature}," +
            $" hum: {Humidity}%, press: {Pressure}, hPsea: {SeaLevel}, hPgrnd: {GroundLevel}";
    }
}