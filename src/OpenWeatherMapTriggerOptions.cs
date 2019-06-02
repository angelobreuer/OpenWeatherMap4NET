namespace OpenWeatherMap
{
    using System;

    public class OpenWeatherMapTriggerOptions : OpenWeatherMapOptions
    {
        public TimeSpan PollInterval { get; internal set; } = TimeSpan.FromMinutes(2);
    }
}