using System;
using ToolOffset_Models.Models.Core;
using ToolOffset_Models.Models.Shared;

namespace ToolOffset_Models.Models.Lathe
{
    public class MountedToolOffset : ObservableBase
    {
        public Guid _id;
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
        public ToolOffsetValue Offset
        {
            get { return _offset; }
            private set
            {
                if (value != _offset)
                {
                    _offset = value;
                    OnPropertyChanged("Offset");
                }
            }
        }

        private int _machineOffsetId;
        public int MachineOffsetId
        {
            get { return _machineOffsetId; }
            private set
            {
                if(value != _machineOffsetId)
                {
                    _machineOffsetId = value;
                    OnPropertyChanged("MachineOffsetId");
                }
            }
        }

        public void UpdateOffset(ToolOffsetValue offset)
        {
            Offset = offset;
            //TODO
        }
    }
}