namespace OpenWeatherMap.Entities
{
    using System;
    using Newtonsoft.Json;
    using OpenWeatherMap.Util;

    /// <summary>
    ///     The item in a <see cref="WeatherForecast"/>.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public sealed class WeatherForecastItem
    {
        /// <summary>
        ///     The calculation time needed.
        /// </summary>
        [JsonProperty("dt"), JsonConverter(typeof(UnixTimeConverter))]
        public DateTimeOffset? CalculationTime { get; internal set; }

        /// <summary>
        ///     Gets the additional clouds information.
        /// </summary>
        [JsonProperty("clouds")]
        public CloudsInformation Clouds { get; internal set; }

        /// <summary>
        ///     Gets the additional rain information.
        /// </summary>
        [JsonProperty("rain")]
        public RainInformation Rain { get; internal set; }

        /// <summary>
        ///     Gets the temperature information.
        /// </summary>
        [JsonRequired, JsonProperty("main")]
        public TemperatureInfo Temperature { get; internal set; }

        /// <summary>
        ///     Gets the weather information.
        /// </summary>
        [JsonRequired, JsonProperty("weather")]
        public WeatherCondition[] WeatherConditions { get; internal set; }

        /// <summary>
        ///     Gets the additional wind information.
        /// </summary>
        [JsonProperty("wind")]
        public WindInformation Wind { get; internal set; }
    }
}