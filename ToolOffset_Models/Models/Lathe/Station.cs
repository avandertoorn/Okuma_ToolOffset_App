﻿using System;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Core;
using ToolOffset_Models.Models.MountedTools.Blocks;
using ToolOffset_Models.Models.Tools;

namespace ToolOffset_Models.Models.Lathe
{

    public class Station : ObservableBase
    {
        public Station(int id, Turret turret)
        {
            _id = id;
            Turret = turret;
        }

        public readonly Turret Turret;

        private int _id;
        public int ID { get => _id; }

        private IMountedBlockAssembly _toolBlock;
        public IMountedBlockAssembly ToolBlock
        {
            get { return _toolBlock; }
            private set
            {
                if (value != _toolBlock)
                {
                    _toolBlock = value;
                    OnPropertyChanged("ToolBlock");
                }
            }
        }

        public delegate void BlockMountedEventHandler(Station sender, EventArgs e);
        public event BlockMountedEventHandler BlockMounted;

        public delegate void BlockUnMountingEventHander(Station sender, EventArgs e);
        public event BlockUnMountingEventHander BlockUnMounting;

        public void MountToolBlock(Block toolblock, BlockOrientation orientation)
        {
            if (toolblock == null)
            {
                ToolBlock = null;
                return;
            }

            //TODO
            ToolBlock = new ForwardMountedBlockAssembly(toolblock, this);
            OnBlockMounted();
        }

        public void UnMountToolBlock()
        {
            if (ToolBlock != null)
            {
                foreach (var position in ToolBlock.Positions)
                    position.UnMountTool();

                OnBlockUnMounting();
                ToolBlock = null;
            }
        }

        protected virtual void OnBlockMounted()
        {
            BlockMounted?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnBlockUnMounting()
        {
            BlockUnMounting?.Invoke(this, EventArgs.Empty);
        }
    }

}
