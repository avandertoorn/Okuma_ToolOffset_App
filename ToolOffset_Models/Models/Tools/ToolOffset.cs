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

        public int ID
        {
            get { return _id; }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("ID");
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

        private double _length;

        public double Length
        {
            get { return _length; }
            set
            {
                if (_length != value)
                {
                    _length = value;
                    OnPropertyChanged("Length");
                }
            }
        }

        private double _width;

        public double Width
        {
            get { return _width; }
            set
            {
                if (_width != value)
                {
                    _width = value;
                    OnPropertyChanged("Width");
                }
            }
        }

        private double _xRadiusOffset;

        public double XRadiusOffset
        {
            get { return _xRadiusOffset; }
            set
            {
                if (_xRadiusOffset != value)
                {
                    _xRadiusOffset = value;
                    OnPropertyChanged("XRadiusOffset");
                }
            }

        }

        private double _zRadiusOffset;

        public double ZRadiusOffset
        {
            get { return _zRadiusOffset; }
            set
            {
                if (_zRadiusOffset != value)
                {
                    _zRadiusOffset = value;
                    OnPropertyChanged("ZRadiusOffset");
                }
            }

        }

        private RadiusCompPattern _radiusCompPattern;

        public RadiusCompPattern RadiusCompPattern
        {
            get { return _radiusCompPattern; }
            set
            {
                if (_radiusCompPattern != value)
                {
                    _radiusCompPattern = value;
                    OnPropertyChanged("RadiusCompPattern");
                }
            }

        }

        public void ToolOffsetUpdatedNotify()
        {
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
