using System;
using System.Linq;
using ToolOffset_Application.Wrappers.Base;
using ToolOffset_Models.Models.Tools;

namespace ToolOffset_Application.Wrappers.BlockWrappers
{
    public class BlockAssemblyWrapper : ModelWrapper<BlockAssembly>
    {
        public BlockAssemblyWrapper(BlockAssembly model) : base(model)
        {
            InitializeComplexProperties(model);
            InitializeCollectionProperties(model);
        }

        public int Quantity
        {
            get { return GetValue<int>("Quantity"); }
            set { SetValue(value, "Quantity"); }
        }

        public int QuantityMounted
        {
            get { return GetValue<int>("QuantityMounted"); }
            set { SetValue(value, "QuantityMounted"); }
        }

        public int QuantityAvailable
        {
            get { return GetValue<int>("QuantityAvailable"); }
            set { SetValue(value, "QuantityAvailable"); }
        }

        public BlockWrapper Block { get; private set; }

        public ChangeTrackingCollection<PositionWrapper> Positions { get; private set; }

        private void InitializeCollectionProperties(BlockAssembly model)
        {
            if (model.Positions == null)
                throw new ArgumentNullException("Positions cannot be null");

            Positions = new ChangeTrackingCollection<PositionWrapper>(
                model.Positions.Select(p => new PositionWrapper(p)));
            RegisterCollection(Positions, model.Positions);
        }

        private void InitializeComplexProperties(BlockAssembly model)
        {
            if (model.Block == null)
                throw new ArgumentNullException("Block cannot be null");

            Block = new BlockWrapper(model.Block);
            RegisterComplex(Block);
        }
    }
}
