using ToolOffset_Models.Models.Core;

namespace ToolOffset_Models.Models.Tools
{
    public class Position : ObservableBase
    {
        public Position(BlockPosition blockPosition)
        {
            BlockPosition = blockPosition;
        }

        private BlockPosition _blockPosition;

        public BlockPosition BlockPosition
        {
            get { return _blockPosition; }
            private set
            {
                if (value != _blockPosition)
                {
                    _blockPosition = value;
                    OnPropertyChanged("BlockPosition");
                }
            }
        }
    }
}