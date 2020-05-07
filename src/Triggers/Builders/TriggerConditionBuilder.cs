namespace OpenWeatherMap.Triggers.Builders
{
    public sealed class TriggerConditionBuilder
    {
        public TriggerConditionBuilder(FieldType name, ExpressionType type, double amount)
        {
            Name = name;
            Type = type;
            Amount = amount;
        }

        public TriggerConditionBuilder()
        {
        }

        public TriggerConditionBuilder WithAmount(double amount)
        {
            Amount = amount;
            return this;
        }

        public TriggerConditionBuilder WithExpression(ExpressionType expression)
        {
            Expression = expression;
            return this;
        }

        public TriggerConditionBuilder WithName(FieldType name)
        {
            Name = name;
            return this;
        }

        public double Amount { get; set; }
        public ExpressionType Expression { get; set; }
        public FieldType Name { get; set; }
        public ExpressionType Type { get; }

        public TriggerCondition Build() => new TriggerCondition { Amount = Amount, Name = Name, Expression = Expression };
    }
}