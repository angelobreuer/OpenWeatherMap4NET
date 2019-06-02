namespace OpenWeatherMap.Util
{
    using System.Net.Http;
    using System.Text;

    public sealed class JsonContent : StringContent
    {
        public const string MediaType = "application/json";

        public JsonContent(string content) : this(content, Encoding.UTF8)
        {
        }

        public JsonContent(string content, Encoding encoding) : base(content, encoding, MediaType)
        {
        }
    }
}