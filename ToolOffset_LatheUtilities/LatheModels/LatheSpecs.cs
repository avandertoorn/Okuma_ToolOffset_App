using Gosiger.Utilities;
using ToolOffset_LatheUtilities.Utilities;

namespace ToolOffset_LatheUtilities.LatheModels
{
    public class LatheSpecs
    {
        public bool LatheSpecsInitialized { get; private set; } = false;
        public bool ATurretExistence { get; private set; }
        public bool BTurretExistence { get; private set; }
        public bool CTurretExistence { get; private set; }
        public int ATurretStationCount { get; private set; }
        public int BTurretStationCount { get; private set; }
        public int CTurretStationCount { get; private set; }
        public bool SubSpindleExistence { get; private set; }
        public int OffsetCount { get; private set; }
        public bool ToolWearOffsetExsitence { get; private set; }
        public bool YAxisExsitence { get; private set; }

        public void Initialize(enumMachineType type)
        {
            switch (type)
            {
                case enumMachineType.Lathe:
                    OkumaInitialize();
                    break;
                case enumMachineType.Sim:
                    SimulationInitialize();
                    break;
            }
        }

        private void OkumaInitialize()
        {
            LatheUtility latheUtility = new LatheUtility();

            ATurretExistence = latheUtility.GetATurretExsitence();
            BTurretExistence = latheUtility.GetBTurretExsitence();
            CTurretExistence = latheUtility.GetCTurretExsitence();
            if (ATurretExistence)
                ATurretStationCount = latheUtility.GetATurretStationCount();
            if (BTurretExistence)
                BTurretStationCount = latheUtility.GetBTurretStationCount();
            if (CTurretExistence)
                CTurretStationCount = latheUtility.GetCTurretStationCount();
            SubSpindleExistence = latheUtility.GetSubSpindleExsitence();
            OffsetCount = latheUtility.GetToolOffsetCount();
            ToolWearOffsetExsitence = latheUtility.GetToolWearOffsetExsitence();
            YAxisExsitence = latheUtility.GetYAxisExsitence();

            LatheSpecsInitialized = true;
        }

        private void SimulationInitialize()
        {
            ATurretExistence = true;
            BTurretExistence = false;
            CTurretExistence = false;
            ATurretStationCount = 12;
            SubSpindleExistence = false;
            OffsetCount = 32;
            ToolWearOffsetExsitence = true;
            YAxisExsitence = false;

            LatheSpecsInitialized = true;
        }
    }
}
