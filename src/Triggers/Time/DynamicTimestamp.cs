namespace OpenWeatherMap.Triggers.Time
{
    using System;
    using Newtonsoft.Json;

    public sealed class DynamicTimestamp
    {
        public DynamicTimestamp(long offset, TimestampExpression expression)
        {
            Offset = offset;
            Expression = expression;
        }

        [JsonRequired, JsonProperty("expression")]
        public TimestampExpression Expression { get; internal set; }

        [JsonRequired, JsonProperty("amount")]
        public long Offset { get; internal set; }

        public DateTimeOffset ToTimestamp()
        {
            switch (Expression)
            {
                case TimestampExpression.Exact:
                    return DateTimeOffset.FromUnixTimeMilliseconds(Offset);

                case TimestampExpression.After:
                    return DateTimeOffset.UtcNow + TimeSpan.FromMilliseconds(Offset);

                case TimestampExpression.Before:
                    return DateTimeOffset.UtcNow - TimeSpan.FromMilliseconds(Offset);
            }

            throw new ArgumentOutOfRangeException(nameof(Expression), Expression,
                "The specified Expression is not defined in the TimestampExpression enumeration.");
        }
    }
}