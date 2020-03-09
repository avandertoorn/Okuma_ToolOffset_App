using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using ToolOffset_Models.Enumerations.EnumConverters;

namespace ToolOffset_Models.Enumerations
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum OffsetType
    {
        [Description("Fixed")]
        Fixed = 0,

        [Description("Variable")]
        Variable = 1
    }
}
