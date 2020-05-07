namespace OpenWeatherMap.Triggers.Builders
{
    using System;

    public sealed class TimePeriodBuilder
    {
        public TimePeriodBuilder(TimeExpression start, TimeExpression end)
        {
            Start = start ?? throw new ArgumentNullException(nameof(start));
            End = end ?? throw new ArgumentNullException(nameof(end));
        }

        public TimePeriodBuilder()
        {
        }

        public TimePeriod Build() => new TimePeriod
        {
            Start = Start,
            End = End
        };

        public TimeExpression Start { get; set; }
        public TimeExpression End { get; set; }

        public TimePeriodBuilder WithStartTime(TimeExpressionBuilder timeExpressionBuilder)
            => WithStartTime(timeExpressionBuilder.Build());

        public TimePeriodBuilder WithStartTime(Action<TimeExpressionBuilder> action)
        {
            var builder = new TimeExpressionBuilder();
            action(builder);
            return WithStartTime(builder.Build());
        }

        public TimePeriodBuilder WithStartTime(TimeExpressionType expressionType, DateTimeOffset dateTime)
            => WithStartTime(new TimeExpressionBuilder(expressionType, dateTime));

        public TimePeriodBuilder WithStartTime(TimeExpression timeExpression)
        {
            Start = timeExpression;
            return this;
        }

        public TimePeriodBuilder WithEndTime(TimeExpressionBuilder timeExpressionBuilder)
            => WithEndTime(timeExpressionBuilder.Build());

        public TimePeriodBuilder WithEndTime(TimeExpressionType expressionType, DateTimeOffset dateTime)
            => WithEndTime(new TimeExpressionBuilder(expressionType, dateTime));

        public TimePeriodBuilder WithEndTime(TimeExpression timeExpression)
        {
            End = timeExpression;
            return this;
        }

        public TimePeriodBuilder WithEndTime(Action<TimeExpressionBuilder> action)
        {
            var builder = new TimeExpressionBuilder();
            action(builder);
            return WithEndTime(builder.Build());
        }
    }
}