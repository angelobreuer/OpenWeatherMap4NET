namespace OpenWeatherMap.Util
{
    /// <summary>
    ///     A set of different unit types supported by OpenWeatherMap.
    /// </summary>
    public enum UnitType
    {
        /// <summary>
        ///     When specified temperature is returned in Kelvin and speeds are returned in meter per
        ///     second (meter/sec).
        /// </summary>
        Default,

        /// <summary>
        ///     When specified temperature is returned in Celsius and speeds are returned in meter
        ///     per second (meter/sec).
        /// </summary>
        Metric,

        /// <summary>
        ///     When specified temperature is returned in Fahrenheit and speeds are returned in miles
        ///     per hour (miles/hour).
        /// </summary>
        Imperial
    }
}