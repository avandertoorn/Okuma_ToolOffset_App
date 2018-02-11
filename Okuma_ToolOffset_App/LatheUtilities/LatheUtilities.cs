using Okuma.CLDATAPI.DataAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okuma_ToolOffset_App.LatheUtilities
{
    public class LatheUtilities
    {
        private CSpec _cSpec;

        public LatheUtilities()
        {
            _cSpec = new CSpec();
        }

        public int GetOffsetCount()
        {

            if (_cSpec.GetSpecCode(21, 7))
                return 800;
            else if (_cSpec.GetSpecCode(21, 4))
                return 200;
            else if (_cSpec.GetSpecCode(21, 2))
                return 96;
            else if (_cSpec.GetSpecCode(21, 1))
                return 64;
            else
                return 32;
        }

        public bool ToolWearOffsetCheck()
        {
            return _cSpec.GetSpecCode(21, 5);
        }

        public bool GetYAxisExsitence()
        {
            return _cSpec.GetSpecCode(8, 0);
        }

        public bool GetSubSpindleExsitence()
        {
            return _cSpec.GetSpecCode(4, 1);
        }
    }
}
