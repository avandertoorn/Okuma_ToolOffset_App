using Okuma.CLCMDAPI.Enumerations;
using Okuma.CLDATAPI.Enumerations;
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
    public class OkumaLathe : IOkumaLathe
    {
        private Okuma.CLDATAPI.DataAPI.CMachine _machine;
        private Okuma.CLDATAPI.DataAPI.CTools _tools;
        private Okuma.CLDATAPI.DataAPI.CTurret _turret;
        private Okuma.CLCMDAPI.CommandAPI.CATC _cACT;

        public OkumaLathe()
        {
            _machine = new Okuma.CLDATAPI.DataAPI.CMachine("Tool App");
            _machine.Init();
            _tools = new Okuma.CLDATAPI.DataAPI.CTools();
            _turret = new Okuma.CLDATAPI.DataAPI.CTurret();
            _cACT = new Okuma.CLCMDAPI.CommandAPI.CATC();
        }

        public void Close()
        {
            if (_machine != null)
                _machine.Close();
        }

        public MachineToolOffset GetOffset(MachineToolOffset toolOffset, SubSystem subSystem)
        {
            if (!CheckManualOperationMode())
                throw new Exception("Machine not in Manual Mode");

            if (toolOffset.ID <= 0 || toolOffset.ID > LatheSpecs.OffsetCount)
                throw new Exception("Offset Number Out of Range");

            var tempToolOffset = new MachineToolOffset();

            _tools.SetSubSystem((Okuma.CLDATAPI.Enumerations.SubSystemEnum)subSystem);

            tempToolOffset.XOffset = _tools.GetToolOffset(toolOffset.ID, Okuma.CLDATAPI.Enumerations.ToolOffsetAxisIndexEnum.X_Axis);
            if (LatheSpecs.YAxisExsitence)
                tempToolOffset.YOffset = _tools.GetToolOffset(toolOffset.ID, Okuma.CLDATAPI.Enumerations.ToolOffsetAxisIndexEnum.YI_Axis);
            tempToolOffset.ZOffset = _tools.GetToolOffset(toolOffset.ID, Okuma.CLDATAPI.Enumerations.ToolOffsetAxisIndexEnum.Z_Axis);
            tempToolOffset.RadiusCompPattern = _tools.GetNoseRCompensationPattern(toolOffset.ID);
            tempToolOffset.XRadiusOffset = _tools.GetNoseRCompensation(toolOffset.ID, Okuma.CLDATAPI.Enumerations.NoseRCompensationAxisIndexEnum.X_Axis);
            tempToolOffset.ZRadiusOffset = _tools.GetNoseRCompensation(toolOffset.ID, Okuma.CLDATAPI.Enumerations.NoseRCompensationAxisIndexEnum.Z_Axis);
            if (LatheSpecs.ToolWearOffsetExsitence)
                tempToolOffset.XWearOffset = _tools.GetToolWearOffset(toolOffset.ID, Okuma.CLDATAPI.Enumerations.ToolWearOffsetAxisIndexEnum.X_Axis);
            if (LatheSpecs.ToolWearOffsetExsitence)
                tempToolOffset.ZWearOffset = _tools.GetToolWearOffset(toolOffset.ID, Okuma.CLDATAPI.Enumerations.ToolWearOffsetAxisIndexEnum.Z_Axis);

            return tempToolOffset;
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

        public void AttachTool(int station, Tool tool, ToolLocation turret)
        {
            if (CheckManualOperationMode())
                _cACT.AttachTool(tool.ToolNo, station, (Okuma.CLCMDAPI.Enumerations.ToolLocationEnum)turret);
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
    }
}
