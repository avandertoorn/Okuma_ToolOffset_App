using System;
using System.Collections.Generic;
using ToolOffset_Models.Models.Tools;

namespace ToolOffset_Models.EventArg
{
    public class PositionAddRemoveChangedEventArgs : EventArgs
    {
        public List<Position> AddedPositions { get; private set; }
        public List<Position> RemovedPositions { get; private set; }

        public PositionAddRemoveChangedEventArgs(List<Position> addedPositions, List<Position> removedPositions)
        {
            AddedPositions = addedPositions;
            RemovedPositions = removedPositions;
        }
    }
}
