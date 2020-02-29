using ToolOffset_Models.Models.MountedTools.Blocks;
using ToolOffset_Models.Models.MountedTools.Offsets;
using ToolOffset_Models.Models.Tools;

namespace ToolOffset_Models.Models.MountedTools.Positions
{
    public class MountedPositionMain : MountedPosition
    {
        public MountedPositionMain(Position position, MountedBlockAssembly mountedBlockAssembly)
            : base(position, mountedBlockAssembly)
        {
        }

        public override double MountedXOffset => throw new System.NotImplementedException();

        public override double MountedYOffset => throw new System.NotImplementedException();

        public override double MountedZOffset => throw new System.NotImplementedException();

        public override void AddOffset(IMountedToolOffset toolOffset)
        {
            //TODO
            if (Tool == null)
                return;

            if (!Tool.ToolOffsets.Contains(toolOffset.ToolOffset))
                return;

            foreach (var offset in MountedToolOffsets)
            {
                if (offset.ToolOffset.Equals(toolOffset.ToolOffset))
                    return;
            }

            MountedToolOffsets.Add(toolOffset);
            OnOffsetAdded(toolOffset);
        }
    }
}
