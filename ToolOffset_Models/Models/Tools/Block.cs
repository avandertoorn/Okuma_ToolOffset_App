using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Core;

namespace ToolOffset_Models.Models.Tools
{
    public class Block : ObservableBase
    {
        public Block(int id, int blockNo, string name,
            string comment, BlockType blockType,
            IEnumerable<Position> positions)
        {

            BlockNo = blockNo;
            Name = name;
            Comment = comment;
            BlockType = blockType;
            if (positions != null)
            {
                _positions = new ObservableCollection<Position>(positions);
                Positions = new ReadOnlyObservableCollection<Position>(_positions);
            }
            else
            {
                _positions = new ObservableCollection<Position>();
                Positions = new ReadOnlyObservableCollection<Position>(_positions);
            }
        }


        private int _id;
        public int Id
        {
            get { return _id; }
            private set
            {
                if(value != _id)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }


        private int _blockNo;
        public int BlockNo
        {
            get { return _blockNo; }
            private set
            {
                if (value != _blockNo)
                {
                    _blockNo = value;
                    OnPropertyChanged("BlockNo");
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


        private string _comment;
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


        private int _quantity = 1;
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

        private ObservableCollection<Position> _positions;
        private ReadOnlyObservableCollection<Position> _readOnlyPositions;
        public ReadOnlyObservableCollection<Position> Positions
        {
            get { return _readOnlyPositions; }
            set
            {
                if (value != _readOnlyPositions)
                {
                    _readOnlyPositions = value;
                    OnPropertyChanged("Positions");
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

