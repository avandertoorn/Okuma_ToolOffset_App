using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolOffset_Models.Core;
using ToolOffset_Models.Models.Machine;

namespace ToolOffset_Models.Models.Tools
{
    public class MountedPosition : ObservableBase
    {
        private BlockPosition _blockPosition;
        private Tool _tool;
        private int _offsetNo1;
        private int _offsetNo2;
        public ToolOffset _toolOffset1;
        public ToolOffset _toolOffset2;

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

        public Tool Tool
        {
            get { return _tool; }
            set
            {
                if (value != _tool)
                {
                    _tool = value;
                    OffsetNo1 = 0;
                    OffsetNo2 = 0;
                    ToolOffset1 = null;
                    ToolOffset2 = null;
                    OnPropertyChanged("Tool");
                }
            }
        }

        public int OffsetNo1
        {
            get { return _offsetNo1; }
            set
            {
                if (value != _offsetNo1)
                {
                    _offsetNo1 = value;
                    OnPropertyChanged("OffsetNo1");
                }
            }
        }

        public int OffsetNo2
        {
            get { return _offsetNo2; }
            set
            {
                if (value != _offsetNo2)
                {
                    _offsetNo2 = value;
                    OnPropertyChanged("OffsetNo1");
                }
            }
        }

        public ToolOffset ToolOffset1
        {
            get { return _toolOffset1; }
            set
            {
                if (value != _toolOffset1)
                {
                    _toolOffset1 = value;
                    OnPropertyChanged("ToolOffset1");
                }
            }
        }

        public ToolOffset ToolOffset2
        {
            get { return _toolOffset2; }
            set
            {
                if (value != _toolOffset2)
                {
                    _toolOffset2 = value;
                    OnPropertyChanged("ToolOffset2");
                }
            }
        }

        public MountedPosition() { }
    }
}
