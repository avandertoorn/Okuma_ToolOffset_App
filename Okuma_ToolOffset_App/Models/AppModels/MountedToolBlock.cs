using Okuma_ToolOffset_App.Models.AppModels.Enums;
using Okuma_ToolOffset_App.Models.AppModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okuma_ToolOffset_App.Models.AppModels
{
    public class MountedToolBlock : IToolBlock
    {
        private int _id;
        private string _name;
        private string _comment;
        private BlockTypeEnum _blockType;
        private IEnumerable<IBlockPosition> _positions;
        private MountPositionEnum _mountPosition;
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

        public string Comment
        {
            get { return _comment; }
            set
            {
                if (value != _comment)
                    _comment = value;
            }
        }

        public BlockTypeEnum BlockType
        {
            get { return _blockType; }
            set
            {
                if (value != _blockType)
                    _blockType = value;
            }
        }

        public IEnumerable<IBlockPosition> Positions
        {
            get { return _positions; }
            set
            {
                if (value != _positions)
                    _positions = value;
            }
        }

        public MountPositionEnum MountPosition
        {
            get { return _mountPosition; }
            set
            {
                if (value != _mountPosition)
                    _mountPosition = value;
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

        public double zOffset
        {
            get { return _zOffset; }
            set
            {
                if (value != _zOffset)
                    _zOffset = value;
            }
        }

        public MountedToolBlock() { }

        public MountedToolBlock(ToolBlock tool, MountPositionEnum mountPosition)
        {
            _id = tool.ID;
            _name = tool.Name;
            _comment = tool.Comment;
            _blockType = tool.BlockType;
            _positions = new List<MountedBlockPosition>();
            _positions = (from BlockPosition pos in tool.Positions
                         select new MountedBlockPosition
                         {
                             ID = pos.ID,
                             Name = pos.Name,
                             Side = pos.Side,
                             Type = pos.Type,
                             XOffset = pos.XOffset,
                             YOffset = pos.YOffset,
                             ZOffset = pos.ZOffset
                         }).ToList();
            _mountPosition = mountPosition;
        }
    }
}
