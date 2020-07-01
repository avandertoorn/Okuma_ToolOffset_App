using System;
using System.ComponentModel.DataAnnotations.Schema;
using ToolOffset_Models.Enumerations;

namespace ToolOffset_Models.Models.Shared
{
    [ComplexType]
    public class ToolOffsetValue
    {
        private ToolOffsetValue() { }
        public ToolOffsetValue(double length, double width, 
            double xRadius, double zRadius, 
            RadiusCompPattern compPattern)
        {
            double maxRad = 1;
            if (xRadius < 0)
                throw new ArgumentException("Negative XRadius value not allowed");
            if (xRadius > maxRad)
                throw new ArgumentException("XRadius too large");
            if (zRadius < 0)
                throw new ArgumentException("Negative YRadius value not allowed");
            if (zRadius > maxRad)
                throw new ArgumentException("XRadius too large");

            Length = length;
            Width = width;
            XRadiusOffset = xRadius;
            ZRadiusOffset = zRadius;
            RadiusCompPattern = compPattern;
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
                }
            }
        }


        private OffsetType _lengthType;
        public OffsetType LengthType
        {
            get { return _lengthType; }
            set
            {
                if (_lengthType != value)
                {
                    _lengthType = value;
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
                }
            }

        }
    }
}
