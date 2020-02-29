using System.ComponentModel;
using ToolOffset_Models.Enumerations.EnumConverters;

namespace ToolOffset_Models.Enumerations
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum BlockPositionHand
    {
        [Description("No Hand")]
        NoHand = 0,

        [Description("Right Hand")]
        RightHand = 1,

        [Description("Left Hand")]
        LeftHand = 2
    }
}
