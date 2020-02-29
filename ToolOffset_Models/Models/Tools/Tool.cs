using System.Collections.Generic;
using System.Collections.ObjectModel;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Core;

namespace ToolOffset_Models.Models.Tools
{
    public class Tool : ObservableBase
    {
        public Tool(IEnumerable<ToolOffset> toolOffsets)
        {
            ToolOffsets = new ObservableCollection<ToolOffset>(toolOffsets);
        }

        public Tool(int toolNo, string name,
            string comment, ToolType toolType,
            int toolOffsetDefault, int quantity)
        {
            ToolNo = toolNo;
            Name = name;
            Comment = comment;
            ToolType = toolType;
            ToolOffsetDefault = toolOffsetDefault;
            _quantity = quantity;
            _toolOffsets = new ObservableCollection<ToolOffset>();
        }

        public Tool(int toolNo, string name,
            string comment, ToolType toolType,
            IEnumerable<ToolOffset> toolOffsets,
            int toolOffsetDefault, int quantity)
            : this(toolNo, name, comment, toolType, toolOffsetDefault, quantity)
        {

            if (toolOffsets != null)
                ToolOffsets = new ObservableCollection<ToolOffset>(toolOffsets);
            else
                ToolOffsets = new ObservableCollection<ToolOffset>();
        }

        private int _toolNo;
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

        private string _name;
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

        private string _comment;
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

        private ToolType _toolType;
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

        private ObservableCollection<ToolOffset> _toolOffsets;
        public ObservableCollection<ToolOffset> ToolOffsets
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

        private int _toolOffsetDefault = 1;
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

        public override string ToString()
        {
            return this.Name + " Tool No:" + this.ToolNo.ToString();
        }
    }
}

