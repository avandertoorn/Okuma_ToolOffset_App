using System;
using ToolOffset_Models.Models.Core;
using ToolOffset_Models.Models.Shared;

namespace ToolOffset_Models.Models.Tools
{
    public class ToolOffset : ObservableBase
    {
        public ToolOffset() { }

        public ToolOffset(int id, string name, ToolOffsetValue offset)
        {
            Id = id;
            Name = name;
            Offset = offset;
        }


        public int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }


        public string _name;
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


        private ToolOffsetValue _offset;
        public ToolOffsetValue Offset
        {
            get { return _offset; }
            set
            {
                if(value != _offset)
                {
                    _offset = value;
                    OnPropertyChanged("Offset");
                }
            }
        }


        private Tool _tool;
        public Tool Tool
        {
            get { return _tool; }
            set
            {
                if(value != _tool)
                {
                    _tool = value;
                    OnPropertyChanged("Tool");
                }
            }
        }


        private int _toolId;
        public int ToolId
        {
            get { return _toolId; }
            set
            {
                if (value != _toolId)
                {
                    _toolId = value;
                    OnPropertyChanged("ToolId");
                }
            }
        }

        public void UpdateOffset(ToolOffsetValue offset)
        {
            Offset = offset;
            OnToolOffsetChanged();
            //TODO
        }

        public void ChangeName(string name)
        {
            if (name == null)
                throw new ArgumentNullException("Offset Name");
            if (name == string.Empty)
                throw new ArgumentException("Offset name may not be empty");

            Name = name;
        }

        public delegate void ToolOffsetChangedHandler(ToolOffset source, EventArgs args);
        public event ToolOffsetChangedHandler ToolOffsetChanged;

        protected virtual void OnToolOffsetChanged()
        {
            ToolOffsetChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
