using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Core;

namespace ToolOffset_Models.Models.Tools
{
    public class Block : ObservableBase
    {

        public Block() { }

        public Block(int id, string name, 
            string comment, BlockType blockType)
        {
            ID = id;
            Name = name;
            Comment = comment;
            BlockType = blockType;
            Positions = new ObservableCollection<Position>();
        }

        [JsonConstructor]
        public Block(int id, string name, 
            string comment, BlockType blockType, 
            IEnumerable<Position> positions)
            : this(id, name, comment, blockType)
        {
            if (positions != null)
                foreach(var position in positions)
                    Positions.Add(position);
        }


        private int _id;
        [JsonProperty]
        public int ID
        {
            get { return _id; }
            private set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("ID");
                }
            }
        }


        private string _name;
        [JsonProperty]
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


        private string _comment;
        [JsonProperty]
        public string Comment
        {
            get { return _comment; }
            private set
            {
                if (value != _comment)
                {
                    _comment = value;
                    OnPropertyChanged("Comment");
                }
            }
        }


        private BlockType _blockType;
        [JsonProperty]
        public BlockType BlockType
        {
            get { return _blockType; }
            private set
            {
                if (value != _blockType)
                {
                    _blockType = value;
                    OnPropertyChanged("BlockType");
                }
            }
        }


        private ObservableCollection<Position> _positions;
        [JsonProperty]
        public ObservableCollection<Position> Positions
        {
            get { return _positions; }
            set
            {
                if (value != _positions)
                {
                    _positions = value;
                    OnPropertyChanged("Positions");
                }
            }
        }


        private int _quantity = 1;
        [JsonProperty]
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value != _quantity)
                {
                    _quantity = value;
                    OnPropertyChanged("Quantity");
                }
            }
        }

        public void AddNewPosition(Position position)
        {
            //TODO
        }

        public void DeletePosition(Position position)
        {
            //TODO
        }

        //Cant Remember what this was for
        #region Validation

        //string IDataErrorInfo.Error
        //{
        //    get { return null; }
        //}

        //string IDataErrorInfo.this[string propertyName]
        //{
        //    get
        //    {
        //        string error = null;

        //        switch (propertyName)
        //        {
        //            case "Quantity":
        //                error = ValidateQuantity();
        //                break;
        //        }

        //        return error;
        //    }
        //}

        //private string ValidateQuantity()
        //{
        //    if (Quantity <= 0)
        //        return "Cannot be zero or negative";
        //    else if (Quantity < QuantityMounted)
        //        return "Unmount Tool First";

        //    return null;
        //}

        #endregion
    }
}

