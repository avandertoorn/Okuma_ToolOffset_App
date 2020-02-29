using System;
using System.Collections.ObjectModel;
using ToolOffset_Models.EventArg;
using ToolOffset_Models.Models.Core;
using ToolOffset_Models.Models.MountedTools.Blocks;
using ToolOffset_Models.Models.MountedTools.Offsets;
using ToolOffset_Models.Models.Tools;

namespace ToolOffset_Models.Models.MountedTools.Positions
{
    public abstract class MountedPosition : ObservableBase, IMountedPosition
    {
        public MountedPosition(Position position, MountedBlockAssembly mountedBlockAssembly)
        {
            _blockPosition = position.BlockPosition;
            OnPropertyChanged("BlockPosition");
            ParentMountedBlockAssembly = mountedBlockAssembly;
            _mountedToolOffsets = new ObservableCollection<IMountedToolOffset>();
            OnPropertyChanged("MountedToolOffsets");
        }

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

        public abstract double MountedXOffset { get; }
        public abstract double MountedYOffset { get; }
        public abstract double MountedZOffset { get; }

        public abstract void AddOffset(IMountedToolOffset toolOffset);

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
}
