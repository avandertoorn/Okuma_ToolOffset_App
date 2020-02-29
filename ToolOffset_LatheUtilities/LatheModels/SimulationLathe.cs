using Gosiger.Utilities;
using ToolOffset_LatheUtilities.Enums;
using ToolOffset_LatheUtilities.Interfaces;

namespace ToolOffset_LatheUtilities.LatheModels
{
    public class SimulationLathe : IOkumaLathe
    {
        private SimulationLatheRepository latheRepository;

        public LatheSpecs LatheSpecs { get; }

        public SimulationLathe()
        {
            latheRepository = new SimulationLatheRepository();
            LatheSpecs = new LatheSpecs();
            LatheSpecs.Initialize(enumMachineType.Sim);
        }

        public void Close()
        {

        }

        public MachineToolOffset GetOffset(int toolOffsetID, SubSystem subSystem)
        {
            return latheRepository.GetOffset(toolOffsetID);
        }

        public double GetOffset(int offsetID, ToolOffsetAxisIndex axis, SubSystem subSystem)
        {
            //TODO
            throw new System.NotImplementedException();
        }

        public double GetWearOffset(int offsetID, ToolWearOffsetAxisIndex axis, SubSystem subSystem)
        {
            throw new System.NotImplementedException();
        }

        public double GetRadiusOffset(int offsetID, ToolRadiusOffsetAxisIndex axis, SubSystem subSystem)
        {
            throw new System.NotImplementedException();
        }

        public int GetNoseRadusCompPattern(int offsetID, SubSystem subSystem)
        {
            throw new System.NotImplementedException();
        }

        public void SetOffset(MachineToolOffset offset, bool zeroWearOffset, SubSystem subSystem)
        {
            latheRepository.Update(offset, zeroWearOffset);
        }

        public void ResetOffset(int id, SubSystem subSystem)
        {
        }

        public void AttachTool(int station, int tool, ToolLocation turret)
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
