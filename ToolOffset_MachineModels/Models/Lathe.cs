using System;
using System.Collections.Generic;
using System.Linq;
using ToolOffset_LatheUtilities.Interfaces;
using ToolOffset_LatheUtilities.Utilities;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models;
using ToolOffset_Models.Models.Lathe;
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
        public IEnumerable<MountedBlock> MountedBlockAssemblies { get => GetBlocks(); }
        public IEnumerable<MountedPosition> MountedPositions { get => GetPositions(); }
        public IEnumerable<MountedToolOffset> MountedToolOffsets { get => GetMountedToolOffsets(); }

        #region PublicBlockAndToolUseMethods

        public bool ToolInUse(Tool tool)
        {
            throw new NotImplementedException();
        }

        public bool ToolOffsetInUse(ToolOffset toolOffset)
        {
            throw new NotImplementedException();
        }

        public int ToolInUseCount(Tool tool)
        {
            throw new NotImplementedException();
        }

        public bool BlockInUse(Block blockAssembly)
        {
            throw new NotImplementedException();
        }

        public bool BlockPositionInUse(Position position)
        {
            return MountedPositions
                .Any(a => a.Id == position.ID
                && a.ToolOffsets.Count > 0);
        }

        public int BlockInUseCount(Block blockAssembly)
        {
            return MountedBlockAssemblies
                .Where(a => a.Id == blockAssembly.ID)
                .Count();
        }

        public bool OffsetIdInUse(int offsetId, TurretType turret)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region BlockAndToolUpdateMethods

        public void UpdateToolOffset(ToolOffset toolOffset)
        {
        }

        public void UpdatePosition(Position position)
        {
            //TODO
        }

        private void UpdateOffset()
        {
        }

        private void ResetOffset()
        {
            //TODO
        }

        #endregion

        private void CalculateOffset()
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
            
        }

        private void OnBlockUnMounting(Station source, EventArgs args)
        {

        }

        private void OnOffsetAdded(object source)
        {
            UpdateOffset();
        }

        private void OnOffsetRemoving(object source)
        {
            ResetOffset();
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

        private IEnumerable<MountedBlock> GetBlocks()
        {
            return Stations.Where(a => a.ToolBlock != null)
                .Select(a => a.ToolBlock);
        }

        private IEnumerable<MountedPosition> GetPositions()
        {
            return MountedBlockAssemblies
                .Where(a => a.Positions != null)
                .SelectMany(a => a.Positions);
        }

        private IEnumerable<MountedToolOffset> GetMountedToolOffsets()
        {
            return MountedPositions
                .Where(a => a.ToolOffsets != null)
                .SelectMany(a => a.ToolOffsets);
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
