using System.Collections.Generic;
using System.Collections.ObjectModel;
using ToolOffset_Models.Enumerations;

namespace ToolOffset_Models.Models.Lathe
{
    public class Turret
    {
        public Turret(int numberOfSations, int offsetCount,
            TurretType turretType)
        {
            _turretType = turretType;
            _numberOfStations = numberOfSations;

            var stations = new List<Station>(numberOfSations);

            for (var i = 0; i < numberOfSations; i++)
            {
                stations.Add(new Station(i + 1, this));
            }
            _stations = new ReadOnlyCollection<Station>(stations);
            _offsetCount = offsetCount;
        }

        private readonly int _numberOfStations;

        private readonly ReadOnlyCollection<Station> _stations;
        public ReadOnlyCollection<Station> Stations
        {
            get { return _stations; }
        }

        private readonly int _offsetCount;
        public int OffsetCount
        {
            get { return _offsetCount; }
        }

        private readonly TurretType _turretType;
        public TurretType TurretType
        {
            get { return _turretType; }
        }

        //TODO
        public double MainSideXAdjust { get => 1.5; }
        public double MainSideZAdjust { get => .5; }
        public double SubSideXAdjust { get => 1.5; }
        public double SubSideZAdjust { get => -4.5; }
        public double TurretWidth { get => 4.0; }

    }
}
