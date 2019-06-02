namespace OpenWeatherMap
{
    using System;
    using System.Collections.Specialized;
    using System.Net.Http;
    using System.Runtime.Caching;
    using System.Threading.Tasks;
    using System.Web;
    using System.Linq;
    using Newtonsoft.Json;
    using OpenWeatherMap.Entities;
    using OpenWeatherMap.Util;
    using System.Collections.Generic;
    using System.Text;
    using System.Globalization;
    using System.Net;

    /// <summary>
    ///     The service for getting weather information.
    /// </summary>
    public class OpenWeatherMapService : IDisposable
    {
        private static readonly DateTimeOffset _uvHistoryStartTime
            = new DateTimeOffset(2017, 6, 22, 0, 0, 0, TimeSpan.Zero);

        private readonly MemoryCache _cache;
        private readonly HttpClient _httpClient;
        private readonly OpenWeatherMapOptions _options;

        /// <summary>
        ///     Initializes a new instance of the <see cref="OpenWeatherMapService"/> class.
        /// </summary>
        /// <param name="options">the open weather map options (api key, etc.)</param>
        public OpenWeatherMapService(OpenWeatherMapOptions options)
        {
            _cache = new MemoryCache("openweathermap");
            _httpClient = new HttpClient();

            _options = options ?? throw new ArgumentNullException(nameof(options));
            _options.Validate();
        }

        /// <summary>
        ///     Disposes the underlying HTTP client and clears the request cache.
        /// </summary>
        public virtual void Dispose()
        {
            _httpClient.Dispose();
            _cache.Dispose();
        }

        /// <summary>
        ///     Gets the current UV index for the specified coordinates asynchronously.
        /// </summary>
        /// <param name="latitude">the latitude to get the weather from</param>
        /// <param name="longitude">the longitude to get the weather from</param>
        /// <param name="requestOptions">
        ///     the request options (can change the behavior of requesting and controls caching,
        ///     cancellation, unit and language options of the result)
        /// </param>
        /// <returns>a task that represents the asynchronous operation</returns>
        public Task<UVIndex> GetCurrentUVIndexAsync(double latitude, double longitude, RequestOptions requestOptions = default)
        {
            requestOptions = requestOptions ?? RequestOptions.Default;
            requestOptions.CancellationToken.ThrowIfCancellationRequested();

            // send request
            var parameters = new NameValueCollection { { "lat", latitude.ToString(CultureInfo.InvariantCulture) },
                { "lon", longitude.ToString(CultureInfo.InvariantCulture) } };

            return RequestAsync<UVIndex>("uvi", parameters, requestOptions);
        }

        /// <summary>
        ///     Gets the current weather information for the specified <paramref name="city"/> asynchronously.
        /// </summary>
        /// <param name="city">the city to get the information from</param>
        /// <param name="countryCode">the country code (used to narrow down city search results)</param>
        /// <param name="requestOptions">
        ///     the request options (can change the behavior of requesting and controls caching,
        ///     cancellation, unit and language options of the result)
        /// </param>
        /// <returns>a task that represents the asynchronous operation</returns>
        public Task<Weather> GetCurrentWeatherAsync(string city, string countryCode = null, RequestOptions requestOptions = default)
        {
            requestOptions = requestOptions ?? RequestOptions.Default;
            requestOptions.CancellationToken.ThrowIfCancellationRequested();

            // send request
            var parameters = new NameValueCollection { { "q", BuildCityName(city, countryCode) } };
            return RequestAsync<Weather>("weather", parameters, requestOptions);
        }

        /// <summary>
        ///     Gets the current weather information for the city specified by
        ///     <paramref name="cityId"/> asynchronously.
        /// </summary>
        /// <param name="cityId">the id of the city to get the weather information for ( <see cref="Weather.Id"/>)</param>
        /// <param name="requestOptions">
        ///     the request options (can change the behavior of requesting and controls caching,
        ///     cancellation, unit and language options of the result)
        /// </param>
        /// <returns>a task that represents the asynchronous operation</returns>
        public Task<Weather> GetCurrentWeatherAsync(int cityId, RequestOptions requestOptions = default)
        {
            requestOptions = requestOptions ?? RequestOptions.Default;
            requestOptions.CancellationToken.ThrowIfCancellationRequested();

            // send request
            return RequestAsync<Weather>("weather", new NameValueCollection { { "id", cityId.ToString() } }, requestOptions);
        }

        /// <summary>
        ///     Gets the current weather information for the specified coordinates asynchronously.
        /// </summary>
        /// <param name="latitude">the latitude to get the weather from</param>
        /// <param name="longitude">the longitude to get the weather from</param>
        /// <param name="requestOptions">
        ///     the request options (can change the behavior of requesting and controls caching,
        ///     cancellation, unit and language options of the result)
        /// </param>
        /// <returns>a task that represents the asynchronous operation</returns>
        public Task<Weather> GetCurrentWeatherAsync(double latitude, double longitude, RequestOptions requestOptions = default)
        {
            requestOptions = requestOptions ?? RequestOptions.Default;
            requestOptions.CancellationToken.ThrowIfCancellationRequested();

            // send request
            var parameters = new NameValueCollection { { "lat", latitude.ToString(CultureInfo.InvariantCulture) },
                { "lon", longitude.ToString(CultureInfo.InvariantCulture) } };
            return RequestAsync<Weather>("weather", parameters, requestOptions);
        }

        /// <summary>
        ///     Gets the current weather information for the specified <paramref name="cityIds"/> asynchronously.
        /// </summary>
        /// <param name="cityIds">the ids of the cities to get the weather for</param>
        /// <param name="requestOptions">
        ///     the request options (can change the behavior of requesting and controls caching,
        ///     cancellation, unit and language options of the result)
        /// </param>
        /// <returns>a task that represents the asynchronous operation</returns>
        public Task<WeatherList> GetCurrentWeatherAsync(IEnumerable<int> cityIds, RequestOptions requestOptions = default)
        {
            requestOptions = requestOptions ?? RequestOptions.Default;
            requestOptions.CancellationToken.ThrowIfCancellationRequested();

            var parameters = new NameValueCollection { { "id", string.Join(",", cityIds) } };

            // send request
            return RequestAsync<WeatherList>("group", parameters, requestOptions);
        }

        /// <summary>
        ///     Gets the current weather informations for the specified perimeter asynchronously.
        /// </summary>
        /// <remarks>
        ///     The specified coordinates ( <paramref name="latitude"/> and
        ///     <paramref name="longitude"/> marks the center of the position.)
        /// </remarks>
        /// <param name="latitude">the latitude to get the weather from</param>
        /// <param name="longitude">the longitude to get the weather from</param>
        /// <param name="count">the number of results that should be returned</param>
        /// <param name="cluster">
        ///     a value indicating whether server clustering of points should be used for the
        ///     response data
        /// </param>
        /// <param name="requestOptions">
        ///     the request options (can change the behavior of requesting and controls caching,
        ///     cancellation, unit and language options of the result)
        /// </param>
        /// <returns>a task that represents the asynchronous operation</returns>
        public Task<WeatherList> GetCurrentWeatherAsync(double latitude, double longitude, int count = 10, bool cluster = false, RequestOptions requestOptions = default)
        {
            requestOptions = requestOptions ?? RequestOptions.Default;
            requestOptions.CancellationToken.ThrowIfCancellationRequested();

            var parameters = new NameValueCollection { { "lat", latitude.ToString(CultureInfo.InvariantCulture) },
                { "lon", longitude.ToString(CultureInfo.InvariantCulture) },
                { "cnt", count.ToString() }, { "cluster", cluster ? "yes" : "no" } };

            // send request
            return RequestAsync<WeatherList>("find", parameters, requestOptions);
        }

        /// <summary>
        ///     Gets the current weather informations for the specified <paramref name="zone"/> asynchronously.
        /// </summary>
        /// <param name="zone">the zone to get the weather informations for</param>
        /// <param name="cluster">
        ///     a value indicating whether server clustering of points should be used for the
        ///     response data
        /// </param>
        /// <param name="requestOptions">
        ///     the request options (can change the behavior of requesting and controls caching,
        ///     cancellation, unit and language options of the result)
        /// </param>
        /// <returns>a task that represents the asynchronous operation</returns>
        public Task<WeatherList> GetCurrentWeatherAsync(WeatherZone zone, bool cluster = false, RequestOptions requestOptions = default)
        {
            requestOptions = requestOptions ?? RequestOptions.Default;
            requestOptions.CancellationToken.ThrowIfCancellationRequested();

            // send request
            var parameters = new NameValueCollection { { "bbox", zone.ToZoneString() }, { "cluster", cluster ? "yes" : "no" } };
            return RequestAsync<WeatherList>("box/city", parameters, requestOptions);
        }

        /// <summary>
        ///     Gets the current weather information for the specified <paramref name="zipCode"/> asynchronously.
        /// </summary>
        /// <param name="zipCode">the zip code</param>
        /// <param name="country">the country where the zip code is in (defaults to US)</param>
        /// <param name="requestOptions">
        ///     the request options (can change the behavior of requesting and controls caching,
        ///     cancellation, unit and language options of the result)
        /// </param>
        /// <returns>a task that represents the asynchronous operation</returns>
        public Task<Weather> GetCurrentWeatherAsync(int zipCode, string country = "us", RequestOptions requestOptions = default)
        {
            requestOptions = requestOptions ?? RequestOptions.Default;
            requestOptions.CancellationToken.ThrowIfCancellationRequested();

            // send request
            var parameters = new NameValueCollection { { "zip", zipCode + "," + country } };
            return RequestAsync<Weather>("weather", parameters, requestOptions);
        }

        /// <summary>
        ///     Gets the forecast UV index for the specified coordinates asynchronously.
        /// </summary>
        /// <param name="latitude">the latitude to get the weather from</param>
        /// <param name="longitude">the longitude to get the weather from</param>
        /// <param name="days">the forecast days (max: 8)</param>
        /// <param name="requestOptions">
        ///     the request options (can change the behavior of requesting and controls caching,
        ///     cancellation, unit and language options of the result)
        /// </param>
        /// <returns>a task that represents the asynchronous operation</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     thrown if the specified <paramref name="days"/> parameter is smaller than 1 or
        ///     greater than 8.
        /// </exception>
        public Task<IReadOnlyCollection<UVIndex>> GetUVIndexForecastAsync(double latitude, double longitude, int days, RequestOptions requestOptions = default)
        {
            if (days < 1 || days > 8)
            {
                throw new ArgumentOutOfRangeException(nameof(days), days, "The specified days parameter is smaller than 1 or greater than 8.");
            }

            requestOptions = requestOptions ?? RequestOptions.Default;
            requestOptions.CancellationToken.ThrowIfCancellationRequested();

            var parameters = new NameValueCollection { { "lat", latitude.ToString(CultureInfo.InvariantCulture) },
                { "lon", longitude.ToString(CultureInfo.InvariantCulture) }, { "cnt", days.ToString() } };

            // send request
            return RequestAsync<IReadOnlyCollection<UVIndex>>("uvi/forecast", parameters, requestOptions);
        }

        /// <summary>
        ///     Gets the forecast UV index for the specified coordinates asynchronously.
        /// </summary>
        /// <param name="latitude">the latitude to get the weather from</param>
        /// <param name="longitude">the longitude to get the weather from</param>
        /// <param name="start">the history start time</param>
        /// <param name="end">the history end time</param>
        /// <param name="days">the forecast days (max: 8)</param>
        /// <param name="requestOptions">
        ///     the request options (can change the behavior of requesting and controls caching,
        ///     cancellation, unit and language options of the result)
        /// </param>
        /// <returns>a task that represents the asynchronous operation</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     thrown if the specified <paramref name="days"/> parameter is smaller than 1 or
        ///     greater than 8.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     thrown if the specified <paramref name="start"/> time is before 2017-06-22.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     thrown if the <paramref name="start"/> time is greater than the
        ///     <paramref name="end"/> time.
        /// </exception>
        public Task<IReadOnlyCollection<UVIndex>> GetUVIndexHistoryAsync(double latitude, double longitude, DateTimeOffset start, DateTimeOffset end, int days, RequestOptions requestOptions = default)
        {
            if (days < 1 || days > 8)
            {
                throw new ArgumentOutOfRangeException(nameof(days), days, "The specified days parameter is smaller than 1 or greater than 8.");
            }

            if (_uvHistoryStartTime > start)
            {
                throw new ArgumentOutOfRangeException(nameof(start), start, "The historical UV index data is only available since 2017-06-22.");
            }

            if (end > start)
            {
                throw new ArgumentOutOfRangeException(nameof(end), end, "The start time is greater than the end time.");
            }

            requestOptions = requestOptions ?? RequestOptions.Default;
            requestOptions.CancellationToken.ThrowIfCancellationRequested();

            var parameters = new NameValueCollection { { "lat", latitude.ToString() }, { "lon", longitude.ToString() },
                {"start", start.ToUnixTimeSeconds().ToString() }, {"end", end.ToUnixTimeSeconds().ToString() }, { "cnt", days.ToString() } };

            // send request
            return RequestAsync<IReadOnlyCollection<UVIndex>>("uvi", parameters, requestOptions);
        }

        /// <summary>
        ///     Gets the weather forecast for the specified city asynchronously.
        /// </summary>
        /// <param name="city">the city name</param>
        /// <param name="countryCode">the country code</param>
        /// <param name="forecastType">the forecast type (Hourly, ThreeHour or Daily)</param>
        /// <param name="requestOptions">
        ///     the request options (can change the behavior of requesting and controls caching,
        ///     cancellation, unit and language options of the result)
        /// </param>
        /// <returns>a task that represents the asynchronous operation</returns>
        public Task<WeatherForecast> GetWeatherForecastAsync(string city, string countryCode = null, ForecastType forecastType = ForecastType.ThreeHour, RequestOptions requestOptions = default)
        {
            requestOptions = requestOptions ?? RequestOptions.Default;
            requestOptions.CancellationToken.ThrowIfCancellationRequested();

            // send request
            var parameters = new NameValueCollection { { "q", BuildCityName(city, countryCode) } };
            return RequestAsync<WeatherForecast>(GetEndpoint(forecastType), parameters, requestOptions);
        }

        /// <summary>
        ///     Gets the weather forecast for the specified city asynchronously.
        /// </summary>
        /// <param name="cityId">the city id</param>
        /// <param name="forecastType">the forecast type (Hourly, ThreeHour or Daily)</param>
        /// <param name="requestOptions">
        ///     the request options (can change the behavior of requesting and controls caching,
        ///     cancellation, unit and language options of the result)
        /// </param>
        /// <returns>a task that represents the asynchronous operation</returns>
        public Task<WeatherForecast> GetWeatherForecastAsync(int cityId, ForecastType forecastType = ForecastType.ThreeHour, RequestOptions requestOptions = default)
        {
            requestOptions = requestOptions ?? RequestOptions.Default;
            requestOptions.CancellationToken.ThrowIfCancellationRequested();

            // send request
            var parameters = new NameValueCollection { { "id", cityId.ToString() } };
            return RequestAsync<WeatherForecast>(GetEndpoint(forecastType), parameters, requestOptions);
        }

        /// <summary>
        ///     Gets the weather forecast for the specified city asynchronously.
        /// </summary>
        /// <param name="latitude">the latitude to get the weather forecast for</param>
        /// <param name="longitude">the longitude to get the weather forecast for</param>
        /// <param name="forecastType">the forecast type (Hourly, ThreeHour or Daily)</param>
        /// <param name="requestOptions">
        ///     the request options (can change the behavior of requesting and controls caching,
        ///     cancellation, unit and language options of the result)
        /// </param>
        /// <returns>a task that represents the asynchronous operation</returns>
        public Task<WeatherForecast> GetWeatherForecastAsync(double latitude, double longitude, ForecastType forecastType = ForecastType.ThreeHour, RequestOptions requestOptions = default)
        {
            requestOptions = requestOptions ?? RequestOptions.Default;
            requestOptions.CancellationToken.ThrowIfCancellationRequested();

            var parameters = new NameValueCollection { { "lat", latitude.ToString(CultureInfo.InvariantCulture) },
                { "lon", longitude.ToString(CultureInfo.InvariantCulture) } };

            // send request
            return RequestAsync<WeatherForecast>(GetEndpoint(forecastType), parameters, requestOptions);
        }

        /// <summary>
        ///     Gets the weather forecast for the specified city asynchronously.
        /// </summary>
        /// <param name="zipCode">the zip code</param>
        /// <param name="country">the country where the zip code is in (defaults to US)</param>
        /// <param name="forecastType">the forecast type (Hourly, ThreeHour or Daily)</param>
        /// <param name="requestOptions">
        ///     the request options (can change the behavior of requesting and controls caching,
        ///     cancellation, unit and language options of the result)
        /// </param>
        /// <returns>a task that represents the asynchronous operation</returns>
        public Task<WeatherForecast> GetWeatherForecastAsync(int zipCode, string country = "us", ForecastType forecastType = ForecastType.ThreeHour, RequestOptions requestOptions = default)
        {
            requestOptions = requestOptions ?? RequestOptions.Default;
            requestOptions.CancellationToken.ThrowIfCancellationRequested();

            // send request
            var parameters = new NameValueCollection { { "zip", zipCode + "," + country } };
            return RequestAsync<WeatherForecast>(GetEndpoint(forecastType), parameters, requestOptions);
        }

        private string BuildCityName(string city, string countryCode = null)
            => countryCode == null ? city : city + "-" + countryCode;

        private string BuildRequestCacheKey(string uri, NameValueCollection parameters)
        {
            var query = string.Join(";", parameters.Keys
                .Cast<string>().Select(s => s + ":" + parameters[s]));

            return $"req-{uri}-{{{query}}}";
        }

        private Uri BuildRequestUri(string uri, NameValueCollection queryParameters = null, RequestOptions requestOptions = default, string version = "2.5")
        {
            // create a new query string collection
            var parameters = HttpUtility.ParseQueryString(string.Empty);

            // add query parameters if specified
            if (queryParameters != null)
            {
                parameters.Add(queryParameters);
            }

            // add the api key to the query parameter list
            parameters.Add("APPID", _options.ApiKey);

            // add the specific unit if it is not the default (Kelvin)
            if (requestOptions.Unit != UnitType.Default)
            {
                parameters.Add("units", requestOptions.Unit == UnitType.Imperial
                    ? "imperial" : "metric");
            }

            // add the specific language when specified
            if (!string.IsNullOrWhiteSpace(requestOptions.Language))
            {
                parameters.Add("lang", requestOptions.Language);
            }

            // build request uri
            var query = parameters.ToString();
            var requestUri = new Uri(_options.BaseAddress, version + "/" + uri);
            var builder = new UriBuilder(requestUri) { Query = query };
            return builder.Uri;
        }

        private string GetEndpoint(ForecastType forecastType)
        {
            switch (forecastType)
            {
                case ForecastType.ThreeHour:
                    return "forecast";

                case ForecastType.Hourly:
                    return "forecast/hourly";

                case ForecastType.Daily:
                    return "forecast/daily";

                default:
                    throw new ArgumentException("Unknown forecast type.", nameof(forecastType));
            }
        }

        private async Task<TEntity> RequestAsync<TEntity>(string uri, NameValueCollection queryParameters = null, RequestOptions requestOptions = default,
            string version = "2.5", bool doCache = true, HttpMethod method = null, HttpContent httpContent = null)
        {
            method = method ?? HttpMethod.Get;
            requestOptions = requestOptions ?? RequestOptions.Default;
            requestOptions.CancellationToken.ThrowIfCancellationRequested();

            if (requestOptions.CacheMode == CacheMode.CacheOnly && doCache)
            {
                throw new InvalidOperationException("In the request options cache only is specified, but the requested resource does not support caching.");
            }

            // build the cache key for the request and check if the request is cached
            var cacheKey = doCache ? BuildRequestCacheKey(uri, queryParameters) : null;
            var cacheItem = doCache ? _cache.GetCacheItem(cacheKey) : null;

            // make sure caching is allowed and the request is cached, return the cache result
            if (cacheItem != null && cacheItem.Value != null && requestOptions.CacheMode != CacheMode.Download)
            {
                return (TEntity)cacheItem.Value;
            }

            // check if cache only is enabled. If we get this far the request was not cached, throw
            // an exception.
            if (requestOptions.CacheMode == CacheMode.CacheOnly)
            {
                throw new InvalidOperationException("The request was not retrieved from cache.");
            }

            // send request
            var requestUri = BuildRequestUri(uri, queryParameters, requestOptions, version);
            var result = await SendAsync<TEntity>(method, requestUri, httpContent);

            // add the result to the cache for 10 minutes
            if (doCache)
            {
                _cache.Add(cacheKey, result, DateTimeOffset.UtcNow + TimeSpan.FromMinutes(10));
            }

            return result;
        }

        private async Task<TEntity> SendAsync<TEntity>(HttpMethod httpMethod, Uri uri, HttpContent httpContent = null)
        {
            // send request to the api
            using (var request = new HttpRequestMessage(httpMethod, uri) { Content = httpContent })
            using (var response = await _httpClient.SendAsync(request))
            {
                // read the result as a string
                var content = await response.Content.ReadAsStringAsync();

                // the resource was not found
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return default;
                }

                // something went wrong
                if (!response.IsSuccessStatusCode)
                {
                    var messageBuilder = new StringBuilder();
                    messageBuilder.Append("OpenWeatherMap Request Error:");
                    messageBuilder.AppendFormat("\n- Got status {0} ({1}), expected: 2xx.", response.StatusCode, (int)response.StatusCode);
                    messageBuilder.AppendFormat("\n- Request Status Line: {0} {1}.", httpMethod.Method, uri);
                    messageBuilder.Append("\n- Response Headers:");

                    foreach (var header in response.Headers)
                    {
                        messageBuilder.AppendFormat("\n    - {0}:\t{1}", header.Key, string.Join(", ", header.Value));
                    }

                    messageBuilder.AppendFormat("\n- Response Content: {0}", content);
                    throw new InvalidOperationException(messageBuilder.ToString());
                }

                // deserialize the response
                return JsonConvert.DeserializeObject<TEntity>(content);
            }
        }
    }
}