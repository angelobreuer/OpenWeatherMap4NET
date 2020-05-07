namespace OpenWeatherMap.Triggers
{
    using System.Runtime.Serialization;

    public enum TimeExpressionType
    {
        [EnumMember(Value = "after")]
        After,

        [EnumMember(Value = "before")]
        Before,

        [EnumMember(Value = "exact")]
        Exact
    }
}