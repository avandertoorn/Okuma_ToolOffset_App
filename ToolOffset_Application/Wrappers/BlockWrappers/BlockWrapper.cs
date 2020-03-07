using System;
using System.Linq;
using ToolOffset_Application.Wrappers.Base;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Tools;

namespace ToolOffset_Application.Wrappers.BlockWrappers
{
    public class BlockWrapper : ModelWrapper<Block>
    {
        public BlockWrapper(Block model)
            : base(model)
        {
            InitializeCollectionProperties(model);
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

        public string Comment
        {
            get { return GetValue<string>("Comment"); }
            set { SetValue(value, "Comment"); }
        }

        public BlockType BlockType
        {
            get { return GetValue<BlockType>("BlockType"); }
            set { SetValue(value, "BlockType"); }
        }
        public int Quantity
        {
            get { return GetValue<int>("Quantity"); }
            set { SetValue(value, "Quantity"); }
        }

        public ChangeTrackingCollection<PositionWrapper> Positions { get; private set; }

        private void InitializeCollectionProperties(Block model)
        {
            if (model.Positions == null)
                throw new ArgumentNullException("Positions cannot be null");

            Positions = new ChangeTrackingCollection<PositionWrapper>(
                model.Positions.Select(p => new PositionWrapper(p)));
            RegisterCollection(Positions, model.Positions.ToList());
        }
    }
}
