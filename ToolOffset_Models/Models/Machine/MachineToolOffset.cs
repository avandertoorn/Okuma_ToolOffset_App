using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolOffset_Models.Core;
using ToolOffset_Models.Enumerations;

namespace ToolOffset_Models.Models.Machine
{
    public class MachineToolOffset : ObservableBase
    {
        private int _id;
        private double _xOffset;
        private double _yOffset;
        private double _zOffset;
        private double _xRadiusOffset;
        private double _zRadiusOffset;
        private int _radiusCompPattern;
        private double _xWearOffset;
        private double _zWearOffset;

        public int ID
        {
            get { return _id;}
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("ID");
                }
            }
        }

        public double XOffset
        {
            get { return _xOffset;}
            set
            {
                if (value != _xOffset)
                {
                    _xOffset = value;
                    OnPropertyChanged("XOffset");
                }
            }
        }

        public double YOffset
        {
            get { return _yOffset; }
            set
            {
                if (value != _yOffset)
                {
                    _yOffset = value;
                    OnPropertyChanged("YOffset");
                }
            }
        }

        public double ZOffset
        {
            get { return _zOffset; }
            set
            {
                if (value != _zOffset)
                {
                    _zOffset = value;
                    OnPropertyChanged("ZOffset");
                }
            }
        }

        public double XRadiusOffset
        {
            get { return _xRadiusOffset;}
            set
            {
                if (value != _xRadiusOffset)
                {
                    _xRadiusOffset = value;
                    OnPropertyChanged("XRadiusOffset");
                }
            }
        }

        public double ZRadiusOffset
        {
            get { return _zRadiusOffset;}
            set
            {
                if (value != _zRadiusOffset)
                {
                    _zRadiusOffset = value;
                    OnPropertyChanged("ZRadiusOffset");
                }

            }

        }

        public int RadiusCompPattern
        {
            get { return _radiusCompPattern;}
            set
            {
                if (value != _radiusCompPattern)
                {
                    _radiusCompPattern = value;
                    OnPropertyChanged("RadiusCompPattern");
                }
            }
        }

        public double XWearOffset
        {
            get { return _xWearOffset;}
            set
            {
                if (value != _xWearOffset)
                {
                    _xWearOffset = value;
                    OnPropertyChanged("XWearOffset");
                }
            }
        }

        public double ZWearOffset
        {
            get { return _zWearOffset;}
            set
            {
                if (value != _zWearOffset)
                {
                    _zWearOffset = value;
                    OnPropertyChanged("ZWearOffset");
                }
            }
        }

        public MachineToolOffset() { }

        public MachineToolOffset(int id)
        {
            ID = id;
        }

        public void SetOffset(double x, double y, double z, double xRadius, double zRadius, int pattern, double xWear, double zWear)
        {
            XOffset = x;
            YOffset = y;
            ZOffset = z;
            XRadiusOffset = xRadius;
            ZRadiusOffset = zRadius;
            RadiusCompPattern = pattern;
            XWearOffset = xWear;
            ZWearOffset = zWear;
        }
    }
}
