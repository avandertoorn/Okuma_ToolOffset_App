using System.Collections.ObjectModel;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Core;
using ToolOffset_Models.Models.Lathe;
using ToolOffset_Models.Models.MountedTools.Positions;
using ToolOffset_Models.Models.Tools;

namespace ToolOffset_Models.Models.MountedTools.Blocks
{
    public class MountedBlock : ObservableBase
    {
        public MountedBlock(BlockAssembly blockAssembly, Station station, BlockOrientation orientation)
        {
            _block = blockAssembly.Block;
            OnPropertyChanged("Block");
            Positions = new ObservableCollection<IMountedPosition>();
            Station = station;
            switch (orientation)
            {
                case BlockOrientation.Foward:
                    _orientationStrategy = new BlockFowardStrategy();
                    break;
                case BlockOrientation.Reverse:
                    _orientationStrategy = new BlockReverseStrategy();
                    break;
            }
        }

        private IBlockOrientationStrategy _orientationStrategy;

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

        public void AddPosition(Position position)
        {
            Positions.Add(_orientationStrategy.AddPosition(position));
        }

        public BlockOrientation BlockOrientation => _orientationStrategy.BlockOrientation;
    }

    public interface IBlockOrientationStrategy
    {
        IMountedPosition AddPosition(Position position);
        BlockOrientation BlockOrientation { get; }
    }

    public class BlockFowardStrategy : IBlockOrientationStrategy
    {
        public BlockOrientation BlockOrientation => BlockOrientation.Foward;

        public IMountedPosition AddPosition(Position position)
        {
            throw new System.NotImplementedException();
        }
    }

    public class BlockReverseStrategy : IBlockOrientationStrategy
    {
        public BlockOrientation BlockOrientation => BlockOrientation.Reverse;

        public IMountedPosition AddPosition(Position position)
        {
            throw new System.NotImplementedException();
        }
    }
}
