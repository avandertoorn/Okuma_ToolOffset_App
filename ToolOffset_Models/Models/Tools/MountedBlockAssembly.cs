using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolOffset_Models.Core;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Tools;

namespace ToolOffset_Models.Models.Tools
{
    public class MountedBlockAssembly : ObservableBase
    {
        private Block _block;
        private List<MountedPosition> _positions;
        private BlockOrientation _blockOrientation;

        public Block Block
        {
            get { return _block; }
            set
            {
                if (value != _block)
                {
                    _block = value;
                    OnPropertyChanged("Block");
                }
            }
        }

        public List<MountedPosition> Positions
        {
            get { return _positions; }
            set
            {
                if (value != _positions)
                {
                    _positions = value;
                    OnPropertyChanged("Positions");
                }
            }
        }

        public BlockOrientation BlockOrientation
        {
            get { return _blockOrientation; }
            set
            {
                if (value != _blockOrientation)
                {
                    _blockOrientation = value;
                    OnPropertyChanged("BlockOrientation");
                }
            }
        }
    }
}
