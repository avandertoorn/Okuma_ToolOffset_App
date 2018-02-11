using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolOffset_LatheUtilities.Interfaces;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Machine;
using ToolOffset_Models.Models.Tools;

namespace ToolOffset_LatheUtilities.LatheModels
{
    public class SimulationLathe : IOkumaLathe
    {
        private SimulationLatheRepository latheRepository;

        public SimulationLathe()
        {
            latheRepository = new SimulationLatheRepository();
            if (!LatheSpecs.LatheSpecsInitialized)
                LatheSpecs.Initialize(Enums.LatheType.Simulation);
        }

        public void Close()
        {

        }

        public MachineToolOffset GetOffset(MachineToolOffset toolOffset, SubSystem subSystem)
        {
            return latheRepository.GetOffset(toolOffset.ID);
        }

        public void SetOffset(MachineToolOffset offset, bool zeroWearOffset, SubSystem subSystem)
        {
            latheRepository.Update(offset, zeroWearOffset);
        }

        public void AttachTool(int station, Tool tool, ToolLocation turret)
        {

        }

        public void DetachTool(int station, ToolLocation turret)
        {

        }

        public int GetToolNo(int station)
        {
            return 1;
        }

        private void UpdateAllToolOffets()
        {

        }
    }
}
