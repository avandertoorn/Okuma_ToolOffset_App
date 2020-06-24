using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolOffset_Application.Wrappers.Base;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Shared;

namespace ToolOffset_Application.Wrappers.ToolWrappers
{
    public class ToolOffsetValueWrapper : ModelWrapper<ToolOffsetValue>
    {
        public ToolOffsetValueWrapper(ToolOffsetValue model) : base(model)
        {
        }
        public double Length
        {
            get { return GetValue<double>("Length"); }
            set { SetValue(value, "Length"); }
        }

        public double Width
        {
            get { return GetValue<double>("Width"); }
            set { SetValue(value, "Width"); }
        }

        public double XRadiusOffset
        {
            get { return GetValue<double>("XRadiusOffset"); }
            set { SetValue(value, "XRadiusOffset"); }
        }

        public double ZRadiusOffset
        {
            get { return GetValue<double>("ZRadiusOffset"); }
            set { SetValue(value, "ZRadiusOffset"); }
        }

        public RadiusCompPattern RadiusCompPattern
        {
            get { return GetValue<RadiusCompPattern>("RadiusCompPattern"); }
            set { SetValue(value, "RadiusCompPattern"); }
        }
    }
}
