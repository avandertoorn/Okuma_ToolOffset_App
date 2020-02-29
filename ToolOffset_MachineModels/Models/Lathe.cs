using System;
using System.Collections.Generic;
using System.Linq;
using ToolOffset_LatheUtilities.Interfaces;
using ToolOffset_LatheUtilities.Utilities;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.EventArg;
using ToolOffset_Models.Models;
using ToolOffset_Models.Models.Lathe;
using ToolOffset_Models.Models.MountedTools.Blocks;
using ToolOffset_Models.Models.MountedTools.Offsets;
using ToolOffset_Models.Models.MountedTools.Positions;
using ToolOffset_Models.Models.Tools;

namespace ToolOffset_MachineModels.Models
{
    public class Lathe : ILathe
    {

        public Lathe()
        {
            _machine = LatheFactory.GetAPI();
            Initialize();
        }

        private readonly IOkumaLathe _machine;
        public IOkumaLathe Machine { get => _machine; }

        private Turret _aTurret;
        public Turret ATurret { get => _aTurret; }

        private Turret _bTurret;
        public Turret BTurret { get => _bTurret; }

        private Turret _cTurret;
        public Turret CTurret { get => _cTurret; }

        public IEnumerable<Turret> Turrets { get => GetTurrets(); }
        public IEnumerable<Station> Stations { get => GetStations(); }
        public IEnumerable<IMountedBlockAssembly> MountedBlockAssemblies { get => GetBlocks(); }
        public IEnumerable<IMountedPosition> MountedPositions { get => GetPositions(); }
        public IEnumerable<IMountedToolOffset> MountedToolOffsets { get => GetMountedToolOffsets(); }

        #region PublicBlockAndToolUseMethods

        public bool ToolInUse(Tool tool)
        {
            return MountedPositions
                .Where(a => a.Tool != null)
                .Select(a => a.Tool).Contains(tool);
        }

        public bool ToolOffsetInUse(ToolOffset toolOffset)
        {
            return MountedToolOffsets
                .Select(a => a.ToolOffset)
                .Contains(toolOffset);
        }

        public int ToolInUseCount(Tool tool)
        {
            return MountedPositions
                .Where(a => a.Tool != null)
                .Where(t => t.Tool == tool)
                .Count();
        }

        public bool BlockInUse(BlockAssembly blockAssembly)
        {
            return MountedBlockAssemblies
                .Select(a => a.Block)
                .Contains(blockAssembly.Block);
        }

        public bool BlockPositionInUse(Position position)
        {
            return MountedPositions
                .Any(a => a.BlockPosition == position.BlockPosition
                && a.MountedToolOffsets.Count > 0);
        }

        public int BlockInUseCount(BlockAssembly blockAssembly)
        {
            return MountedBlockAssemblies
                .Where(a => a.Block == blockAssembly.Block)
                .Count();
        }

        public bool OffsetIdInUse(int offsetId, TurretType turret)
        {
            return MountedToolOffsets
                .Any(a =>
                a.ParentMountedPosition.ParentMountedBlockAssembly
                .Station.Turret.TurretType == turret
                && a.OffsetNo == offsetId);
        }

        #endregion

        #region BlockAndToolUpdateMethods

        public void UpdateToolOffset(ToolOffset toolOffset)
        {

            MountedToolOffsets
                .Where(a => a.ToolOffset != null)
                .Where(a => a.ToolOffset == toolOffset)
                .Select(a => a)
                .Invoke(a => UpdateOffset(a));
        }

        public void UpdatePosition(Position position)
        {
            //TODO
            MountedToolOffsets
            .Where(a => a.ParentMountedPosition.BlockPosition
            == position.BlockPosition);
        }

        public void BlockPositionAddedUpdate(
            BlockAssembly blockAssembly, List<Position> addedPositions)
        {
            foreach (var turret in Turrets)
            {
                foreach (var station in turret.Stations)
                {
                    if (station.ToolBlock != null)
                    {
                        if (station.ToolBlock.Block == blockAssembly.Block)
                        {
                            foreach (var pos in addedPositions)
                                station.ToolBlock.AddPosition(pos);
                        }
                    }
                }
            }
        }

        public void BlockPositionsRemovedUpdate(
            BlockAssembly blockAssembly, List<Position> removedPositions)
        {
            foreach (var turret in Turrets)
            {
                foreach (var station in turret.Stations)
                {
                    if (station.ToolBlock != null)
                    {
                        if (station.ToolBlock.Block == blockAssembly.Block)
                        {
                            foreach (var removedPosition in removedPositions)
                            {
                                IMountedPosition tempPosition = null;
                                foreach (var mountedPosition in station.ToolBlock.Positions)
                                {
                                    if (removedPosition.BlockPosition == mountedPosition.BlockPosition)
                                    {
                                        tempPosition = mountedPosition;
                                        break;
                                    }
                                }
                                if (tempPosition != null)
                                    station.ToolBlock.RemovePosition(tempPosition);
                            }
                        }
                    }
                }
            }
        }

        private void UpdateOffset(IMountedToolOffset offset)
        {
            CalculateOffset(offset);
        }

        private void ResetOffset(IMountedToolOffset offset)
        {
            //TODO
        }

        #endregion

        private void CalculateOffset(IMountedToolOffset offset)
        {

        }

        private void Initialize()
        {
            if (_machine.LatheSpecs.ATurretExistence)
            {
                _aTurret = new Turret(
                    _machine.LatheSpecs.ATurretStationCount,
                    _machine.LatheSpecs.OffsetCount,
                    TurretType.ATurret);
            }
            if (_machine.LatheSpecs.BTurretExistence)
            {
                _bTurret = new Turret(
                    _machine.LatheSpecs.BTurretStationCount,
                    _machine.LatheSpecs.OffsetCount,
                    TurretType.BTurret);
            }
            if (_machine.LatheSpecs.CTurretExistence)
            {
                _cTurret = new Turret(
                    _machine.LatheSpecs.CTurretStationCount,
                    _machine.LatheSpecs.OffsetCount,
                    TurretType.CTurret);
            }

            AttachStationEventHandlers();
        }

        #region EventHandlers

        private void AttachStationEventHandlers()
        {
            foreach (var station in Stations)
            {
                station.BlockMounted += OnBlockMounted;
                station.BlockUnMounting += OnBlockUnMounting;
            }

        }

        private void OnBlockMounted(Station source, EventArgs args)
        {
            if (source.ToolBlock != null)
            {
                foreach (var position in source.ToolBlock.Positions)
                {
                    position.OffsetAdded += OnOffsetAdded;
                    position.OffsetRemoving += OnOffsetRemoving;
                }
            }
        }

        private void OnBlockUnMounting(Station source, EventArgs args)
        {
            if (source.ToolBlock != null)
            {
                foreach (var position in source.ToolBlock.Positions)
                {
                    position.OffsetAdded -= OnOffsetAdded;
                    position.OffsetRemoving -= OnOffsetRemoving;
                }
            }
        }

        private void OnOffsetAdded(object source, MountedOffsetAddRemoveEventArgs args)
        {
            UpdateOffset(args.MountedToolOffset);
        }

        private void OnOffsetRemoving(object source, MountedOffsetAddRemoveEventArgs args)
        {
            ResetOffset(args.MountedToolOffset);
        }

        #endregion

        #region private IEnumrable Methods

        private IEnumerable<Turret> GetTurrets()
        {
            if (ATurret != null)
                yield return ATurret;

            if (BTurret != null)
                yield return BTurret;

            if (CTurret != null)
                yield return CTurret;
        }

        private IEnumerable<Station> GetStations()
        {
            return Turrets
                .Where(a => a.Stations != null)
                .SelectMany(a => a.Stations);
        }

        private IEnumerable<IMountedBlockAssembly> GetBlocks()
        {
            return Stations.Where(a => a.ToolBlock != null)
                .Select(a => a.ToolBlock);
        }

        private IEnumerable<IMountedPosition> GetPositions()
        {
            return MountedBlockAssemblies
                .Where(a => a.Positions != null)
                .SelectMany(a => a.Positions);
        }

        private IEnumerable<IMountedToolOffset> GetMountedToolOffsets()
        {
            return MountedPositions
                .Where(a => a.MountedToolOffsets != null)
                .SelectMany(a => a.MountedToolOffsets);
        }

        #endregion
    }

    public static class LINQExtension
    {
        public static void Invoke<T>(this IEnumerable<T> source, Action<T> method)
        {
            foreach (var offset in source)
            {
                method(offset);
            }
        }
    }
}
