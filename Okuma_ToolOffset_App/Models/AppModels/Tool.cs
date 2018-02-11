using Okuma_ToolOffset_App.Models.AppModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okuma_ToolOffset_App.Models.AppModels
{
    public class Tool
    {
        private int _toolNo;
        private string _name;
        private string _comment;
        private double _length;
        private double _width;
        private double _xRadiusOffset;
        private double _zRadiusOffset;
        private int _radiusCompPattern;
        private ToolTypeEnum _toolType;

        public int ToolNo
        {
            set
            {
                if (_toolNo != value)
                    _toolNo = value;
            }
            get { return _toolNo; }
        }

        public string Name
        {
            set
            {
                if (_name != value)
                    _name = value;
            }
            get { return _name; }
        }

        public string Comment
        {
            set
            {
                if (_comment != value)
                    _comment = value;
            }
            get { return _name; }
        }

        public double Length
        {
            set
            {
                if (_length != value)
                    _length = value;
            }
            get { return _length; }
        }

        public double Width
        {
            set
            {
                if (_width != value)
                    _width = value;
            }
            get { return _width; }
        }

        public double XRadiusOffset
        {
            set
            {
                if (_xRadiusOffset != value)
                    _xRadiusOffset = value;
            }
            get { return _xRadiusOffset; }
        }

        public double ZRadiusOffset
        {
            set
            {
                if (_zRadiusOffset != value)
                    _zRadiusOffset = value;
            }
            get { return _zRadiusOffset; }
        }

        public int RadiusCompPattern
        {
            set
            {
                if (_radiusCompPattern != value)
                {
                    if (value <= 9 && value >= 0)
                        _radiusCompPattern = value;
                }
            }
            get { return _radiusCompPattern; }
        }

        public ToolTypeEnum ToolType
        {
            set
            {
                if (_toolType != value)
                    _toolType = value;
            }
            get { return _toolType; }
        }

        public override string ToString()
        {
            return this.Name + " Tool No:" + this.ToolNo.ToString();
        }
    }
}
