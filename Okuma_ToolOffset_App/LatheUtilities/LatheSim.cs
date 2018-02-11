using Okuma_ToolOffset_App.Models.AppModels;
using Okuma_ToolOffset_App.Models.MachineModels;
using Okuma_ToolOffset_App.Models.MachineModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okuma_ToolOffset_App.LatheUtilities
{
    public class LatheSim : IOkumaLathe
    {
        private Random random;
        private double[] _TestRadiusOffsets;

        public List<MachineToolOffset> MachineToolOffsets { get; private set; }
        public bool ToolWearOffsetExsitence { get; private set; }
        public bool YAxisExsitence { get; private set; }
        public int ToolOffsetCount { get; private set; }
        public int StationCount { get; private set; }
        public bool SubSpindleExsitence { get; private set; }

        public LatheSim()
        {
            if (random == null)
                random = new Random();
            if (MachineToolOffsets == null)
                MachineToolOffsets = new List<MachineToolOffset>();
            if (_TestRadiusOffsets == null)
                _TestRadiusOffsets = new double[6] { 0.00, .015, .031, .125, .1875, .25 };
            ToolWearOffsetExsitence = true;
            YAxisExsitence = false;
            ToolOffsetCount = 32;
            StationCount = 12;
            SubSpindleExsitence = false;

            if (MachineToolOffsets.Count == 0)
                for (int i = 0; i < ToolOffsetCount; i++)
                {
                    MachineToolOffsets.Add(new MachineToolOffset());
                }

            Initialize();
        }

        public void Initialize()
        {
            UpdateAllToolOffets();
        }

        public void Close()
        {

        }

        public void UpdateOffset(int offsetNo)
        {

            MachineToolOffsets[offsetNo].XOffset = random.Next(0, 5) + random.NextDouble();
            if (YAxisExsitence)
                MachineToolOffsets[offsetNo].YOffset = random.Next(0, 1) + random.NextDouble();
            MachineToolOffsets[offsetNo].ZOffset = random.Next(0, 5) + random.NextDouble();
            MachineToolOffsets[offsetNo].RadiusCompPattern = random.Next(0, 9);

            double radius = _TestRadiusOffsets[random.Next(0, 5)];
            MachineToolOffsets[offsetNo].XRadiusOffset = radius;
            MachineToolOffsets[offsetNo].ZRadiusOffset = radius;

            if (ToolWearOffsetExsitence)
                MachineToolOffsets[offsetNo].XWearOffset = random.NextDouble() / 200;
            if (ToolWearOffsetExsitence)
                MachineToolOffsets[offsetNo].ZWearOffset = random.NextDouble() / 200;
        }

        public void SetOffset(MachineToolOffset offset, bool zeroWearOffset)
        {
            MachineToolOffsets[offset.ID].XOffset = offset.XOffset;
            if (YAxisExsitence)
                MachineToolOffsets[offset.ID].YOffset = offset.YOffset;
            MachineToolOffsets[offset.ID].ZOffset = offset.ZOffset;
            MachineToolOffsets[offset.ID].RadiusCompPattern = offset.RadiusCompPattern;
            if (zeroWearOffset)
                MachineToolOffsets[offset.ID].XWearOffset = 0.0;
            if (zeroWearOffset)
                MachineToolOffsets[offset.ID].ZWearOffset = 0.0;
        }

        public void SetWearOffset(int offsetNo, ToolWearOffsetAxisIndexEnum axis, double value)
        {

        }

        public void AttachTool(int station, Tool tool, ToolLocationEnum turret)
        {

        }

        public void DetachTool(int station, ToolLocationEnum turret)
        {

        }

        public int GetToolNo(int station)
        {
            return 1;
        }

        private void UpdateAllToolOffets()
        {
            if (MachineToolOffsets == null)
                MachineToolOffsets = new List<MachineToolOffset>(ToolOffsetCount);
            for (int i = 0; i < ToolOffsetCount; i++)
            {
                UpdateOffset(i);
            }
        }
    }
}
