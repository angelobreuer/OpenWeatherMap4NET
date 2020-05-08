namespace OpenWeatherMap.Util
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    ///     Represents a HTTP content which holds JSON-encoded data.
    /// </summary>
    public sealed class JsonContent : HttpContent
    {
        /// <summary>
        ///     The media type for JSON-encoded HTTP content ("application/json").
        /// </summary>
        public const string MediaType = "application/json";

        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonContent"/> class.
        /// </summary>
        /// <param name="value">the JSON object to write</param>
        /// <param name="encoding">
        ///     the encoding to use when writing the JSON data; or <see langword="null"/> to use
        ///     <see cref="Encoding.UTF8"/>
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     thrown if the specified <paramref name="value"/> is <see langword="null"/>.
        /// </exception>
        public JsonContent(object value, Encoding encoding = null) : this(JToken.FromObject(value), encoding)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="JsonContent"/> class.
        /// </summary>
        /// <param name="token">the JSON token to write</param>
        /// <param name="encoding">
        ///     the encoding to use when writing the JSON data; or <see langword="null"/> to use
        ///     <see cref="Encoding.UTF8"/>
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     thrown if the specified <paramref name="token"/> is <see langword="null"/>.
        /// </exception>
        public JsonContent(JToken token, Encoding encoding = null)
        {
            Token = token ?? throw new ArgumentNullException(nameof(token));
            Encoding = encoding ?? Encoding.UTF8;
            Headers.ContentType = new MediaTypeHeaderValue(MediaType);
        }

        /// <summary>
        ///     Gets the encoding to use when writing the JSON data.
        /// </summary>
        /// <value>the encoding to use when writing the JSON data</value>
        public Encoding Encoding { get; }

        /// <summary>
        ///     Gets the JSON token to write.
        /// </summary>
        /// <value>the JSON token to write</value>
        public JToken Token { get; }

        /// <inheritdoc/>
        protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            using (var streamWriter = new StreamWriter(stream, Encoding, 4096, leaveOpen: true))
            using (var jsonTextWriter = new JsonTextWriter(streamWriter))
            {
                await Token.WriteToAsync(jsonTextWriter);
            }
        }

        /// <inheritdoc/>
        protected override bool TryComputeLength(out long length)
        {
            length = default;
            return false;
        }
    }
}