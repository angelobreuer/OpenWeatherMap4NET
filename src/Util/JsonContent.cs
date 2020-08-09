namespace OpenWeatherMap.Util
{
    using System.Net.Http;
    using System.Text;

    /// <summary>
    ///     Represents JSON content.
    /// </summary>
    public sealed class JsonContent : StringContent
    {
        /// <summary>
        ///     The media type for the HTTP content.
        /// </summary>
        public const string MediaType = "application/json";

        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonContent"/> class.
        /// </summary>
        /// <param name="content">the JSON content</param>
        public JsonContent(string content) : this(content, Encoding.UTF8)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonContent"/> class.
        /// </summary>
        /// <param name="content">the JSON content</param>
        /// <param name="encoding">the encoding</param>
        public JsonContent(string content, Encoding encoding) : base(content, encoding, MediaType)
        {
        }
    }
}
