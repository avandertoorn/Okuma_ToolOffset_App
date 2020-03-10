using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ToolOffset_Models.Models.Lathe
{
    public class MountedBlock
    {
        public int Id { get; set; }
        public List<MountedPosition> Positions { get; set; }

    }
}
