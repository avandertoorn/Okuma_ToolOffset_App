using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ToolOffset_Models.Models.Core;

namespace ToolOffset_Models.Models.Tools
{
    public class BlockAssembly : ObservableBase, IDataErrorInfo
    {
        public BlockAssembly() { }

        public BlockAssembly(Block block)
        {
            Block = block;
        }

        public BlockAssembly(Block block, IEnumerable<Position> positions)
        {
            Block = block;
            Positions = new List<Position>(positions);
        }

        private Block _block;

        public Block Block
        {
            get { return _block; }
            set
            {
                if (value != _block)
                {
                    _block = value;
                    OnPropertyChanged("Block");
                }
            }
        }

        private List<Position> _positions;

        public List<Position> Positions
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

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value != _quantity)
                {
                    _quantity = value;
                    _quantityAvailable = _quantity - _quantityMounted;
                    OnPropertyChanged("Quantity");
                    OnPropertyChanged("QuantityAvailable");

                }
            }
        }

        private int _quantityMounted = 0;

        public int QuantityMounted
        {
            get { return _quantityMounted; }
        }

        private int _quantityAvailable;

        public int QauntityAvailable
        {
            get { return _quantityAvailable; }
        }

        #region Validation

        string IDataErrorInfo.Error
        {
            get { return null; }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                string error = null;

                switch (propertyName)
                {
                    case "Quantity":
                        error = ValidateQuantity();
                        break;
                }

                return error;
            }
        }

        private string ValidateQuantity()
        {
            if (Quantity <= 0)
                return "Cannot be zero or negative";
            else if (Quantity < QuantityMounted)
                return "Unmount Tool First";

            return null;
        }

        #endregion

        #region Public Methods

        public void MountBlock()
        {
            if (_quantityAvailable >= 0)
            {
                _quantityAvailable -= 1;
                _quantityMounted += 1;
                OnPropertyChanged("QuantityAvailable");
                OnPropertyChanged("QuantityMounted");
            }
            else
                throw new Exception("No Block Available to Mount");
        }

        public void AddNewPosition(Position position)
        {
            if (_positions == null)
                Positions = new List<Position>();
            int i = 0;
            if (_positions.Count > 0)
            {
                _positions.OrderBy(a => a.BlockPosition.ID);
                foreach (Position pos in _positions)
                {
                    i = pos.BlockPosition.ID;
                }
            }

            position.BlockPosition.ID += i + 1;
            Positions.Add(position);
        }

        public void DeletePosition(Position position)
        {
            if (_positions != null)
            {
                if (_positions.Contains(position))
                {
                    Positions.Remove(position);

                    _positions.OrderBy(a => a.BlockPosition.ID);

                    int i = 1;

                    foreach (Position pos in _positions)
                    {
                        pos.BlockPosition.ID = i;
                        i++;
                    }
                }
            }
        }

        public void UnMountBlock()
        {
            if (_quantityMounted > 0)
            {
                _quantityAvailable += 1;
                _quantityMounted -= 1;
                OnPropertyChanged("QuantityAvailable");
                OnPropertyChanged("QuantityMounted");
            }
        }

        #endregion

        //public delegate void BlockPositionAddRemovedHandler(object source, PositionAddRemoveChangedEventArgs args);
        //public event BlockPositionAddRemovedHandler BlockPositionAddRemove;

        //public static explicit operator MountedBlockAssembly(BlockAssembly blockAssembly)
        //{
        //    return new MountedBlockAssembly(blockAssembly);
        //}
    }
}
