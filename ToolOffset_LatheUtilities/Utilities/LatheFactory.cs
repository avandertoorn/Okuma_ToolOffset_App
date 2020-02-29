using Gosiger.Utilities;
using System;
using ToolOffset_LatheUtilities.Interfaces;
using ToolOffset_LatheUtilities.LatheModels;

namespace ToolOffset_LatheUtilities.Utilities
{
    public static class LatheFactory
    {
        public static IOkumaLathe GetAPI()
        {
            var _machineType = MachineType.GetMachineType();
            if (_machineType == enumMachineType.Lathe)
                return new OkumaLathe();
            if (_machineType == enumMachineType.Sim)
                return new SimulationLathe();
            else
                throw new Exception("Invalid Machine Type");
        }

        public static enumMachineType GetMachineType()
        {
            return MachineType.GetMachineType();
        }
    }
}
