using Okuma_ToolOffset_App.Models.AppModels;
using Okuma_ToolOffset_App.Models.AppModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okuma_ToolOffset_App.Models.MachineModels
{
    public class Turret
    {
        private int _numberOfStations;
        private List<Station> _stations;

        public List<Station> Stations
        {
            get { return _stations; }
        }

        public Turret(int numberOfSations)
        {
            _numberOfStations = numberOfSations;
            _stations = new List<Station>(numberOfSations);

            for (int i = 0; i < numberOfSations; i++)
            {
                _stations.Add(new Station(i + 1));
            }
        }

        public void MountBlock(ToolBlock toolBlock, int station, MountPositionEnum mountPosition)
        {
            if (station < 0 && station > _numberOfStations)
                throw new Exception("Invalid Station ID");

            foreach(Station stat in Stations)
            {
                if (stat.ID == station)
                {
                    stat.ToolBlock = new MountedToolBlock(toolBlock, mountPosition);
                    break;
                }
            }
        }


    }
}
