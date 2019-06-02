namespace OpenWeatherMap
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using OpenWeatherMap.Triggers;
    using OpenWeatherMap.Util;

    public class OpenWeatherMapTriggerService : OpenWeatherMapService, IDisposable
    {
        private readonly OpenWeatherMapTriggerOptions _options;
        private readonly CancellationTokenSource _cancellationTokenSource;

        public event Func<AlertTrigger, Alert, Task> AlertReceived;

        public override void Dispose()
        {
            base.Dispose();
            _cancellationTokenSource.Cancel();
        }

        protected virtual Task OnAlertReceived(AlertTrigger trigger, Alert alert)
            => AlertReceived == null ? Task.CompletedTask : Task.WhenAll(AlertReceived.GetInvocationList()
                .Select(s => s.DynamicInvoke(trigger, alert)).Cast<Task>());

        public OpenWeatherMapTriggerService(OpenWeatherMapTriggerOptions options) : base(options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _cancellationTokenSource = new CancellationTokenSource();
            _ = GetUpdateTask();
        }

        public async Task<int> ForcePullAlertsAsync(RequestOptions requestOptions = default)
        {
            Console.WriteLine("polling...");
            var triggers = await GetAllTriggersAsync(requestOptions);
            var tasks = triggers.SelectMany(s => s.Alerts.Select(j => OnAlertReceived(s, j.Value))).ToArray();
            await Task.WhenAll(tasks);
            Console.WriteLine("polling finished: " + tasks.Length);
            return tasks.Length;
        }

        public Task<IReadOnlyCollection<AlertTrigger>> GetAllTriggersAsync(RequestOptions requestOptions = default)
        {
            requestOptions = requestOptions ?? RequestOptions.Default;
            requestOptions.CancellationToken.ThrowIfCancellationRequested();

            return RequestAsync<IReadOnlyCollection<AlertTrigger>>("triggers", doCache: false, requestOptions: requestOptions, version: "3.0");
        }

        public async Task<AlertTrigger> UpdateTriggerAsync(string id, Trigger trigger, RequestOptions requestOptions = default)
        {
            requestOptions = requestOptions ?? RequestOptions.Default;
            requestOptions.CancellationToken.ThrowIfCancellationRequested();

            using (var content = new JsonContent(JsonConvert.SerializeObject(trigger)))
            {
                return await RequestAsync<AlertTrigger>($"trigger/{id}", null, requestOptions, "3.0", false, HttpMethod.Put, content);
            }
        }

        public Task<HistoryAlert> GetHistoryAlertAsync(string triggerId, string alertId, RequestOptions requestOptions = default)
        {
            requestOptions = requestOptions ?? RequestOptions.Default;
            requestOptions.CancellationToken.ThrowIfCancellationRequested();

            return RequestAsync<HistoryAlert>($"triggers/{triggerId}/history/{alertId}", null, requestOptions, version: "3.0", doCache: false);
        }

        public Task<AlertTrigger> GetTriggerAsync(string id, RequestOptions requestOptions = default)
        {
            requestOptions = requestOptions ?? RequestOptions.Default;
            requestOptions.CancellationToken.ThrowIfCancellationRequested();

            return RequestAsync<AlertTrigger>($"triggers/{id}", null, requestOptions, version: "3.0", doCache: false);
        }

        public Task<IReadOnlyCollection<HistoryAlert>> GetTriggerHistoryAsync(string id, RequestOptions requestOptions = default)
        {
            requestOptions = requestOptions ?? RequestOptions.Default;
            requestOptions.CancellationToken.ThrowIfCancellationRequested();

            return RequestAsync<IReadOnlyCollection<HistoryAlert>>($"triggers/{id}/history", null, requestOptions, "3.0", false);
        }

        public async Task<AlertTrigger> CreateTriggerAsync(Trigger trigger, RequestOptions requestOptions = default)
        {
            requestOptions = requestOptions ?? RequestOptions.Default;
            requestOptions.CancellationToken.ThrowIfCancellationRequested();

            using (var content = new JsonContent(JsonConvert.SerializeObject(trigger)))
            {
                return await RequestAsync<AlertTrigger>("triggers", null, requestOptions, "3.0", false, HttpMethod.Post, content);
            }
        }

        public Task DeleteHistoryAsync(string triggerId, RequestOptions requestOptions = default)
        {
            requestOptions = requestOptions ?? RequestOptions.Default;
            requestOptions.CancellationToken.ThrowIfCancellationRequested();

            return RequestAsync<HistoryAlert>($"triggers/{triggerId}/history", null, requestOptions, version: "3.0", doCache: false, HttpMethod.Delete);
        }

        public Task DeleteTriggerAsync(string id, RequestOptions requestOptions = default)
        {
            requestOptions = requestOptions ?? RequestOptions.Default;
            requestOptions.CancellationToken.ThrowIfCancellationRequested();

            return RequestAsync<AlertTrigger>($"triggers/{id}", null, requestOptions,
                version: "3.0", doCache: false, method: HttpMethod.Delete);
        }

        public Task DeleteTriggerHistorysync(string triggerId, string alertId, RequestOptions requestOptions = default)
        {
            requestOptions = requestOptions ?? RequestOptions.Default;
            requestOptions.CancellationToken.ThrowIfCancellationRequested();

            return RequestAsync<HistoryAlert>($"triggers/{triggerId}/history/{alertId}", null, requestOptions, version: "3.0", doCache: false, HttpMethod.Delete);
        }

        private async Task GetUpdateTask()
        {
            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                var pullTask = ForcePullAlertsAsync();
                await Task.WhenAll(pullTask, Task.Delay(_options.PollInterval));
            }
        }
    }
}