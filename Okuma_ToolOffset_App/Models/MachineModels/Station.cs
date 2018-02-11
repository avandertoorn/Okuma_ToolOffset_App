using Okuma_ToolOffset_App.Models.AppModels;
using Okuma_ToolOffset_App.Models.AppModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okuma_ToolOffset_App.Models.MachineModels
{
    public class Station
    {
        private int _id;
        private MountedToolBlock _toolBlock;

        public int ID
        {
            get { return _id; }
        }

        public MountedToolBlock ToolBlock
        {
            get { return _toolBlock; }
            set
            {
                if (value != _toolBlock)
                    _toolBlock = value;
            }
        }

        public Station(int id)
        {
            _id = id;
        }
    }
}
