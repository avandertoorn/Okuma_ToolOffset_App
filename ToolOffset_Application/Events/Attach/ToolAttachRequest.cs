using System.Collections.Generic;
using ToolOffset_Models.Models.Lathe;
using ToolOffset_Models.Models.Tools;

namespace ToolOffset_Application.Events.Attach
{
    public class ToolAttachRequest
    {
        public Tool Tool { get; }
        public MountedPosition Position { get; }
        public List<MountedToolOffset> MountedOffsets { get; }

        public ToolAttachRequest(Tool tool, MountedPosition position, IEnumerable<MountedToolOffset> mountedOffsets)
        {
            Tool = tool;
            Position = position;
            MountedOffsets = new List<MountedToolOffset>(mountedOffsets);
        }
    }
}
