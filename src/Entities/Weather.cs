namespace OpenWeatherMap.Entities
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using OpenWeatherMap.Util;

    /// <summary>
    ///     The weather response object.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Weather
    {
        /// <summary>
        ///     Gets additional information about the weather.
        /// </summary>
        /// <value>additional information about the weather.</value>
        [JsonProperty("sys")]
        public AdditionalWeatherInformation? AdditionalInformation { get; internal set; }

        /// <summary>
        ///     Gets the calculation time needed.
        /// </summary>
        /// <value>the calculation time needed.</value>
        [JsonProperty("dt"), JsonConverter(typeof(UnixTimeConverter))]
        public DateTimeOffset? CalculationTime { get; internal set; }

        /// <summary>
        ///     Gets the additional clouds information.
        /// </summary>
        /// <value>the additional clouds information.</value>
        [JsonProperty("clouds")]
        public CloudsInformation? Clouds { get; internal set; }

        /// <summary>
        ///     Gets the coordinates of the city.
        /// </summary>
        /// <value>the coordinates of the city.</value>
        [JsonProperty("coord")]
        public WeatherCoordinates? Coordinates { get; internal set; }

        /// <summary>
        ///     Gets the city id.
        /// </summary>
        /// <value>the city id.</value>
        [JsonRequired, JsonProperty("id")]
        public int Id { get; internal set; }

        /// <summary>
        ///     Gets the name of the city.
        /// </summary>
        /// <value>the name of the city.</value>
        [JsonRequired, JsonProperty("name")]
        public string Name { get; internal set; } = null!;

        /// <summary>
        ///     Gets the additional rain information.
        /// </summary>
        /// <value>the additional rain information.</value>
        [JsonProperty("rain")]
        public RainInformation? Rain { get; internal set; }

        /// <summary>
        ///     Gets the temperature information.
        /// </summary>
        /// <value>the temperature information.</value>
        [JsonRequired, JsonProperty("main")]
        public TemperatureInfo? Temperature { get; internal set; }

        /// <summary>
        ///     Gets the weather information.
        /// </summary>
        /// <value>the weather information.</value>
        [JsonRequired, JsonProperty("weather")]
        public IReadOnlyList<WeatherCondition> WeatherConditions { get; internal set; } = null!;

        /// <summary>
        ///     Gets the additional wind information.
        /// </summary>
        /// <value>the additional wind information.</value>
        [JsonProperty("wind")]
        public WindInformation Wind { get; internal set; } = null!;
    }
}
