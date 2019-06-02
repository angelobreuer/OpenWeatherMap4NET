namespace OpenWeatherMap
{
    using System;

    /// <summary>
    ///     Options for the <see cref="OpenWeatherMapService"/>.
    /// </summary>
    public class OpenWeatherMapOptions
    {
        /// <summary>
        ///     Gets or sets the RESTful api key (required).
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        ///     Gets or sets the base address for the RESTful api service (required).
        /// </summary>
        public Uri BaseAddress { get; set; } = new Uri("https://api.openweathermap.org/data/");

        /// <summary>
        ///     Validates the open weather map options.
        /// </summary>
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(ApiKey))
            {
                throw new InvalidOperationException("No api key specified.");
            }

            if (BaseAddress == null)
            {
                throw new InvalidOperationException("No base address specified.");
            }
        }
    }
}