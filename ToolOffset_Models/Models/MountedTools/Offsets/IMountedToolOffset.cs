using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.MountedTools.Positions;

namespace ToolOffset_Models.Models.MountedTools.Offsets
{
    public interface IMountedToolOffset
    {
        int OffsetNo { get; set; }

        IMountedPosition ParentMountedPosition { get; }
        ToolOffset ToolOffset { get; }
        ToolOffsetSide ToolOffsetSide { get; }
        double MountedXOffset { get; }
        double MountedYOffset { get; }
        double MountedZOffset { get; }
        double XRadiusOffset { get; }
        double ZRadiusOffset { get; }
        RadiusCompPattern MountedPattern { get; }
    }
}
