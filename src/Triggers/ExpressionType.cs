namespace OpenWeatherMap.Triggers
{
    using System.Runtime.Serialization;

    public enum ExpressionType
    {
        [EnumMember(Value = "$gt")]
        GreaterThan,

        [EnumMember(Value = "$lt")]
        LessThan,

        [EnumMember(Value = "$gte")]
        GreaterThanOrEquals,

        [EnumMember(Value = "$lte")]
        LessThanOrEquals,

        [EnumMember(Value = "$eq")]
        Equals,

        [EnumMember(Value = "$ne")]
        NotEquals
    }
}