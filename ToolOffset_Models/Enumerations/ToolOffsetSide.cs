using System.ComponentModel;
using ToolOffset_Models.Enumerations.EnumConverters;

namespace ToolOffset_Models.Enumerations
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum ToolOffsetSide
    {
        [Description("Main Spindle")]
        MainSpindle = 0,

        [Description("Sub Spindle")]
        SubSpindle = 1
    }
}
