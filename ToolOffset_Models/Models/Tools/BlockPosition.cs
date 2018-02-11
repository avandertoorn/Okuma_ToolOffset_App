using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolOffset_Models.Core;
using ToolOffset_Models.Enumerations;

namespace ToolOffset_Models.Models.Tools
{
    public class BlockPosition : ObservableBase
    {
        private int _id;
        private string _name;
        private BlockPositionSide _side;
        private BlockPositionHand _type;
        private double _xOffset;
        private double _yOffset;
        private double _zOffset;

        public int ID
        {
            get { return _id; }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("ID");
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public BlockPositionSide Side
        {
            get { return _side; }
            set
            {
                if (value != _side)
                {
                    _side = value;
                    OnPropertyChanged("Side");
                }
            }
        }

        public BlockPositionHand Type
        {
            get { return _type; }
            set
            {
                if (value != _type)
                {
                    _type = value;
                    OnPropertyChanged("Type");
                }
            }
        }

        public double XOffset
        {
            get { return _xOffset; }
            set
            {
                if (value != _xOffset)
                {
                    _xOffset = value;
                    OnPropertyChanged("XOffset");
                }
            }
        }

        public double YOffset
        {
            get { return _yOffset; }
            set
            {
                if (value != _yOffset)
                {
                    _yOffset = value;
                    OnPropertyChanged("YOffset");
                }
            }
        }

        public double ZOffset
        {
            get { return _zOffset; }
            set
            {
                if (value != _zOffset)
                {
                    _zOffset = value;
                    OnPropertyChanged("ZOffset");
                }
            }
        }

        public BlockPosition() { }

        public BlockPosition(int id, string name, BlockPositionSide side, BlockPositionHand type, double xOffset, double yOffset, double zOffset)
        {
            ID = id;
            Name = name;
            Side = side;
            Type = type;
            XOffset = xOffset;
            YOffset = yOffset;
            ZOffset = zOffset;
        }
    }
}

