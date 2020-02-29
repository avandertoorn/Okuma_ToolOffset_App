using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.MountedTools.Positions;

namespace ToolOffset_Models.Models.MountedTools.Offsets
{
    public class MainSideAxialRegularMainOffset : MountedToolOffset
    {
        public MainSideAxialRegularMainOffset(ToolOffset toolOffset, MountedPosition mountedPosition)
            : base(toolOffset, mountedPosition)
        {
        }

        public override ToolOffsetSide ToolOffsetSide => ToolOffsetSide.MainSpindle;

        public override double MountedXOffset =>
            ParentMountedPosition.ParentMountedBlockAssembly.Station.Turret.MainSideXAdjust
            - ToolOffset.Width
            - ParentMountedPosition.MountedXOffset;

        public override double MountedYOffset => ParentMountedPosition.MountedYOffset;

        public override double MountedZOffset =>
            ParentMountedPosition.ParentMountedBlockAssembly.Station.Turret.MainSideZAdjust
            - ToolOffset.Length
            - ParentMountedPosition.MountedZOffset;

        //TODO
        public override double XRadiusOffset => ToolOffset.XRadiusOffset;
        //TODO
        public override double ZRadiusOffset => ToolOffset.ZRadiusOffset;
        //TODO
        public override RadiusCompPattern MountedPattern => ToolOffset.RadiusCompPattern;
    }
}
