
using Okuma.CLDATAPI.DataAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolOffset_LatheUtilities.Utilities
{
    public class LatheUtility
    {
        private CSpec _cSpec;
        private CTurret _cTurret;

        public LatheUtility()
        {
            _cSpec = new CSpec();
            _cTurret = new CTurret();
        }

        public bool GetATurretExsitence()
        {
            return true;
        }

        public bool GetBTurretExsitence()
        {
            return _cSpec.GetSpecCode(4, 7);
        }

        public bool GetCTurretExsitence()
        {
            return false;
        }

        public int GetATurretStationCount()
        {
            return _cTurret.GetMaxToolPots(Okuma.CLDATAPI.Enumerations.TurretEnum.A_Turret);
        }

        public int GetBTurretStationCount()
        {
            return _cTurret.GetMaxToolPots(Okuma.CLDATAPI.Enumerations.TurretEnum.B_Turret);
        }

        public int GetCTurretStationCount()
        {
            return _cTurret.GetMaxToolPots(Okuma.CLDATAPI.Enumerations.TurretEnum.C_Turret);
        }

        public bool GetSubSpindleExsitence()
        {
            return _cSpec.GetSpecCode(4, 1);
        }

        public int GetToolOffsetCount()
        {
            if (_cSpec.GetBSpecCode(8, 2))
                return 999;
            else if (_cSpec.GetSpecCode(21, 7))
                return 800;
            else if (_cSpec.GetSpecCode(21, 4))
                return 200;
            else if (_cSpec.GetSpecCode(21, 2))
                return 96;
            else if (_cSpec.GetSpecCode(2, 1))
                return 64;
            else
                return 32;
        }

        public bool GetToolWearOffsetExsitence()
        {
            return _cSpec.GetSpecCode(21, 5);
        }

        public bool GetYAxisExsitence()
        {
            return _cSpec.GetSpecCode(8, 0);
        }

    }
}
