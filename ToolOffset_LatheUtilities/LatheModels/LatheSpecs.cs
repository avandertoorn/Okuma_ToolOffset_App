using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolOffset_LatheUtilities.Enums;
using ToolOffset_LatheUtilities.Utilities;

namespace ToolOffset_Models.Models.Machine
{
    public static class LatheSpecs
    {
        public static bool LatheSpecsInitialized { get; private set; }
        public static bool ATurretExistence { get; private set; }
        public static bool BTurretExistence { get; private set; }
        public static bool CTurretExistence { get; private set; }
        public static int ATurretStationCount { get; private set; }
        public static int BTurretStationCount { get; private set; }
        public static int CTurretStationCount { get; private set; }
        public static bool SubSpindleExistence { get; private set; }
        public static int OffsetCount { get; private set; }
        public static bool ToolWearOffsetExsitence { get; private set; }
        public static bool YAxisExsitence { get; private set; }

        public static void Initialize(LatheType type)
        {
            switch (type)
            {
                case LatheType.Okuma:
                    OkumaInitialize();
                    break;
                case LatheType.Simulation:
                    SimulationInitialize();
                    break;
            }
        }

        private static void OkumaInitialize()
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

        private static void SimulationInitialize()
        {
            ATurretExistence = true;
            BTurretExistence = false;
            CTurretExistence = false;
            ATurretStationCount = 12;
            SubSpindleExistence = false;
            OffsetCount = 32;
            ToolWearOffsetExsitence = true;
            YAxisExsitence = false;
        }
    }
}
