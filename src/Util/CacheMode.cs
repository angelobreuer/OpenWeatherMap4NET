namespace OpenWeatherMap.Util
{
    /// <summary>
    ///     A set of supported caching modes.
    /// </summary>
    public enum CacheMode
    {
        /// <summary>
        ///     Allows caching and downloading.
        /// </summary>
        AllowDownload,

        /// <summary>
        ///     Does not try to get the request from the cache, this will always try to download the
        ///     resource even if it is in cache.
        /// </summary>
        Download,

        /// <summary>
        ///     Throws an exception if the requested resource is not cached.
        /// </summary>
        CacheOnly,

        /// <summary>
        ///     The default <see cref="CacheMode"/>.
        /// </summary>
        Default = AllowDownload
    }
}