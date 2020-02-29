using System;
using System.Collections.Generic;
using ToolOffset_Models.Models;

namespace ToolOffset_Models.EventArg
{
    public class ToolOffsetsAddedRemovedEventArgs : EventArgs
    {
        public List<ToolOffset> AddedOffsets { get; private set; }
        public List<ToolOffset> RemovedOffsets { get; private set; }

        public ToolOffsetsAddedRemovedEventArgs(List<ToolOffset> addedOffsets, List<ToolOffset> removedOffsets)
        {
            AddedOffsets = addedOffsets;
            RemovedOffsets = removedOffsets;
        }
    }
}
