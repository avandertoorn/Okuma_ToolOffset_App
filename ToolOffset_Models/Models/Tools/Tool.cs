using System.Collections.Generic;
using System.Collections.ObjectModel;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Core;

namespace ToolOffset_Models.Models.Tools
{
    public class Tool : ObservableBase
    {
        private Tool()
        {
            ToolOffsets = new ObservableCollection<ToolOffset>();
        }
        public Tool(int id, int toolNo, string name,
            string comment, ToolType toolType,
            IEnumerable<ToolOffset> toolOffsets)
        {
            Id = id;
            ToolNo = toolNo;
            Name = name;
            Comment = comment;
            ToolType = toolType;
            if (toolOffsets != null)
            {
                ToolOffsets = new ObservableCollection<ToolOffset>(toolOffsets);
            }
            else
            {
                ToolOffsets = new ObservableCollection<ToolOffset>();
            }
        }


        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
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

        private int _toolOffsetDefault;
        public int ToolOffsetDefault
        {
            get { return _toolOffsetDefault; }
            set
            {
                if(value != _toolOffsetDefault)
                {
                    _toolOffsetDefault = value;
                    OnPropertyChanged("ToolOffsetDefault");
                }
            }
        }
    }
}


