using System;
using ToolOffset_Models.Models.MountedTools.Offsets;

namespace ToolOffset_Models.EventArg
{
    public class MountedOffsetAddRemoveEventArgs : EventArgs
    {
        public IMountedToolOffset MountedToolOffset { get; private set; }

        public MountedOffsetAddRemoveEventArgs(IMountedToolOffset mountedToolOffset)
        {
            MountedToolOffset = mountedToolOffset;
        }
    }
}
