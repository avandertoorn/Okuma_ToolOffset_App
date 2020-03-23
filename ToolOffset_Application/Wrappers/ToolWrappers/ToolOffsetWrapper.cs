using ToolOffset_Application.Wrappers.Base;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Tools;

namespace ToolOffset_Application.Wrappers.ToolWrappers
{
    public class ToolOffsetWrapper : ModelWrapper<ToolOffset>
    {
        public ToolOffsetWrapper(ToolOffset model)
            : base(model)
        {
        }

        public int ID
        {
            get { return GetValue<int>("ID"); }
            set { SetValue(value, "ID"); }
        }

        public string Name
        {
            get { return GetValue<string>("Name"); }
            set { SetValue(value, "Name"); }
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
