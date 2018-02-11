using Okuma_ToolOffset_App.Models.AppModels.Enums;
using Okuma_ToolOffset_App.Models.AppModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okuma_ToolOffset_App.Models.AppModels
{
    public class BlockPosition : IBlockPosition
    {
        private int _id;
        private string _name;
        private BlockSideEnum _side;
        private BlockPositionTypeEnum _type;
        private double _xOffset;
        private double _yOffset;
        private double _zOffset;

        public int ID
        {
            get { return _id; }
            set
            {
                if (value != _id)
                    _id = value;
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                    _name = value;
            }
        }

        public BlockSideEnum Side
        {
            get { return _side; }
            set
            {
                if (value != _side)
                    _side = value;
            }
        }

        public BlockPositionTypeEnum Type
        {
            get { return _type; }
            set
            {
                if (value != _type)
                    _type = value;
            }
        }

        public double XOffset
        {
            get { return _xOffset; }
            set
            {
                if (value != _xOffset)
                    _xOffset = value;
            }
        }

        public double YOffset
        {
            get { return _yOffset; }
            set
            {
                if (value != _yOffset)
                    _yOffset = value;
            }
        }

        public double ZOffset
        {
            get { return _zOffset; }
            set
            {
                if (value != _zOffset)
                    _zOffset = value;
            }
        }
    }
}
