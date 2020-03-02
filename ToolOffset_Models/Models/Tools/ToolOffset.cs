using Newtonsoft.Json;
using System;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Core;

namespace ToolOffset_Models.Models
{
    public class ToolOffset : ObservableBase
    {
        public ToolOffset() { }

        public ToolOffset(int id, string name,
            double length, double width, double xRadius,
            double zRadius, RadiusCompPattern compPattern)
        {
            ID = id;
            Name = name;
            Length = length;
            Width = width;
            XRadiusOffset = xRadius;
            ZRadiusOffset = zRadius;
            RadiusCompPattern = compPattern;
        }


        public int _id;
        [JsonProperty]
        public int ID
        {
            get { return _id; }
            private set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("ID");
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


        private double _length;
        [JsonProperty]
        public double Length
        {
            get { return _length; }
            private set
            {
                if (_length != value)
                {
                    _length = value;
                    OnPropertyChanged("Length");
                }
            }
        }


        private double _width;
        [JsonProperty]
        public double Width
        {
            get { return _width; }
            private set
            {
                if (_width != value)
                {
                    _width = value;
                    OnPropertyChanged("Width");
                }
            }
        }


        private double _xRadiusOffset;
        [JsonProperty]
        public double XRadiusOffset
        {
            get { return _xRadiusOffset; }
            private set
            {
                if (_xRadiusOffset != value)
                {
                    _xRadiusOffset = value;
                    OnPropertyChanged("XRadiusOffset");
                }
            }

        }


        private double _zRadiusOffset;
        [JsonProperty]
        public double ZRadiusOffset
        {
            get { return _zRadiusOffset; }
            private set
            {
                if (_zRadiusOffset != value)
                {
                    _zRadiusOffset = value;
                    OnPropertyChanged("ZRadiusOffset");
                }
            }

        }


        private RadiusCompPattern _radiusCompPattern;
        [JsonProperty]
        public RadiusCompPattern RadiusCompPattern
        {
            get { return _radiusCompPattern; }
            private set
            {
                if (_radiusCompPattern != value)
                {
                    _radiusCompPattern = value;
                    OnPropertyChanged("RadiusCompPattern");
                }
            }

        }

        public void UpdateOffset(
            double length, double width, double xRadius,
            double zRadius, RadiusCompPattern compPattern)
        {
            Length = length;
            Width = width;
            XRadiusOffset = xRadius;
            ZRadiusOffset = zRadius;
            RadiusCompPattern = compPattern;
            OnToolOffsetChanged();
        }

        public delegate void ToolOffsetChangedHandler(ToolOffset source, EventArgs args);
        public event ToolOffsetChangedHandler ToolOffsetChanged;

        protected virtual void OnToolOffsetChanged()
        {
            ToolOffsetChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
