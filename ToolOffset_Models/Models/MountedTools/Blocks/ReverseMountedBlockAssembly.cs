using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Lathe;
using ToolOffset_Models.Models.MountedTools.Positions;
using ToolOffset_Models.Models.Tools;

namespace ToolOffset_Models.Models.MountedTools.Blocks
{
    public class ReverseMountedBlockAssembly : MountedBlockAssembly
    {
        public ReverseMountedBlockAssembly(BlockAssembly blockAssembly, Station station)
            : base(blockAssembly, station)
        {
            //TODO: impliment positons list add
        }

        public override void AddPosition(Position position)
        {
            switch (position.BlockPosition.Side)
            {
                case BlockPositionSide.Main:
                    Positions.Add(new MountedPositionSub(position, this));
                    break;
                case BlockPositionSide.Opposite:
                    Positions.Add(new MountedPositionMain(position, this));
                    break;
            }
        }

        public override BlockOrientation BlockOrientation { get => BlockOrientation.Reverse; }
    }
}
