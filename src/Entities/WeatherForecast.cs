namespace OpenWeatherMap.Entities
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using OpenWeatherMap.Entities;

    /// <summary>
    ///     Represents the response object of a weather forecast request.
    /// </summary>
    public sealed class WeatherForecast
    {
        /// <summary>
        ///     The list of available weather forecasts.
        /// </summary>
        [JsonRequired, JsonProperty("list")]
        public IReadOnlyCollection<WeatherForecastItem> List { get; internal set; }
    }
}