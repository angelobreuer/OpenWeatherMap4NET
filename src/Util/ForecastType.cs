namespace OpenWeatherMap.Util
{
    /// <summary>
    ///     Supported forecast types.
    /// </summary>
    public enum ForecastType
    {
        /// <summary>
        ///     Hourly forecast for four days.
        /// </summary>
        Hourly,

        /// <summary>
        ///     Three hour forecast for five days.
        /// </summary>
        ThreeHour,

        /// <summary>
        ///     Daily weather forecast for 16 days.
        /// </summary>
        Daily
    }
}