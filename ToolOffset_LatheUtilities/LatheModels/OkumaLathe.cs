using System;
using ToolOffset_LatheUtilities.Enums;
using ToolOffset_LatheUtilities.Interfaces;

namespace ToolOffset_LatheUtilities.LatheModels
{
    public class OkumaLathe : IOkumaLathe
    {
        private Okuma.CLDATAPI.DataAPI.CMachine _machine;
        private Okuma.CLDATAPI.DataAPI.CTools _tools;
        private Okuma.CLDATAPI.DataAPI.CTurret _turret;
        private Okuma.CLCMDAPI.CommandAPI.CATC _cACT;

        public LatheSpecs LatheSpecs { get; }

        public OkumaLathe()
        {
            _machine = new Okuma.CLDATAPI.DataAPI.CMachine("Tool App");
            _machine.Init();
            _tools = new Okuma.CLDATAPI.DataAPI.CTools();
            _turret = new Okuma.CLDATAPI.DataAPI.CTurret();
            _cACT = new Okuma.CLCMDAPI.CommandAPI.CATC();
            LatheSpecs = new LatheSpecs();
            LatheSpecs.Initialize(Gosiger.Utilities.enumMachineType.Lathe);
        }

        public void Close()
        {
            if (_machine != null)
                _machine.Close();
        }

        public MachineToolOffset GetOffset(int toolOffsetID, SubSystem subSystem)
        {
            if (!CheckManualOperationMode())
                throw new Exception("Machine not in Manual Mode");

            if (toolOffsetID <= 0 || toolOffsetID > LatheSpecs.OffsetCount)
                throw new Exception("Offset Number Out of Range");

            var tempToolOffset = new MachineToolOffset();

            _tools.SetSubSystem((Okuma.CLDATAPI.Enumerations.SubSystemEnum)subSystem);

            tempToolOffset.XOffset = _tools.GetToolOffset(toolOffsetID, Okuma.CLDATAPI.Enumerations.ToolOffsetAxisIndexEnum.X_Axis);
            if (LatheSpecs.YAxisExsitence)
                tempToolOffset.YOffset = _tools.GetToolOffset(toolOffsetID, Okuma.CLDATAPI.Enumerations.ToolOffsetAxisIndexEnum.YI_Axis);
            tempToolOffset.ZOffset = _tools.GetToolOffset(toolOffsetID, Okuma.CLDATAPI.Enumerations.ToolOffsetAxisIndexEnum.Z_Axis);
            tempToolOffset.RadiusCompPattern = _tools.GetNoseRCompensationPattern(toolOffsetID);
            tempToolOffset.XRadiusOffset = _tools.GetNoseRCompensation(toolOffsetID, Okuma.CLDATAPI.Enumerations.NoseRCompensationAxisIndexEnum.X_Axis);
            tempToolOffset.ZRadiusOffset = _tools.GetNoseRCompensation(toolOffsetID, Okuma.CLDATAPI.Enumerations.NoseRCompensationAxisIndexEnum.Z_Axis);
            if (LatheSpecs.ToolWearOffsetExsitence)
                tempToolOffset.XWearOffset = _tools.GetToolWearOffset(toolOffsetID, Okuma.CLDATAPI.Enumerations.ToolWearOffsetAxisIndexEnum.X_Axis);
            if (LatheSpecs.ToolWearOffsetExsitence)
                tempToolOffset.ZWearOffset = _tools.GetToolWearOffset(toolOffsetID, Okuma.CLDATAPI.Enumerations.ToolWearOffsetAxisIndexEnum.Z_Axis);

            return tempToolOffset;
        }


        public double GetOffset(int offsetID, ToolOffsetAxisIndex axis, SubSystem subSystem)
        {
            if (!LatheSpecs.YAxisExsitence && axis == ToolOffsetAxisIndex.YI_Axis)
                throw new Exception("Y axis not available");

            _tools.SetSubSystem((Okuma.CLDATAPI.Enumerations.SubSystemEnum)subSystem);

            return _tools.GetToolOffset(
                offsetID, (Okuma.CLDATAPI.Enumerations.ToolOffsetAxisIndexEnum)axis);
        }

        public void SetOffset(MachineToolOffset offset, bool zeroWearOffset, SubSystem subSystem)
        {
            if (!CheckManualOperationMode())
                throw new Exception("Machine not in Manual Mode");

            _tools.SetSubSystem((Okuma.CLDATAPI.Enumerations.SubSystemEnum)subSystem);

            _tools.SetToolOffset(offset.ID, Okuma.CLDATAPI.Enumerations.ToolOffsetAxisIndexEnum.X_Axis, offset.XOffset);
            if (LatheSpecs.YAxisExsitence)
                _tools.SetToolOffset(offset.ID, Okuma.CLDATAPI.Enumerations.ToolOffsetAxisIndexEnum.YI_Axis, offset.YOffset);
            _tools.SetToolOffset(offset.ID, Okuma.CLDATAPI.Enumerations.ToolOffsetAxisIndexEnum.Z_Axis, offset.ZOffset);
            _tools.SetNoseRCompensationPattern(offset.ID, offset.RadiusCompPattern);
            _tools.SetNoseRCompensation(offset.ID, Okuma.CLDATAPI.Enumerations.NoseRCompensationAxisIndexEnum.X_Axis, offset.XRadiusOffset);
            _tools.SetNoseRCompensation(offset.ID, Okuma.CLDATAPI.Enumerations.NoseRCompensationAxisIndexEnum.Z_Axis, offset.ZRadiusOffset);
            if (zeroWearOffset && LatheSpecs.ToolWearOffsetExsitence)
                _tools.SetToolWearOffset(offset.ID, Okuma.CLDATAPI.Enumerations.ToolWearOffsetAxisIndexEnum.X_Axis, 0.0);
            if (zeroWearOffset && LatheSpecs.ToolWearOffsetExsitence)
                _tools.SetToolWearOffset(offset.ID, Okuma.CLDATAPI.Enumerations.ToolWearOffsetAxisIndexEnum.Z_Axis, 0.0);
        }

        public void ResetOffset(int id, SubSystem subSystem)
        {
            if (!CheckManualOperationMode())
                throw new Exception("Machine not in Manual Mode");

            _tools.SetSubSystem((Okuma.CLDATAPI.Enumerations.SubSystemEnum)subSystem);

            _tools.SetToolOffset(id, Okuma.CLDATAPI.Enumerations.ToolOffsetAxisIndexEnum.X_Axis, 0.0);
            if (LatheSpecs.YAxisExsitence)
                _tools.SetToolOffset(id, Okuma.CLDATAPI.Enumerations.ToolOffsetAxisIndexEnum.YI_Axis, 0.0);
            _tools.SetToolOffset(id, Okuma.CLDATAPI.Enumerations.ToolOffsetAxisIndexEnum.Z_Axis, 0.0);
            _tools.SetNoseRCompensationPattern(id, 0);
            _tools.SetNoseRCompensation(id, Okuma.CLDATAPI.Enumerations.NoseRCompensationAxisIndexEnum.X_Axis, 0.0);
            _tools.SetNoseRCompensation(id, Okuma.CLDATAPI.Enumerations.NoseRCompensationAxisIndexEnum.Z_Axis, 0.0);
            if (LatheSpecs.ToolWearOffsetExsitence)
                _tools.SetToolWearOffset(id, Okuma.CLDATAPI.Enumerations.ToolWearOffsetAxisIndexEnum.X_Axis, 0.0);
            if (LatheSpecs.ToolWearOffsetExsitence)
                _tools.SetToolWearOffset(id, Okuma.CLDATAPI.Enumerations.ToolWearOffsetAxisIndexEnum.Z_Axis, 0.0);
        }

        public void AttachTool(int station, int toolNo, ToolLocation turret)
        {
            if (CheckManualOperationMode())
                _cACT.AttachTool(toolNo, station, (Okuma.CLCMDAPI.Enumerations.ToolLocationEnum)turret);
            else
                throw new Exception("Machine not in Manual Mode");
        }

        public void DetachTool(int station, ToolLocation turret)
        {
            if (CheckManualOperationMode())
                _cACT.DetachTool(station, (Okuma.CLCMDAPI.Enumerations.ToolLocationEnum)turret);
            else
                throw new Exception("Machine not in Manual Mode");
        }

        public int GetToolNo(int station)
        {
            int toolNo = _turret.GetToolNo(station);
            return toolNo;
        }

        private bool CheckManualOperationMode()
        {
            return _machine.GetOperationMode() == Okuma.CLDATAPI.Enumerations.OperationModeEnum.Manual;
        }

        public double GetWearOffset(int offsetID, ToolWearOffsetAxisIndex axis, SubSystem subSystem)
        {
            throw new NotImplementedException();
        }

        public double GetRadiusOffset(int offsetID, ToolRadiusOffsetAxisIndex axis, SubSystem subSystem)
        {
            throw new NotImplementedException();
        }

        public int GetNoseRadusCompPattern(int offsetID, SubSystem subSystem)
        {
            throw new NotImplementedException();
        }
    }
}
