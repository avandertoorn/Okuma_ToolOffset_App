using Okuma_ToolOffset_App.Models.AppModels;
using Okuma_ToolOffset_App.Models.MachineModels;
using Okuma_ToolOffset_App.Models.MachineModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okuma_ToolOffset_App.LatheUtilities
{
    public interface IOkumaLathe
    {
        List<MachineToolOffset> MachineToolOffsets { get; }
        bool ToolWearOffsetExsitence { get; }
        bool YAxisExsitence { get; }
        int ToolOffsetCount { get; }
        int StationCount { get; }
        bool SubSpindleExsitence { get; }

        void Initialize();
        void Close();
        void UpdateOffset(int offsetNo);
        void SetOffset(MachineToolOffset offset, bool zeroWearOffset);
        void SetWearOffset(int offsetNo, ToolWearOffsetAxisIndexEnum axis, double value);
        void AttachTool(int station, Tool tool, ToolLocationEnum turret);
        void DetachTool(int station, ToolLocationEnum turret);
        int GetToolNo(int station);
    }
}
