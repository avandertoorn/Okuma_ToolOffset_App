using System;
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

        public ToolOffsetValueWrapper Offset { get; private set; }

        private void InitializeCompleProperties(ToolOffset model)
        {
            if (model.Offset == null)
                throw new ArgumentNullException("Offset cannot be null");

            Offset = new ToolOffsetValueWrapper(model.Offset);
            //TODO: RegisterComplex<ToolOffsetValueWrapper>(Offset);
        }
    }
}
