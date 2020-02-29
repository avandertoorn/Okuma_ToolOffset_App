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
        bool BlockInUse(BlockAssembly blockAssembly);
        bool BlockPositionInUse(Position position);
        int BlockInUseCount(BlockAssembly blockAssembly);
        bool OffsetIdInUse(int offsetId, TurretType turretType);

        void UpdateToolOffset(ToolOffset toolOffset);
        void UpdatePosition(Position position);
        void BlockPositionAddedUpdate(BlockAssembly blockAssembly, List<Position> addedPositions);
        void BlockPositionsRemovedUpdate(BlockAssembly blockAssembly, List<Position> removedPositions);
    }
}
