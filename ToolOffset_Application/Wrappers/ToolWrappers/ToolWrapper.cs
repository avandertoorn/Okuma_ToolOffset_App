using System;
using System.Linq;
using ToolOffset_Application.Wrappers.Base;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Tools;

namespace ToolOffset_Application.Wrappers.ToolWrappers
{
    public class ToolWrapper : ModelWrapper<Tool>
    {
        public ToolWrapper(Tool model)
            : base(model)
        {
            InitializeCollectionProperties(model);
        }

        public int ToolNo
        {
            get { return GetValue<int>("ToolNo"); }
            set { SetValue(value, "ToolNo"); }
        }

        public string Name
        {
            get { return GetValue<string>("Name"); }
            set { SetValue(value, "Name"); }
        }

        public string Comment
        {
            get { return GetValue<string>("Comment"); }
            set { SetValue(value, "Comment"); }
        }

        public ToolType ToolType
        {
            get { return GetValue<ToolType>("ToolType"); }
            set { SetValue(value, "ToolType"); }
        }

        //public int ToolOffsetDefault
        //{
        //    get { return GetValue<int>("ToolOffsetDefault"); }
        //    set { SetValue(value, "ToolOffsetDefault"); }
        //}

        //public int Quantity
        //{
        //    get { return GetValue<int>("Quantity"); }
        //    set
        //    {
        //        SetValue(value, "Quantity");
        //        OnPropertyChanged("QuantityAvailable");
        //    }
        //}

        //public int QuantityAvailable
        //{
        //    get { return GetValue<int>("QuantityAvailable"); }
        //}

        //public int QuantityMounted
        //{
        //    get { return GetValue<int>("QuantityMounted"); }
        //}

        public ChangeTrackingCollection<ToolOffsetWrapper> ToolOffsets { get; private set; }

        private void InitializeCollectionProperties(Tool model)
        {
            if (model.ToolOffsets == null)
                throw new ArgumentNullException("Positions cannot be null");

            ToolOffsets = new ChangeTrackingCollection<ToolOffsetWrapper>(
                model.ToolOffsets.Select(p => new ToolOffsetWrapper(p)));
            RegisterCollection(ToolOffsets, model.ToolOffsets.ToList());
        }
    }
}
