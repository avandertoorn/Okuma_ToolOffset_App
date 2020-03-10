﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Core;

namespace ToolOffset_Models.Models.Tools
{
    public class Tool : ObservableBase
    {
        [JsonConstructor]
        public Tool(Guid id, int toolNo, string name,
            string comment, ToolType toolType,
            IEnumerable<ToolOffset> toolOffsets,
            Guid toolOffsetDefault, int quantity)
        {
            Id = id;
            ToolNo = toolNo;
            Name = name;
            Comment = comment;
            ToolType = toolType;
            ToolOffsetDefault = toolOffsetDefault;
            Quantity = quantity;
            if (toolOffsets != null)
            {
                _toolOffsets = new ObservableCollection<ToolOffset>(toolOffsets);
                ToolOffsets = new ReadOnlyObservableCollection<ToolOffset>(_toolOffsets);
            }
            else
            {
                _toolOffsets = new ObservableCollection<ToolOffset>();
                ToolOffsets = new ReadOnlyObservableCollection<ToolOffset>(_toolOffsets);
            }
        }


        private Guid _id;
        [JsonProperty]
        public Guid Id
        {
            get { return _id; }
            private set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }


        private int _toolNo;
        [JsonProperty]
        public int ToolNo
        {
            get { return _toolNo; }
            private set
            {
                if (_toolNo != value)
                {
                    _toolNo = value;
                    OnPropertyChanged("ToolNo");
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
                if (_name != value)
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
                if (_comment != value)
                {
                    _comment = value;
                    OnPropertyChanged("Comment");
                }
            }
        }


        private ToolType _toolType;
        [JsonProperty]
        public ToolType ToolType
        {
            get { return _toolType; }
            private set
            {
                if (_toolType != value)
                {
                    _toolType = value;
                    OnPropertyChanged("ToolType");
                }
            }
        }

        
        private ObservableCollection<ToolOffset> _toolOffsets;
        private ReadOnlyObservableCollection<ToolOffset> _readOnlyToolOffsets;
        [JsonProperty]
        public ReadOnlyObservableCollection<ToolOffset> ToolOffsets
        {
            get { return _readOnlyToolOffsets; }
            private set
            {
                if (value != _readOnlyToolOffsets)
                {
                    _readOnlyToolOffsets = value;
                    OnPropertyChanged("ToolOffsets");
                }
            }
        }


        private Guid _toolOffsetDefault;
        [JsonProperty]
        public Guid ToolOffsetDefault
        {
            get { return _toolOffsetDefault; }
            private set
            {
                if (value != _toolOffsetDefault)
                {
                    _toolOffsetDefault = value;
                    OnPropertyChanged("ToolOffsetDefault");
                }
            }
        }


        private int _quantity = 1;
        [JsonProperty]
        public int Quantity
        {
            get { return _quantity; }
            private set
            {
                if (value != _quantity)
                {
                    _quantity = value;
                    OnPropertyChanged("Quantity");
                }
            }
        }
    }
}

