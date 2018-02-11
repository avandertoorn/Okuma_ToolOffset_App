using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolOffset_Models.Core;
using ToolOffset_Models.Enumerations;

namespace ToolOffset_Models.Models.Tools
{
    public class Block : ObservableBase
    {
        private int _id;
        private string _name;
        private string _comment;
        private BlockType _blockType;

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

        public string Comment
        {
            get { return _comment; }
            set
            {
                if (value != _comment)
                {
                    _comment = value;
                    OnPropertyChanged("Comment");
                }
            }
        }

        public BlockType BlockType
        {
            get { return _blockType; }
            set
            {
                if (value != _blockType)
                {
                    _blockType = value;
                    OnPropertyChanged("BlockType");
                }
            }
        }

        public Block() { }

        public Block(int id, string name, string comment, BlockType blockType)
        {
            ID = id;
            Name = name;
            Comment = comment;
            BlockType = blockType;
        }
    }
}

