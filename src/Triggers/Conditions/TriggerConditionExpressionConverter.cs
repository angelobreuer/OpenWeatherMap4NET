namespace OpenWeatherMap.Triggers.Conditions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    internal static class TriggerConditionExpressionConverter
    {
        public static IEnumerable<TriggerCondition> FromExpression(Expression<Func<WeatherTriggerCondition, bool>> expression)
        {
            if (expression.CanReduce)
            {
                expression = (Expression<Func<WeatherTriggerCondition, bool>>)expression.ReduceAndCheck();
            }

            if (!(expression is LambdaExpression lambdaExpression))
            {
                throw new ArgumentException("Expected lambda expression: " + expression, nameof(expression));
            }

            if (!(lambdaExpression.Body is BinaryExpression binaryExpression))
            {
                throw new ArgumentException("Expected binary expression: " + lambdaExpression.Body, nameof(expression));
            }

            return VisitAndAlsoExpressionChain(binaryExpression).Select(CreateFromExpression);
        }

        private static TriggerCondition CreateFromExpression(BinaryExpression expression)
        {
            var expressionType = ResolveExpressionType(expression);

            var leftConstantExpression = expression.Left as ConstantExpression;
            var rightConstantExpression = expression.Right as ConstantExpression;

            if ((leftConstantExpression is null) == (rightConstantExpression is null))
            {
                var failedExpression = leftConstantExpression is null ? expression.Right : expression.Left;
                throw new InvalidOperationException("Could not convert expression: " + failedExpression);
            }

            var constantValue = leftConstantExpression is null ? rightConstantExpression.Value : leftConstantExpression.Value;
            var propertyExpression = (leftConstantExpression is null ? expression.Left : expression.Right) as MemberExpression;

            if (propertyExpression is null)
            {
                var failedExpression = leftConstantExpression is null ? expression.Left : expression.Right;
                throw new InvalidOperationException("Could not convert expression: " + failedExpression);
            }

            if (propertyExpression.Member.DeclaringType != typeof(WeatherTriggerCondition))
            {
                throw new InvalidOperationException("Could not convert expression: " + propertyExpression);
            }

            if (((PropertyInfo)propertyExpression.Member).PropertyType != constantValue.GetType())
            {
                throw new InvalidOperationException("Could not convert expression: " + expression);
            }

            var triggerType = ResolveTriggerType(propertyExpression.Member.Name);
            return new TriggerCondition(triggerType, constantValue, expressionType);
        }

        private static WeatherExpressionType ResolveExpressionType(BinaryExpression expression)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.Equal: return WeatherExpressionType.Equal;
                case ExpressionType.NotEqual: return WeatherExpressionType.NotEqual;
                case ExpressionType.GreaterThan: return WeatherExpressionType.GreaterThan;
                case ExpressionType.LessThan: return WeatherExpressionType.LessThan;
                case ExpressionType.GreaterThanOrEqual: return WeatherExpressionType.GreaterThan;
                case ExpressionType.LessThanOrEqual: return WeatherExpressionType.GreaterOrEqual;
            }

            throw new ArgumentOutOfRangeException(
                nameof(expression.NodeType), expression.NodeType,
                "Unsupported logical expression type: " + expression);
        }

        private static WeatherTriggerType ResolveTriggerType(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(WeatherTriggerCondition.Clouds): return WeatherTriggerType.Clouds;
                case nameof(WeatherTriggerCondition.Humidity): return WeatherTriggerType.Humidity;
                case nameof(WeatherTriggerCondition.Pressure): return WeatherTriggerType.Pressure;
                case nameof(WeatherTriggerCondition.Temperature): return WeatherTriggerType.Temperature;
                case nameof(WeatherTriggerCondition.WindDirection): return WeatherTriggerType.WindDirection;
                case nameof(WeatherTriggerCondition.WindSpeed): return WeatherTriggerType.WindSpeed;
            }

            throw new ArgumentException("Failed to resolve weather trigger type.", nameof(propertyName));
        }

        private static IEnumerable<BinaryExpression> VisitAndAlsoExpressionChain(BinaryExpression expression)
        {
            var enumerable = Enumerable.Empty<BinaryExpression>();

            if (expression.NodeType == ExpressionType.AndAlso)
            {
                if (!(expression.Left is BinaryExpression leftBinaryExpression))
                {
                    throw new InvalidOperationException("Could not convert expression: " + expression.Left);
                }

                // append left children
                enumerable = enumerable.Concat(VisitAndAlsoExpressionChain(leftBinaryExpression));

                if (!(expression.Right is BinaryExpression rightBinaryExpression))
                {
                    throw new InvalidOperationException("Could not convert expression: " + expression.Right);
                }

                // append right children
                enumerable = enumerable.Concat(VisitAndAlsoExpressionChain(rightBinaryExpression));
            }
            else
            {
                // append self
                enumerable = enumerable.Append(expression);
            }

            return enumerable;
        }
    }
}