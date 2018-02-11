using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using ToolOffset_Models.Core;

namespace ToolOffset_Models.Models.Tools
{
    public class BlockAssembly : ObservableBase, IDataErrorInfo
    {
        private Block _block;
        private ObservableCollection<Position> _positions;
        private int _quantity = 1;
        private int _quantityMounted = 0;
        private int _quantityAvailable;

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

                }
            }
        }

        public int QuantityMounted
        {
            get { return _quantityMounted; }
        }

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
                        error = ValidateCustomerName();
                        break;
                }

                return error;
            }
        }

        private string ValidateCustomerName()
        {
            if (Quantity <= 0)
                return "Cannot be zero or negative";
            else if (Quantity < QuantityMounted)
                return "Unmount Tool First";

            return null;
        }

        public void MountBlock()
        {
            if (_quantityAvailable >= 0)
            {
                _quantityAvailable -= 1;
                _quantityMounted += 1;
            }
            else
                throw new Exception("No Tool Available to Mount");
        }

        #endregion

#region Public Methods
        public void AddNewPosition(Position position)
        {
            if (_positions == null)
                Positions = new ObservableCollection<Position>();
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
            }
        }

#endregion

        public BlockAssembly() { }

        public BlockAssembly(Block block)
        {
            Block = block;
        }

        public BlockAssembly(Block block, List<Position> positions)
        {
            Block = block;
            if (positions != null)
                Positions = new ObservableCollection<Position>(positions);
            else
                Positions = new ObservableCollection<Position>();
        }

        public static explicit operator MountedBlockAssembly(BlockAssembly blockAssembly)
        {
            List<Position> tempList = new List<Position>(blockAssembly.Positions);
            return new MountedBlockAssembly
            {
                Block = blockAssembly.Block,
                Positions = tempList.ConvertAll(
                    new Converter<Position, MountedPosition>(a => (MountedPosition)a)).ToList()
            };
        }
    }
}
