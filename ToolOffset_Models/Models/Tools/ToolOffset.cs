using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolOffset_Models.Core;
using ToolOffset_Models.Enumerations;

namespace ToolOffset_Models.Models.Tools
{
    public class ToolOffset : ObservableBase
    {
        public int _id;
        public string _name;
        private double _length;
        private double _width;
        private double _xRadiusOffset;
        private double _zRadiusOffset;
        private RadiusCompPattern _radiusCompPattern;

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

        public ToolOffset() { }

        public ToolOffset(int id, string name, double length, double width, double xRadius, double zRadius, RadiusCompPattern compPattern)
        {
            ID = id;
            Name = name;
            Length = length;
            Width = width;
            XRadiusOffset = xRadius;
            ZRadiusOffset = zRadius;
            RadiusCompPattern = compPattern;
        }
    }
}
