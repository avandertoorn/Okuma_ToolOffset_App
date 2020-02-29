using System.ComponentModel;
using ToolOffset_Models.Enumerations.EnumConverters;

namespace ToolOffset_Models.Enumerations
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum BlockPositionSide
    {
        [Description("Main")]
        Main = 0,

        [Description("Opposite")]
        Opposite = 1
    }
}
