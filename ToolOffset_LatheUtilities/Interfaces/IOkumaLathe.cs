using ToolOffset_LatheUtilities.Enums;
using ToolOffset_LatheUtilities.LatheModels;

namespace ToolOffset_LatheUtilities.Interfaces
{
    public interface IOkumaLathe
    {
        LatheSpecs LatheSpecs { get; }

        void Close();
        MachineToolOffset GetOffset(int toolOffsetID, SubSystem subSystem);
        double GetOffset(int offsetID, ToolOffsetAxisIndex axis, SubSystem subSystem);
        double GetWearOffset(int offsetID, ToolWearOffsetAxisIndex axis, SubSystem subSystem);
        double GetRadiusOffset(int offsetID, ToolRadiusOffsetAxisIndex axis, SubSystem subSystem);
        int GetNoseRadusCompPattern(int offsetID, SubSystem subSystem);
        void SetOffset(MachineToolOffset offset, bool zeroWearOffset, SubSystem subSystem);
        void ResetOffset(int id, SubSystem subSystem);
        void AttachTool(int station, int toolNo, ToolLocation turret);
        void DetachTool(int station, ToolLocation turret);
        int GetToolNo(int station);
    }
}
