namespace OpenWeatherMap.Triggers
{
    using System;
    using System.Collections.Generic;

    public sealed class AlertEventArgs : EventArgs
    {
        public AlertEventArgs(Trigger trigger, IReadOnlyDictionary<string, TriggerAlert> alerts)
        {
            Trigger = trigger ?? throw new ArgumentNullException(nameof(trigger));
            Alerts = alerts ?? throw new ArgumentNullException(nameof(alerts));
        }

        public IReadOnlyDictionary<string, TriggerAlert> Alerts { get; }
        public Trigger Trigger { get; }
    }
}