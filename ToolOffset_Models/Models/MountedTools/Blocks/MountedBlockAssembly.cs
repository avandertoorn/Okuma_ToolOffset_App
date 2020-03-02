using System.Collections.ObjectModel;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Core;
using ToolOffset_Models.Models.Lathe;
using ToolOffset_Models.Models.MountedTools.Positions;
using ToolOffset_Models.Models.Tools;

namespace ToolOffset_Models.Models.MountedTools.Blocks
{
    public abstract class MountedBlockAssembly : ObservableBase, IMountedBlockAssembly
    {
        public MountedBlockAssembly(Block blockAssembly, Station station)
        {
            _block = blockAssembly.Block;
            OnPropertyChanged("Block");
            Positions = new ObservableCollection<IMountedPosition>();
            Station = station;
        }

        public Station Station { get; }

        private readonly Block _block;
        public Block Block { get => _block; }

        private ObservableCollection<IMountedPosition> _positions;
        public ObservableCollection<IMountedPosition> Positions
        {
            get => _positions;
            protected set => _positions = value;
        }

        public void RemovePosition(IMountedPosition position)
        {
            if (_positions.Contains(position))
            {
                position.UnMountTool();
                _positions.Remove(position);
            }
        }

        public abstract BlockOrientation BlockOrientation { get; }

        public abstract void AddPosition(Position position);
    }
}
