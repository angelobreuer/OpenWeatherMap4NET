namespace OpenWeatherMap.Triggers.Conditions
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public sealed class TriggerCondition
    {
        public TriggerCondition(WeatherTriggerType type, object value, WeatherExpressionType expression = WeatherExpressionType.Equal)
        {
            Type = type;
            Expression = expression;
            Value = value;
        }

        public WeatherExpressionType Expression { get; }
        public WeatherTriggerType Type { get; }
        public object Value { get; }

        public static IEnumerable<TriggerCondition> FromExpression(Expression<Func<WeatherTriggerCondition, bool>> expression)
            => TriggerConditionExpressionConverter.FromExpression(expression);
    }
}