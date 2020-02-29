using System;
using System.Collections.ObjectModel;
using ToolOffset_Models.EventArg;
using ToolOffset_Models.Models.MountedTools.Blocks;
using ToolOffset_Models.Models.MountedTools.Offsets;
using ToolOffset_Models.Models.Tools;

namespace ToolOffset_Models.Models.MountedTools.Positions
{
    public interface IMountedPosition
    {
        IMountedBlockAssembly ParentMountedBlockAssembly { get; }
        BlockPosition BlockPosition { get; }
        Tool Tool { get; }
        ObservableCollection<IMountedToolOffset> MountedToolOffsets { get; }
        void MountTool(Tool tool);
        void UnMountTool();
        void AddOffset(IMountedToolOffset toolOffset);
        void RemoveOffset(IMountedToolOffset toolOffset);
        event EventHandler ToolMounted;
        event EventHandler ToolUnmounting;
        event EventHandler<MountedOffsetAddRemoveEventArgs> OffsetAdded;
        event EventHandler<MountedOffsetAddRemoveEventArgs> OffsetRemoving;
        double MountedXOffset { get; }
        double MountedYOffset { get; }
        double MountedZOffset { get; }
    }
}
