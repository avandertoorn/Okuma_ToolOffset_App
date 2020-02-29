using System;
using ToolOffset_Models.Models.MountedTools.Positions;

namespace ToolOffset_Models.EventArg
{
    public class ToolMountUnMountEventArgs : EventArgs
    {
        public MountedPosition Position { get; private set; }

        public ToolMountUnMountEventArgs(MountedPosition position)
        {
            Position = position;
        }
    }
}
