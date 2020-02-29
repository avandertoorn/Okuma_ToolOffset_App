using System.ComponentModel;
using ToolOffset_Models.Enumerations.EnumConverters;

namespace ToolOffset_Models.Enumerations
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum RadiusCompPattern
    {
        [Description("None")]
        None = 0,

        [Description("BackRight")]
        BackRight = 1,

        [Description("BackLeft")]
        BackLeft = 2,

        [Description("FrontLeft")]
        FrontLeft = 3,

        [Description("FrontRight")]
        FrontRight = 4,

        [Description("Right")]
        Right = 5,

        [Description("Back")]
        Back = 6,

        [Description("Left")]
        Left = 7,

        [Description("Front")]
        Front = 8,

        [Description("Center")]
        Center = 9
    }
}
