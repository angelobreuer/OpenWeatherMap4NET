namespace OpenWeatherMap.Entities
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    ///     Represents the response object of a weather forecast request.
    /// </summary>
    public sealed class WeatherForecast
    {
        /// <summary>
        ///     Gets a read-only list of available weather forecasts.
        /// </summary>
        /// <value>a read-only list of available weather forecasts.</value>
        [JsonRequired, JsonProperty("list")]
        public IReadOnlyCollection<WeatherForecastItem> List { get; internal set; } = Array.Empty<WeatherForecastItem>();
    }
}
