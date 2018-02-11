using Okuma_ToolOffset_App.Models.AppModels;
using Okuma_ToolOffset_App.Models.MachineModels;
using Okuma_ToolOffset_App.Models.MachineModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okuma_ToolOffset_App.LatheUtilities
{
    public class Lathe : IOkumaLathe
    {
        private Okuma.CLDATAPI.DataAPI.CMachine _machine;
        private Okuma.CLDATAPI.DataAPI.CTools _tools;
        private Okuma.CLDATAPI.DataAPI.CTurret _turret;
        private Okuma.CLCMDAPI.CommandAPI.CATC _cACT;
        private LatheUtilities _latheUtilities;

        public List<MachineToolOffset> MachineToolOffsets { get; private set; }
        public bool ToolWearOffsetExsitence { get; private set; }
        public bool YAxisExsitence { get; private set; }
        public int StationCount { get; private set; }
        public int ToolOffsetCount { get; private set; }
        public bool SubSpindleExsitence { get; private set; }

        //Add method to set

        public Lathe()
        {
            _machine = new Okuma.CLDATAPI.DataAPI.CMachine("Tool App");
            _machine.Init();
            _tools = new Okuma.CLDATAPI.DataAPI.CTools();
            _turret = new Okuma.CLDATAPI.DataAPI.CTurret();
            _cACT = new Okuma.CLCMDAPI.CommandAPI.CATC();
            Initialize();
        }

        public void Initialize()
        {
            _latheUtilities = new LatheUtilities();

            ToolOffsetCount = _latheUtilities.GetOffsetCount();
            ToolWearOffsetExsitence = _latheUtilities.ToolWearOffsetCheck();
            YAxisExsitence = _latheUtilities.GetYAxisExsitence();
            SubSpindleExsitence = _latheUtilities.GetSubSpindleExsitence();
            StationCount = _turret.GetMaxToolPots(Okuma.CLDATAPI.Enumerations.TurretEnum.A_Turret);
            UpdateAllToolOffets();
        }

        public void Close()
        {
            if (_machine != null)
                _machine.Close();
        }

        public void UpdateOffset(int offsetNo)
        {
            if (offsetNo <= 0 || offsetNo > ToolOffsetCount)
                throw new Exception("Offset Number Out of Range");

            MachineToolOffsets[offsetNo].XOffset = _tools.GetToolOffset(offsetNo, Okuma.CLDATAPI.Enumerations.ToolOffsetAxisIndexEnum.X_Axis);
            if (YAxisExsitence)
                MachineToolOffsets[offsetNo].YOffset = _tools.GetToolOffset(offsetNo, Okuma.CLDATAPI.Enumerations.ToolOffsetAxisIndexEnum.YI_Axis);
            MachineToolOffsets[offsetNo].ZOffset = _tools.GetToolOffset(offsetNo, Okuma.CLDATAPI.Enumerations.ToolOffsetAxisIndexEnum.Z_Axis);
            MachineToolOffsets[offsetNo].RadiusCompPattern = _tools.GetNoseRCompensationPattern(offsetNo);
            MachineToolOffsets[offsetNo].XRadiusOffset = _tools.GetNoseRCompensation(offsetNo, Okuma.CLDATAPI.Enumerations.NoseRCompensationAxisIndexEnum.X_Axis);
            MachineToolOffsets[offsetNo].ZRadiusOffset = _tools.GetNoseRCompensation(offsetNo, Okuma.CLDATAPI.Enumerations.NoseRCompensationAxisIndexEnum.Z_Axis);
            if (ToolWearOffsetExsitence)
                MachineToolOffsets[offsetNo].XWearOffset = _tools.GetToolWearOffset(offsetNo, Okuma.CLDATAPI.Enumerations.ToolWearOffsetAxisIndexEnum.X_Axis);
            if (ToolWearOffsetExsitence)
                MachineToolOffsets[offsetNo].ZWearOffset = _tools.GetToolWearOffset(offsetNo, Okuma.CLDATAPI.Enumerations.ToolWearOffsetAxisIndexEnum.Z_Axis);
        }

        public void SetOffset(MachineToolOffset offset, bool zeroWearOffset)
        {
            _tools.SetToolOffset(offset.ID, Okuma.CLDATAPI.Enumerations.ToolOffsetAxisIndexEnum.X_Axis, offset.XOffset);
            if (YAxisExsitence)
                _tools.SetToolOffset(offset.ID, Okuma.CLDATAPI.Enumerations.ToolOffsetAxisIndexEnum.YI_Axis, offset.YOffset);
            _tools.SetToolOffset(offset.ID, Okuma.CLDATAPI.Enumerations.ToolOffsetAxisIndexEnum.Z_Axis, offset.ZOffset);
            _tools.SetNoseRCompensationPattern(offset.ID, offset.RadiusCompPattern);
            _tools.SetNoseRCompensation(offset.ID, Okuma.CLDATAPI.Enumerations.NoseRCompensationAxisIndexEnum.X_Axis, offset.XRadiusOffset);
            _tools.SetNoseRCompensation(offset.ID, Okuma.CLDATAPI.Enumerations.NoseRCompensationAxisIndexEnum.Z_Axis, offset.ZRadiusOffset);
            if (zeroWearOffset && ToolWearOffsetExsitence)
                _tools.SetToolWearOffset(offset.ID, Okuma.CLDATAPI.Enumerations.ToolWearOffsetAxisIndexEnum.X_Axis, 0.0);
            if (zeroWearOffset && ToolWearOffsetExsitence)
                _tools.SetToolWearOffset(offset.ID, Okuma.CLDATAPI.Enumerations.ToolWearOffsetAxisIndexEnum.Z_Axis, 0.0);

            UpdateOffset(offset.ID);
        }

        public void SetWearOffset(int offsetNo, ToolWearOffsetAxisIndexEnum axis, double value)
        {
            if (ToolWearOffsetExsitence)
                _tools.SetToolWearOffset(offsetNo, (Okuma.CLDATAPI.Enumerations.ToolWearOffsetAxisIndexEnum)axis, value);
            else
                throw new Exception("Wear Offsets Invalid");
        }

        public void AttachTool(int station, Tool tool, ToolLocationEnum turret)
        {
            if (CheckManualOperationMode())
                _cACT.AttachTool(tool.ToolNo, station, (Okuma.CLCMDAPI.Enumerations.ToolLocationEnum)turret);
            else
                throw new Exception("Machine not in Manual Mode");
        }

        public void DetachTool(int station, ToolLocationEnum turret)
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

        private void UpdateAllToolOffets()
        {
            if (MachineToolOffsets == null)
                MachineToolOffsets = new List<MachineToolOffset>(ToolOffsetCount);
            for (int i = 0; i < ToolOffsetCount; i++)
            {
                UpdateOffset(i + 1);
            }
        }
    }
}
