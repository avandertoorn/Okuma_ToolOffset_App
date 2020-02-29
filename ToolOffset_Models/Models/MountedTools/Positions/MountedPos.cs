using System;
using System.Collections.ObjectModel;
using ToolOffset_Models.EventArg;
using ToolOffset_Models.Models.Core;
using ToolOffset_Models.Models.MountedTools.Blocks;
using ToolOffset_Models.Models.MountedTools.Offsets;
using ToolOffset_Models.Models.Tools;

namespace ToolOffset_Models.Models.MountedTools.Positions
{
    public class MountedPos : ObservableBase, IMountedPosition
    {
        public MountedPos(Position position, MountedBlockAssembly mountedBlockAssembly, IPositionOrientationStrategy positionOrientationStrategy)
        {
            _blockPosition = position.BlockPosition;
            OnPropertyChanged("BlockPosition");
            ParentMountedBlockAssembly = mountedBlockAssembly;
            _mountedToolOffsets = new ObservableCollection<IMountedToolOffset>();
            OnPropertyChanged("MountedToolOffsets");
            _orientationStrategy = positionOrientationStrategy;
        }

        private IPositionOrientationStrategy _orientationStrategy;

        public IMountedBlockAssembly ParentMountedBlockAssembly { get; }

        private BlockPosition _blockPosition;
        public BlockPosition BlockPosition { get => _blockPosition; }

        private Tool _tool;
        public Tool Tool { get => _tool; }

        private ObservableCollection<IMountedToolOffset> _mountedToolOffsets;
        public ObservableCollection<IMountedToolOffset> MountedToolOffsets { get => _mountedToolOffsets; }

        public void MountTool(Tool tool)
        {
            if (Tool != null)
                UnMountTool();

            _tool = tool;
            OnPropertyChanged("Tool");
            OnToolMounted();
        }

        public void UnMountTool()
        {
            RemoveAllOffsets();
            OnToolUnMounting();
            _tool = null;
            OnPropertyChanged("Tool");
        }

        public double MountedXOffset { get => _orientationStrategy.XOffset; }
        public double MountedYOffset { get => _orientationStrategy.YOffset; }
        public double MountedZOffset { get => _orientationStrategy.ZOffset; }

        public void AddOffset(IMountedToolOffset toolOffset)
        {
            MountedToolOffsets.Add(_orientationStrategy.AddOffset(toolOffset));
        }

        public void RemoveOffset(IMountedToolOffset toolOffset)
        {
            if (MountedToolOffsets.Contains(toolOffset))
            {
                OnOffsetRemoving(toolOffset);
                MountedToolOffsets.Remove(toolOffset);
            }
        }

        private void RemoveAllOffsets()
        {
            for (int i = MountedToolOffsets.Count - 1; i >= 0; i--)
                RemoveOffset(MountedToolOffsets[i]);
        }

        public event EventHandler ToolMounted;
        public event EventHandler ToolUnmounting;
        public event EventHandler<MountedOffsetAddRemoveEventArgs> OffsetAdded;
        public event EventHandler<MountedOffsetAddRemoveEventArgs> OffsetRemoving;

        protected virtual void OnToolMounted()
        {
            ToolMounted?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnToolUnMounting()
        {
            ToolUnmounting?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnOffsetAdded(IMountedToolOffset offset)
        {
            OffsetAdded?.Invoke(this, new MountedOffsetAddRemoveEventArgs(offset));
        }

        protected virtual void OnOffsetRemoving(IMountedToolOffset offset)
        {
            OffsetRemoving?.Invoke(this, new MountedOffsetAddRemoveEventArgs(offset));
        }
    }

    public interface IPositionOrientationStrategy
    {
        IMountedToolOffset AddOffset(IMountedToolOffset toolOffset);
        double XOffset { get; }
        double YOffset { get; }
        double ZOffset { get; }
    }

    public abstract class PositionOrientationStratageyBase : IPositionOrientationStrategy
    {
        public PositionOrientationStratageyBase(BlockPosition blockPosition)
        {
            _blockPosition = blockPosition;
        }

        protected readonly BlockPosition _blockPosition;

        public abstract double XOffset { get; }
        public abstract double YOffset { get; }
        public abstract double ZOffset { get; }
        public abstract IMountedToolOffset AddOffset(IMountedToolOffset toolOffset);
    }

    public class PositionFoward : PositionOrientationStratageyBase
    {
        public PositionFoward(BlockPosition blockPosition)
            : base(blockPosition)
        {
        }

        public override double XOffset => _blockPosition.XOffset;
        public override double YOffset => _blockPosition.YOffset;
        public override double ZOffset => _blockPosition.ZOffset;

        public override IMountedToolOffset AddOffset(IMountedToolOffset toolOffset)
        {
            throw new NotImplementedException();
        }
    }

    public class PositionReverse : PositionOrientationStratageyBase
    {
        public PositionReverse(BlockPosition blockPosition)
            : base(blockPosition)
        {
        }

        public override double XOffset => _blockPosition.XOffset;
        public override double YOffset => _blockPosition.YOffset * -1;
        public override double ZOffset => _blockPosition.ZOffset;

        public override IMountedToolOffset AddOffset(IMountedToolOffset toolOffset)
        {
            throw new NotImplementedException();
        }
    }
}
