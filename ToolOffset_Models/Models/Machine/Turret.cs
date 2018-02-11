using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Tools;

namespace ToolOffset_Models.Models.Machine
{
    public class Turret
    {
        private int _numberOfStations;
        private int _numberOfOffsets;
        private List<Station> _stations;
        private List<MachineToolOffset> _offsets;

        public List<Station> Stations
        {
            get { return _stations; }
        }

        public List<MachineToolOffset> Offsets
        {
            get { return _offsets; }
        }

        public Turret(int numberOfSations, int numberOfOffsets)
        {
            _numberOfStations = numberOfSations;
            _stations = new List<Station>(numberOfSations);

            for (var i = 0; i < numberOfSations; i++)
            {
                _stations.Add(new Station(i + 1));
            }

            _numberOfOffsets = numberOfOffsets;
            _offsets = new List<MachineToolOffset>(numberOfOffsets);

            for (var i = 0; i < numberOfOffsets; i++)
            {
                _offsets.Add(new MachineToolOffset(i + 1));
            }
        }
    }
}
