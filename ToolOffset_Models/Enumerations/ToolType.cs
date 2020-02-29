using System.ComponentModel;
using ToolOffset_Models.Enumerations.EnumConverters;

namespace ToolOffset_Models.Enumerations
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum ToolType
    {
        [Description("Right Hand Radial")]
        RightHandRadial = 0,

        [Description("Left Hand Radial")]
        LeftHandRadial = 1,

        [Description("Right Hand Axial")]
        RightHandAxial = 2,

        [Description("Left Hand Axial")]
        LeftHandAxial = 3,

        [Description("Turning Drill")]
        DrillTurn = 4,

        [Description("Multi Mach Drill")]
        DrillMulti = 5,

        [Description("Milling")]
        Mill = 6
    }
}
