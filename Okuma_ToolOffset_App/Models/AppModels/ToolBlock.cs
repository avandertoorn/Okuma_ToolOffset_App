using Okuma_ToolOffset_App.Models.AppModels.Enums;
using Okuma_ToolOffset_App.Models.AppModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okuma_ToolOffset_App.Models.AppModels
{
    public class ToolBlock : IToolBlock
    {
        private int _id;
        private string _name;
        private string _comment;
        private BlockTypeEnum _blockType;
        private IEnumerable<IBlockPosition> _positions;

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
    }
}
