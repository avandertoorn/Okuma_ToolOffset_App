using System;
using System.Collections.Generic;

namespace ToolOffset_Models.Models.Lathe
{
    public class MountedPosition
    {
        public Guid Id { get; set; }
        public MountedTool Tool { get; set; }
        public List<MountedToolOffset> ToolOffsets { get; set; }
    }
}