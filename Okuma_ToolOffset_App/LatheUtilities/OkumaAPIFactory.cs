using Gosiger.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okuma_ToolOffset_App.LatheUtilities
{
    public static class OkuamAPIFactory
    {
        public static IOkumaLathe GetAPI()
        {
            var _machineType = MachineType.GetMachineType();
            if (_machineType == enumMachineType.Lathe)
                return new Lathe();
            if (_machineType == enumMachineType.Sim)
                return new LatheSim();
            else
                throw new Exception("Invalid Machine Type");
        }
    }
}
