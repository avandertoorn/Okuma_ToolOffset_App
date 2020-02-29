using System;
using ToolOffset_Application.Wrappers.Base;
using ToolOffset_Models.Models.Tools;

namespace ToolOffset_Application.Wrappers.BlockWrappers
{
    public class PositionWrapper : ModelWrapper<Position>
    {
        public PositionWrapper(Position model)
            : base(model)
        {
            InitializeComplexProperties(model);
        }

        private void InitializeComplexProperties(Position model)
        {
            if (model.BlockPosition == null)
                throw new ArgumentNullException("BlockPosition cannot be null");

            BlockPosition = new BlockPositionWrapper(model.BlockPosition);
            RegisterComplex(BlockPosition);
        }

        public BlockPositionWrapper BlockPosition { get; private set; }
    }
}
