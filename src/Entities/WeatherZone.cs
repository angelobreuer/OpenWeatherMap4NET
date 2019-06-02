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
        /// <param name="longitudeRight">t</param>
        /// <param name="latitudeTop">t</param>
        /// <param name="zoom"></param>
        public WeatherZone(int longitudeLeft, int latitudeBottom, int longitudeRight, int latitudeTop, int zoom)
        {
            LatitudeBottom = latitudeBottom;
            LatitudeTop = latitudeTop;
            LongitudeLeft = longitudeLeft;
            LongitudeRight = longitudeRight;
            Zoom = zoom;
        }

        /// <summary>
        ///     The bottom latitude.
        /// </summary>
        public int LatitudeBottom { get; }

        /// <summary>
        ///     The top latitude.
        /// </summary>
        public int LatitudeTop { get; }

        /// <summary>
        ///     The left longitude.
        /// </summary>
        public int LongitudeLeft { get; }

        /// <summary>
        ///     The right longitude.
        /// </summary>
        public int LongitudeRight { get; }

        /// <summary>
        ///     The rectangle zoom.
        /// </summary>
        public int Zoom { get; }

        /// <summary>
        ///     Creates the zone string in format: "{LongitudeLeft},{LatitudeBottom},{LongitudeRight},{LatitudeTop},{Zoom}".
        /// </summary>
        /// <returns>the zone string</returns>
        public string ToZoneString() => $"{LongitudeLeft},{LatitudeBottom},{LongitudeRight},{LatitudeTop},{Zoom}";
    }
}