namespace OpenWeatherMap.Triggers.Conditions
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Newtonsoft.Json;

    public sealed class TriggerCondition
    {
        public TriggerCondition(WeatherTriggerName name, object value, WeatherExpressionType expression = WeatherExpressionType.Equal)
        {
            Name = name;
            Expression = expression;
            Value = value;
        }

        [JsonRequired, JsonProperty("expression")]
        public WeatherExpressionType Expression { get; }

        [JsonRequired, JsonProperty("name")]
        public WeatherTriggerName Name { get; }

        [JsonRequired, JsonProperty("amount")]
        public object Value { get; }

        public static IEnumerable<TriggerCondition> FromExpression(Expression<Func<WeatherTriggerCondition, bool>> expression)
            => TriggerConditionExpressionConverter.FromExpression(expression);
    }
}