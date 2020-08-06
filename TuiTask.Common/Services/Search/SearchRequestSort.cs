using System.Runtime.Serialization;

namespace TuiTask.Common.Services.Search
{
    [DataContract]
    public enum SearchRequestSort : byte
    {
        [EnumMember(Value = "byPrice")]
        byPrice = 1,
        [EnumMember(Value = "byPriceDesc")]
        byPriceDesc = 2,
        [EnumMember(Value = "byName")]
        byName = 3,
        [EnumMember(Value = "byDate")]
        byDate = 4,
        [EnumMember(Value = "byDateDesc")]
        byDateDesc = 5
    }
}