namespace OpenWeatherMap.Entities
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using OpenWeatherMap.Util;

    /// <summary>
    ///     The item in a <see cref="WeatherForecast"/>.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class WeatherForecastItem
    {
        /// <summary>
        ///     Gets the calculation time needed.
        /// </summary>
        /// <value>the calculation time needed.</value>
        [JsonProperty("dt"), JsonConverter(typeof(UnixTimeConverter))]
        public DateTimeOffset? CalculationTime { get; internal set; }

        /// <summary>
        ///     Gets additional clouds information.
        /// </summary>
        /// <value>additional clouds information.</value>
        [JsonProperty("clouds")]
        public CloudsInformation? Clouds { get; internal set; }

        /// <summary>
        ///     Gets additional rain information.
        /// </summary>
        /// <value>additional rain information.</value>
        [JsonProperty("rain")]
        public RainInformation? Rain { get; internal set; }

        /// <summary>
        ///     Gets the temperature information.
        /// </summary>
        /// <value>the temperature information.</value>
        [JsonRequired, JsonProperty("main")]
        public TemperatureInfo? Temperature { get; internal set; }

        /// <summary>
        ///     Gets a read-only list containing information about the weather conditions.
        /// </summary>
        /// <value>a read-only list containing information about the weather conditions.</value>
        [JsonRequired, JsonProperty("weather")]
        public IReadOnlyList<WeatherCondition> WeatherConditions { get; internal set; } = Array.Empty<WeatherCondition>();

        /// <summary>
        ///     Gets additional wind information.
        /// </summary>
        /// <value>additional wind information.</value>
        [JsonProperty("wind")]
        public WindInformation? Wind { get; internal set; }
    }
}
