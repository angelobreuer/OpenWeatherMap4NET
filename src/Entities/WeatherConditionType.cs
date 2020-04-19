namespace OpenWeatherMap.Entities
{
    /// <summary>
    ///     The different weather condition types.
    /// </summary>
    /// <remarks>https://openweathermap.org/weather-conditions</remarks>
    public enum WeatherConditionType : byte
    {
        /// <summary>
        ///     Denotes that the weather condition type is <c>"Ash"</c>.
        /// </summary>
        Ash,

        /// <summary>
        ///     Denotes that the weather condition type is <c>"Clear"</c>.
        /// </summary>
        Clear,

        /// <summary>
        ///     Denotes that the weather condition type is <c>"Clouds"</c>.
        /// </summary>
        Clouds,

        /// <summary>
        ///     Denotes that the weather condition type is <c>"Drizzle"</c>.
        /// </summary>
        Drizzle,

        /// <summary>
        ///     Denotes that the weather condition type is <c>"Dust"</c>.
        /// </summary>
        Dust,

        /// <summary>
        ///     Denotes that the weather condition type is <c>"Fog"</c>.
        /// </summary>
        Fog,

        /// <summary>
        ///     Denotes that the weather condition type is <c>"Haze"</c>.
        /// </summary>
        Haze,

        /// <summary>
        ///     Denotes that the weather condition type is <c>"Mist"</c>.
        /// </summary>
        Mist,

        /// <summary>
        ///     Denotes that the weather condition type is <c>"Rain"</c>.
        /// </summary>
        Rain,

        /// <summary>
        ///     Denotes that the weather condition type is <c>"Sand"</c>.
        /// </summary>
        Sand,

        /// <summary>
        ///     Denotes that the weather condition type is <c>"Smoke"</c>.
        /// </summary>
        Smoke,

        /// <summary>
        ///     Denotes that the weather condition type is <c>"Snow"</c>.
        /// </summary>
        Snow,

        /// <summary>
        ///     Denotes that the weather condition type is <c>"Squall"</c>.
        /// </summary>
        Squall,

        /// <summary>
        ///     Denotes that the weather condition type is <c>"Thunderstorm"</c>.
        /// </summary>
        Thunderstorm,

        /// <summary>
        ///     Denotes that the weather condition type is <c>"Tornado"</c>.
        /// </summary>
        Tornado
    }
}