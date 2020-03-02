using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Lathe;
using ToolOffset_Models.Models.MountedTools.Positions;
using ToolOffset_Models.Models.Tools;

namespace ToolOffset_Models.Models.MountedTools.Blocks
{
    public class ForwardMountedBlockAssembly : MountedBlockAssembly
    {
        public ForwardMountedBlockAssembly(Block blockAssembly, Station station)
            : base(blockAssembly, station)
        {
        }

        public override void AddPosition(Position position)
        {
            switch (position.Side)
            {
                case BlockPositionSide.Main:
                    Positions.Add(new MountedPositionMain(position, this));
                    break;
                case BlockPositionSide.Opposite:
                    Positions.Add(new MountedPositionSub(position, this));
                    break;
            }
        }

        public override BlockOrientation BlockOrientation { get => BlockOrientation.Foward; }
    }
}
