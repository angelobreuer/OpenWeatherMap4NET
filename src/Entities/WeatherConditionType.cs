namespace OpenWeatherMap.Entities
{
    /// <summary>
    ///     The different weather condition types.
    /// </summary>
    public enum WeatherConditionType : byte
    {
        /// <summary>
        ///     Thunderstorm weather condition
        /// </summary>
        Thunderstorm,

        /// <summary>
        ///     Drizzle weather condition
        /// </summary>
        Drizzle,

        /// <summary>
        ///     Rain weather condition
        /// </summary>
        Rain,

        /// <summary>
        ///     Snow weather condition
        /// </summary>
        Snow,

        /// <summary>
        ///     Atmosphere weather condition
        /// </summary>
        Atmosphere,

        /// <summary>
        ///     Clear weather condition
        /// </summary>
        Clear,

        /// <summary>
        ///     Clouds weather condition
        /// </summary>
        Clouds,

        /// <summary>
        ///     Haze weather condition
        /// </summary>
        Haze,

        /// <summary>
        ///     Mist weather condition
        /// </summary>
        Mist
    }
}