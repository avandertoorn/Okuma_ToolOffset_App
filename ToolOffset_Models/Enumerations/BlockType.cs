using System.ComponentModel;
using ToolOffset_Models.Enumerations.EnumConverters;

namespace ToolOffset_Models.Enumerations
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum BlockType
    {
        [Description("Radial Turning")]
        RadialTurn = 0,

        [Description("Axial Turning")]
        AxialTurn = 1,

        [Description("Radial Milling")]
        RadialMill = 2,

        [Description("Axial Milling")]
        AxialMill = 3
    }
}
