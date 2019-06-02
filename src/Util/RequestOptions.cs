namespace OpenWeatherMap.Util
{
    using System.Threading;

    /// <summary>
    ///     Request options for <see cref="OpenWeatherMapService"/>.
    /// </summary>
    public sealed class RequestOptions
    {
        /// <summary>
        ///     Gets the default request options (can be changed to change the default behavior, note
        ///     that other services behavior may change).
        /// </summary>
        public static RequestOptions Default { get; } = new RequestOptions();

        /// <summary>
        ///     Gets or sets the caching mode to use when requesting.
        /// </summary>
        public CacheMode CacheMode { get; set; } = CacheMode.Default;

        /// <summary>
        ///     A cancellation token used to propagate notification that the request should be canceled.
        /// </summary>
        public CancellationToken CancellationToken { get; set; }

        /// <summary>
        ///     Gets or sets the response language.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        ///     Gets or sets the unit for the response units.
        /// </summary>
        public UnitType Unit { get; set; }
    }
}