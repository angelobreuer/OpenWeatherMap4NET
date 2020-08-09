namespace OpenWeatherMap.Util
{
    using System.Threading;

    /// <summary>
    ///     Request options for <see cref="OpenWeatherMapService"/>.
    /// </summary>
    public sealed class RequestOptions
    {
        /// <summary>
        ///     Gets the default request options (can be changed to change the default behavior,
        ///     note that other services behavior may change).
        /// </summary>
        /// <value>
        ///     the default request options (can be changed to change the default behavior, note
        ///     that other services behavior may change).
        /// </value>
        public static RequestOptions Default { get; } = new RequestOptions();

        /// <summary>
        ///     Gets or sets the caching mode to use when requesting.
        /// </summary>
        /// <value>the caching mode to use when requesting.</value>
        public CacheMode CacheMode { get; set; } = CacheMode.Default;

        /// <summary>
        ///     Gets or sets a cancellation token used to propagate notification that the request
        ///     should be canceled.
        /// </summary>
        /// <value>
        ///     a cancellation token used to propagate notification that the request should be canceled.
        /// </value>
        public CancellationToken CancellationToken { get; set; }

        /// <summary>
        ///     Gets or sets the response language; or <see langword="null"/> to use the default language.
        /// </summary>
        /// <value>the response language; or <see langword="null"/> to use the default language.</value>
        public string? Language { get; set; }

        /// <summary>
        ///     Gets or sets the unit for the response units.
        /// </summary>
        /// <value>the unit for the response units.</value>
        public UnitType Unit { get; set; }
    }
}
