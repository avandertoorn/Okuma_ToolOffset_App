namespace ToolOffset_LatheUtilities.LatheModels
{
    public class MachineToolOffset
    {
        public MachineToolOffset() { }

        public MachineToolOffset(int id)
        {
            ID = id;
        }

        public void SetOffset(double x, double y,
            double z, double xRadius, double zRadius,
            int pattern, double xWear, double zWear)
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

        private int _id;

        public int ID
        {
            get { return _id; }
            set
            {
                if (value != _id)
                {
                    _id = value;
                }
            }
        }

        private double _xOffset;

        public double XOffset
        {
            get { return _xOffset; }
            set
            {
                if (value != _xOffset)
                {
                    _xOffset = value;
                }
            }
        }

        private double _yOffset;

        public double YOffset
        {
            get { return _yOffset; }
            set
            {
                if (value != _yOffset)
                {
                    _yOffset = value;
                }
            }
        }

        private double _zOffset;

        public double ZOffset
        {
            get { return _zOffset; }
            set
            {
                if (value != _zOffset)
                {
                    _zOffset = value;
                }
            }
        }

        private double _xRadiusOffset;

        public double XRadiusOffset
        {
            get { return _xRadiusOffset; }
            set
            {
                if (value != _xRadiusOffset)
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
                if (value != _zRadiusOffset)
                {
                    _zRadiusOffset = value;
                }

            }

        }

        private int _radiusCompPattern;

        public int RadiusCompPattern
        {
            get { return _radiusCompPattern; }
            set
            {
                if (value != _radiusCompPattern)
                {
                    _radiusCompPattern = value;
                }
            }
        }

        private double _xWearOffset;

        public double XWearOffset
        {
            get { return _xWearOffset; }
            set
            {
                if (value != _xWearOffset)
                {
                    _xWearOffset = value;
                }
            }
        }

        private double _zWearOffset;

        public double ZWearOffset
        {
            get { return _zWearOffset; }
            set
            {
                if (value != _zWearOffset)
                {
                    _zWearOffset = value;
                }
            }
        }
    }
}
