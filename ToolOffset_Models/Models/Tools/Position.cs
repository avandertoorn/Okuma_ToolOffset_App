using System;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Core;

namespace ToolOffset_Models.Models.Tools
{
    public class Position : ObservableBase
    {
        private Position() { }

        public Position(int id, string name,
            BlockPositionSide side, BlockPositionHand type,
            double xOffset, double yOffset, double zOffset)
        {
            Id = id;
            Name = name;
            Side = side;
            Hand = type;
            XOffset = xOffset;
            YOffset = yOffset;
            ZOffset = zOffset;
        }


        private int _id;
        public int Id
        {
            get { return _id; }
            private set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }


        private string _name;
        public string Name
        {
            get { return _name; }
            private set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }


        private BlockPositionSide _side;
        public BlockPositionSide Side
        {
            get { return _side; }
            private set
            {
                if (value != _side)
                {
                    _side = value;
                    OnPropertyChanged("Side");
                }
            }
        }


        private BlockPositionHand _hand;
        public BlockPositionHand Hand
        {
            get { return _hand; }
            private set
            {
                if (value != _hand)
                {
                    _hand = value;
                    OnPropertyChanged("Hand");
                }
            }
        }


        private double _xOffset;
        public double XOffset
        {
            get { return _xOffset; }
            private set
            {
                if (value != _xOffset)
                {
                    _xOffset = value;
                    OnPropertyChanged("XOffset");
                }
            }
        }


        private double _yOffset;
        public double YOffset
        {
            get { return _yOffset; }
            private set
            {
                if (value != _yOffset)
                {
                    _yOffset = value;
                    OnPropertyChanged("YOffset");
                }
            }
        }


        private double _zOffset;
        public double ZOffset
        {
            get { return _zOffset; }
            private set
            {
                if (value != _zOffset)
                {
                    _zOffset = value;
                    OnPropertyChanged("ZOffset");
                }
            }
        }

        //private Block _block;
        //public Block Block
        //{
        //    get { return _block; }
        //    private set
        //    {
        //        if(value != _block)
        //        {
        //            _block = value;
        //            OnPropertyChanged("Block");
        //        }
        //    }
        //}

        //private int _blockId;
        //public int BlockId
        //{
        //    get { return _blockId; }
        //    private set
        //    {
        //        if (value != _blockId)
        //        {
        //            _blockId = value;
        //            OnPropertyChanged("BlockId");
        //        }
        //    }
        //}
    }
}