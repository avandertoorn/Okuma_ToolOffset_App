using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Core;
using ToolOffset_Models.Models.MountedTools.Positions;

namespace ToolOffset_Models.Models.MountedTools.Offsets
{
    public class MountedToolOffs : ObservableBase, IMountedToolOffset
    {
        public MountedToolOffs(ToolOffset toolOffset,
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

        public ToolOffsetSide ToolOffsetSide { get; }
        public double MountedXOffset { get; }
        public double MountedYOffset { get; }
        public double MountedZOffset { get; }
        public double XRadiusOffset { get; }
        public double ZRadiusOffset { get; }
        public RadiusCompPattern MountedPattern { get; }
    }
}
