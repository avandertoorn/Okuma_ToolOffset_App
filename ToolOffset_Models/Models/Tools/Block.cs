using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Core;

namespace ToolOffset_Models.Models.Tools
{
    public class Block : ObservableBase
    {

        public Block() { }

        public Block(int id, string name, string comment, BlockType blockType)
        {
            ID = id;
            Name = name;
            Comment = comment;
            BlockType = blockType;
        }

        private int _id;

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

        private string _name;

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

        private string _comment;

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

        private BlockType _blockType;

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
    }
}

