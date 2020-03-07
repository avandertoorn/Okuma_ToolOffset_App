using System.Collections.Generic;
using ToolOffset_LatheUtilities.Interfaces;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models;
using ToolOffset_Models.Models.Lathe;
using ToolOffset_Models.Models.Tools;

namespace ToolOffset_MachineModels.Models
{
    public interface ILathe
    {
        Turret ATurret { get; }
        Turret BTurret { get; }
        Turret CTurret { get; }
        IOkumaLathe Machine { get; }
        IEnumerable<Turret> Turrets { get; }

        bool ToolInUse(Tool tool);
        bool ToolOffsetInUse(ToolOffset toolOffset);
        int ToolInUseCount(Tool tool);
        bool BlockInUse(Block block);
        bool BlockPositionInUse(Position position);
        int BlockInUseCount(Block block);
        bool OffsetIdInUse(int offsetId, TurretType turretType);

        void UpdateToolOffset(ToolOffset toolOffset);
        void UpdatePosition(Position position);
    }
}
