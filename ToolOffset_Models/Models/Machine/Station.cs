using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolOffset_Models.Core;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Tools;

namespace ToolOffset_Models.Models.Machine
{

    public class Station : ObservableBase
    {
        private int _id;
        private MountedBlockAssembly _toolBlock;

        public int ID
        {
            get { return _id; }
        }

        public MountedBlockAssembly ToolBlock
        {
            get { return _toolBlock; }
            set
            {
                if (value != _toolBlock)
                    _toolBlock = value;
                OnPropertyChanged("ToolBlock");
            }
        }

        public Station(int id)
        {
            _id = id;
        }

        public void MountToolBlock(BlockAssembly toolblock, BlockOrientation orientation)
        {
            if (_toolBlock == null)
                _toolBlock = new MountedBlockAssembly();

            ToolBlock = (MountedBlockAssembly)toolblock;
            ToolBlock.BlockOrientation = orientation;
        }

        public void UnMountToolBlock()
        {

            ToolBlock = new MountedBlockAssembly();
        }
    }

}
