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
            TurretType = turretType;

            var stations = new List<Station>(numberOfSations);

            for (var i = 0; i < numberOfSations; i++)
            {
                stations.Add(new Station(i + 1));
            }
            Stations = new ReadOnlyCollection<Station>(stations);
            OffsetCount = offsetCount;
        }

        public readonly ReadOnlyCollection<Station> Stations;
        public readonly int OffsetCount;
        public readonly TurretType TurretType;
    }
}
