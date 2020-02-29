using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Core;
using ToolOffset_Models.Models.MountedTools.Positions;

namespace ToolOffset_Models.Models.MountedTools.Offsets
{
    public abstract class MountedToolOffset : ObservableBase, IMountedToolOffset
    {
        public MountedToolOffset(ToolOffset toolOffset,
            MountedPosition mountedPosition)
        {
            ToolOffset = toolOffset;
            ParentMountedPosition = mountedPosition;
        }

        public IMountedPosition ParentMountedPosition { get; }

        private int _offsetNo;
        public int OffsetNo
        {
            get { return _offsetNo; }
            set
            {
                if (value != _offsetNo)
                {
                    _offsetNo = value;
                    OnPropertyChanged("OffsetNo");
                }
            }
        }

        private ToolOffset _toolOffset;
        public ToolOffset ToolOffset
        {
            get { return _toolOffset; }
            private set
            {
                if (value != _toolOffset)
                {
                    _toolOffset = value;
                    OnPropertyChanged("ToolOffset");
                }
            }
        }

        public abstract ToolOffsetSide ToolOffsetSide { get; }
        public abstract double MountedXOffset { get; }
        public abstract double MountedYOffset { get; }
        public abstract double MountedZOffset { get; }
        public abstract double XRadiusOffset { get; }
        public abstract double ZRadiusOffset { get; }
        public abstract RadiusCompPattern MountedPattern { get; }
    }
}