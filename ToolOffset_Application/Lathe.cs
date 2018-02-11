using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolOffset_LatheUtilities.Interfaces;
using ToolOffset_LatheUtilities.Utilities;
using ToolOffset_Models.Models.Machine;
using ToolOffset_Services.Interfaces;

namespace ToolOffset_Application
{
    public class Lathe : ILathe
    {
        private Turret _aTurret;
        private Turret _bTurret;
        private Turret _cTurret;
        private IOkumaLathe _okumaLathe;
        private IUnitOfWork _unitOfWork;

        public Turret ATurret
        {
            get { return _aTurret; }
        }

        public Turret BTurret
        {
            get { return _bTurret; }
        }

        public Turret CTurret
        {
            get { return _cTurret; }
        }

        public Lathe(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _okumaLathe = LatheFactory.GetAPI();

            if (LatheSpecs.ATurretExistence)
                _aTurret = new Turret(LatheSpecs.ATurretStationCount, LatheSpecs.OffsetCount);
            if (LatheSpecs.BTurretExistence)
                _bTurret = new Turret(LatheSpecs.BTurretStationCount, LatheSpecs.OffsetCount);
            if (LatheSpecs.CTurretExistence)
                _cTurret = new Turret(LatheSpecs.CTurretStationCount, LatheSpecs.OffsetCount);
        }
    }
}
