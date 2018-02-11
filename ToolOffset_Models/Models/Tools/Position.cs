using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolOffset_Models.Core;

namespace ToolOffset_Models.Models.Tools
{
    public class Position : ObservableBase
    {
        private BlockPosition _blockPosition;

        public BlockPosition BlockPosition
        {
            get { return _blockPosition; }
            set
            {
                if (value != _blockPosition)
                {
                    _blockPosition = value;
                    OnPropertyChanged("BlockPosition");
                }
            }
        }

        public Position()
        {
            BlockPosition = new BlockPosition();
        }

        public Position(BlockPosition blockPosition)
        {
            BlockPosition = blockPosition;
        }

        public static explicit operator MountedPosition(Position position)
        {
            return new MountedPosition
            {
                BlockPosition = position.BlockPosition
            };
        }
    }
}