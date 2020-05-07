namespace OpenWeatherMap.Triggers.Builders
{
    using System;
    using System.Collections.Generic;

    public sealed class TriggerBuilder
    {
        public List<TriggerCondition> Conditions { get; set; } = new List<TriggerCondition>();
        public TimePeriod TimePeriod { get; set; }

        public Trigger Build() => new Trigger
        {
            Conditions = Conditions.AsReadOnly(),
            TimePeriod = TimePeriod
        };

        public void Validate()
        {
            if (Conditions.Count == 0)
            {
                throw new InvalidOperationException("There are no conditions.");
            }
        }

        public TriggerBuilder WithCondition(TriggerConditionBuilder conditionBuilder)
        {
            Conditions.Add(conditionBuilder.Build());
            return this;
        }

        public TriggerBuilder WithCondition(Action<TriggerConditionBuilder> action)
        {
            var builder = new TriggerConditionBuilder();
            action(builder);
            return WithCondition(builder);
        }

        public TriggerBuilder WithCondition(FieldType fieldName, ExpressionType expressionType, double amount)
            => WithCondition(new TriggerConditionBuilder(fieldName, expressionType, amount));

        public TriggerBuilder WithTimePeriod(TimePeriodBuilder timePeriodBuilder)
        {
            TimePeriod = timePeriodBuilder.Build();
            return this;
        }

        public TriggerBuilder WithTimePeriod(Action<TimePeriodBuilder> action)
        {
            var builder = new TimePeriodBuilder();
            action(builder);
            return WithTimePeriod(builder);
        }

        public TriggerBuilder WithTimePeriod(TimeExpression start, TimeExpression end)
            => WithTimePeriod(new TimePeriodBuilder(start, end));
    }
}