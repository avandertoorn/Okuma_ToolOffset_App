using Newtonsoft.Json;
using System;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Core;
using ToolOffset_Models.Models.Shared;

namespace ToolOffset_Models.Models
{
    public class ToolOffset : ObservableBase
    {
        public ToolOffset() { }

        public ToolOffset(Guid id, string name, ToolOffsetValue offset)
        {
            Id = id;
            Name = name;
            Offset = offset;
        }


        public Guid _id;
        [JsonProperty]
        public Guid Id
        {
            get { return _id; }
            private set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }


        public string _name;
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


        private ToolOffsetValue _offset;
        [JsonProperty]
        public ToolOffsetValue Offset
        {
            get { return _offset; }
            private set
            {
                if(value != _offset)
                {
                    _offset = value;
                    OnPropertyChanged("Offset");
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
