namespace OpenWeatherMap.Entities
{
    /// <summary>
    ///     Represents a weather zone.
    /// </summary>
    public sealed class WeatherZone
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="WeatherZone"/> class.
        /// </summary>
        /// <param name="longitudeLeft">the left longitude</param>
        /// <param name="latitudeBottom">the bottom latitude</param>
        /// <param name="longitudeRight">the right longitude</param>
        /// <param name="latitudeTop">the top latitude</param>
        /// <param name="zoom">the zone zoom</param>
        public WeatherZone(int longitudeLeft, int latitudeBottom, int longitudeRight, int latitudeTop, int zoom)
        {
            LatitudeBottom = latitudeBottom;
            LatitudeTop = latitudeTop;
            LongitudeLeft = longitudeLeft;
            LongitudeRight = longitudeRight;
            Zoom = zoom;
        }

        /// <summary>
        ///     Gets the bottom latitude.
        /// </summary>
        /// <value>the bottom latitude.</value>
        public int LatitudeBottom { get; }

        /// <summary>
        ///     Gets the top latitude.
        /// </summary>
        /// <value>the top latitude.</value>
        public int LatitudeTop { get; }

        /// <summary>
        ///     Gets the left longitude.
        /// </summary>
        /// <value>the left longitude.</value>
        public int LongitudeLeft { get; }

        /// <summary>
        ///     Gets the right longitude.
        /// </summary>
        /// <value>the right longitude.</value>
        public int LongitudeRight { get; }

        /// <summary>
        ///     Gets the rectangle zoom.
        /// </summary>
        /// <value>the rectangle zoom.</value>
        public int Zoom { get; }

        /// <summary>
        ///     Creates the zone string in format: "{LongitudeLeft},{LatitudeBottom},{LongitudeRight},{LatitudeTop},{Zoom}".
        /// </summary>
        /// <returns>the zone string</returns>
        public string ToZoneString() => $"{LongitudeLeft},{LatitudeBottom},{LongitudeRight},{LatitudeTop},{Zoom}";
    }
}
