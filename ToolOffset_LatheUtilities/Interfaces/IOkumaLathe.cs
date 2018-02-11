using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Machine;
using ToolOffset_Models.Models.Tools;

namespace ToolOffset_LatheUtilities.Interfaces
{
    public interface IOkumaLathe
    {
        void Close();
        MachineToolOffset GetOffset(MachineToolOffset toolOffset, SubSystem subSystem);
        void SetOffset(MachineToolOffset offset, bool zeroWearOffset, SubSystem subSystem);
        void AttachTool(int station, Tool tool, ToolLocation turret);
        void DetachTool(int station, ToolLocation turret);
        int GetToolNo(int station);
    }
}
