namespace OpenWeatherMap.Triggers.Builders
{
    using System;

    public sealed class TimeExpressionBuilder
    {
        public TimeExpressionBuilder()
        {
        }

        public TimeExpressionBuilder(TimeExpressionType expressionType, DateTimeOffset dateTime)
        {
            ExpressionType = expressionType;
            DateTime = dateTime;
        }

        public TimeExpressionBuilder WithExpressionType(TimeExpressionType expressionType)
        {
            ExpressionType = expressionType;
            return this;
        }

        public TimeExpressionBuilder WithDateTime(DateTimeOffset dateTime)
        {
            DateTime = dateTime;
            return this;
        }

        public TimeExpressionType ExpressionType { get; set; }

        public DateTimeOffset DateTime { get; set; }

        public TimeExpression Build() => new TimeExpression
        {
            ExpressionType = ExpressionType,
            Value = DateTime
        };
    }
}