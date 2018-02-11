using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolOffset_Models.Core;
using ToolOffset_Models.Enumerations;

namespace ToolOffset_Models.Models.Tools
{
    public class Tool : ObservableBase
    {
        private int _toolNo;
        private string _name;
        private string _comment;
        private ToolType _toolType;
        private List<ToolOffset> _toolOffsets;
        private int _toolOffsetDefault = 1;
        private int _quantity = 1;
        private int _quantityMounted;
        private int _quantityAvailable;

        public int ToolNo
        {
            get { return _toolNo; }
            set
            {
                if (_toolNo != value)
                {
                    _toolNo = value;
                    OnPropertyChanged("ToolNo");
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
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
                if (_comment != value)
                {
                    _comment = value;
                    OnPropertyChanged("Comment");
                }
            }
        }

        public ToolType ToolType
        {
            get { return _toolType; }
            set
            {
                if (_toolType != value)
                {
                    _toolType = value;
                    OnPropertyChanged("ToolType");
                }
            }
        }

        public List<ToolOffset> ToolOffsets
        {
            get { return _toolOffsets; }
            set
            {
                if (value != _toolOffsets)
                {
                    _toolOffsets = value;
                    OnPropertyChanged("ToolOffsets");
                }
            }
        }

        public int ToolOffsetDefault
        {
            get { return _toolOffsetDefault; }
            set
            {
                if (value != _toolOffsetDefault)
                {
                    _toolOffsetDefault = value;
                    OnPropertyChanged("ToolOffsetDefault");
                }
            }
        }

        public int Quantity
        {
            get { return _quantity; }
        }

        public int QuantityMounted
        {
            get { return _quantityMounted; }
        }

        public int QauntityAvailable
        {
            get { return _quantityAvailable; }
        }

        public void AddNewToolOffset(ToolOffset toolOffset)
        {
            if (_toolOffsets == null)
                ToolOffsets = new List<ToolOffset>();
            int i = 0;
            if (_toolOffsets.Count > 0)
            {
                _toolOffsets.OrderBy(a => a.ID);
                foreach (ToolOffset offset in _toolOffsets)
                {
                    i = offset.ID;
                }
            }

            toolOffset.ID += i;
            ToolOffsets.Add(toolOffset);
        }

        public void DeleteToolOffset(ToolOffset toolOffset)
        {
            if (_toolOffsets != null)
            {
                if (_toolOffsets.Contains(toolOffset))
                {
                    int deletedID = toolOffset.ID;
                    if (deletedID == _toolOffsetDefault)
                        ToolOffsetDefault = 1;

                    ToolOffsets.Remove(toolOffset);

                    _toolOffsets.OrderBy(a => a.ID);

                    int i = 1;

                    foreach (ToolOffset offset in _toolOffsets)
                    {
                        if (offset.ID != i)
                        {
                            if (_toolOffsetDefault == offset.ID)
                                ToolOffsetDefault = i;
                            offset.ID = i;
                        }
                        i++;
                    }
                }
            }
        }

        public void MountTool()
        {
            if (_quantityAvailable > 0)
            {
                _quantityAvailable -= 1;
                _quantityMounted += 1;
                OnPropertyChanged("QuantityAvailable");
                OnPropertyChanged("QuantityMounted");
            }
            else
                throw new Exception("Unable To Mount");
        }

        public void UnMountTool()
        {
            if (_quantityMounted > 0)
            {
                _quantityMounted -= 1;
                _quantityAvailable += 1;
                OnPropertyChanged("QuantityAvailable");
                OnPropertyChanged("QuantityMounted");
            }
            else
                throw new Exception("Unable To Unmount");
        }

        public void AddQuantity(int quantity)
        {
            _quantity += quantity;
            _quantityAvailable = _quantity - _quantityMounted;
            OnPropertyChanged("Quantity");
            OnPropertyChanged("QuantityAvailable");
        }

        public void SubtractQuantity(int quantity)
        {
            if (_quantityAvailable >= quantity && _quantity > quantity)
            {
                _quantity -= quantity;
                _quantityAvailable = _quantity - _quantityMounted;
                OnPropertyChanged("Quantity");
                OnPropertyChanged("QuantityAvailable");
            }
            else
                throw new Exception("Not Enough Tools Available");
        }

        public Tool(int toolNo, string name, string comment, ToolType toolType, int toolOffsetDefault, int quantity)
        {
            ToolNo = toolNo;
            Name = name;
            Comment = comment;
            ToolType = toolType;
            ToolOffsetDefault = toolOffsetDefault;
            _quantity = quantity;
            _quantityAvailable = quantity;
            _toolOffsets = new List<ToolOffset>();
        }

        public Tool(int toolNo, string name, string comment, ToolType toolType, List<ToolOffset> toolOffsets, int toolOffsetDefault, int quantity)
        {
            ToolNo = toolNo;
            Name = name;
            Comment = comment;
            ToolType = toolType;
            if (toolOffsets != null)
                ToolOffsets = toolOffsets;
            else
                ToolOffsets = new List<ToolOffset>();
            ToolOffsetDefault = toolOffsetDefault;
            _quantity = quantity;
            _quantityAvailable = quantity;
        }

        public override string ToString()
        {
            return this.Name + " Tool No:" + this.ToolNo.ToString();
        }
    }
}

