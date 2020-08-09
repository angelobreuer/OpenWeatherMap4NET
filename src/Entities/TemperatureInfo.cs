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
        ///     Gets the human perception of weather.
        /// </summary>
        /// <value>the human perception of weather.</value>
        [JsonRequired, JsonProperty("feels_like")]
        public double FeelsLike { get; internal set; }

        /// <summary>
        ///     Gets the atmospheric pressure on the ground level (in hPa).
        /// </summary>
        /// <value>the atmospheric pressure on the ground level (in hPa).</value>
        [JsonProperty("grnd_level")]
        public double? GroundLevel { get; internal set; }

        /// <summary>
        ///     Gets the air humidity.
        /// </summary>
        /// <value>the air humidity.</value>
        [JsonRequired, JsonProperty("humidity")]
        public double Humidity { get; internal set; }

        /// <summary>
        ///     Gets the maximum temperature.
        /// </summary>
        /// <value>the maximum temperature.</value>
        [JsonProperty("temp_max")]
        public double? MaximumTemperature { get; internal set; }

        /// <summary>
        ///     Gets the minimum temperature.
        /// </summary>
        /// <value>the minimum temperature.</value>
        [JsonProperty("temp_min")]
        public double? MinimumTemperature { get; internal set; }

        /// <summary>
        ///     Gets the air pressure.
        /// </summary>
        /// <value>the air pressure.</value>
        [JsonRequired, JsonProperty("pressure")]
        public double Pressure { get; internal set; }

        /// <summary>
        ///     Gets the atmospheric pressure on the sea level (in hPa).
        /// </summary>
        /// <value>the atmospheric pressure on the sea level (in hPa).</value>
        [JsonProperty("sea_level")]
        public double? SeaLevel { get; internal set; }

        /// <summary>
        ///     Gets the temperature.
        /// </summary>
        /// <value>the temperature.</value>
        [JsonRequired, JsonProperty("temp")]
        public double Value { get; internal set; }

        /// <summary>
        ///     Builds a <see cref="string"/> representation of the object.
        /// </summary>
        /// <returns>the <see cref="string"/> representation</returns>
        public override string ToString() => $"temp: {Value}, realFeel: {FeelsLike}, min: {MinimumTemperature}, max: {MaximumTemperature}," +
            $" hum: {Humidity}%, press: {Pressure}, hPsea: {SeaLevel}, hPgrnd: {GroundLevel}";
    }
}
