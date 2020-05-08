namespace OpenWeatherMap.Triggers.Builders
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using OpenWeatherMap.Triggers.Area;
    using OpenWeatherMap.Triggers.Conditions;
    using OpenWeatherMap.Triggers.Time;

    public sealed class AlertTriggerBuilder
    {
        private readonly List<IGeoArea> _areas;
        private readonly List<TriggerCondition> _conditions;

        private TimePeriod _period;

        public AlertTriggerBuilder()
        {
            _areas = new List<IGeoArea>();
            _conditions = new List<TriggerCondition>();
        }

        public Trigger Build()
        {
            return new Trigger
            {
                Areas = _areas.ToArray(),
                Conditions = _conditions.ToArray(),
                Period = _period
            };
        }

        public AlertTriggerBuilder WithArea(IGeoArea area)
        {
            _areas.Add(area);
            return this;
        }

        public AlertTriggerBuilder WithCondition(TriggerCondition condition)
        {
            _conditions.Add(condition);
            return this;
        }

        public AlertTriggerBuilder WithCondition(Expression<Func<WeatherTriggerCondition, bool>> expression)
        {
            _conditions.AddRange(TriggerCondition.FromExpression(expression));
            return this;
        }

        public AlertTriggerBuilder WithPeriod(TimePeriod period)
        {
            _period = period ?? throw new ArgumentNullException(nameof(period));
            return this;
        }

        public AlertTriggerBuilder WithPeriod(DynamicTimestamp start, DynamicTimestamp end)
            => WithPeriod(new TimePeriod { Start = start, End = end });
    }
}