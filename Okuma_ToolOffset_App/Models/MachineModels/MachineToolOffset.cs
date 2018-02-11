using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okuma_ToolOffset_App.Models.MachineModels
{
    public class MachineToolOffset
    {
        public int ID { get; set; }
        public double XOffset { get; set; }
        public double YOffset { get; set; }
        public double ZOffset { get; set; }
        public double XRadiusOffset { get; set; }
        public double ZRadiusOffset { get; set; }
        public int RadiusCompPattern { get; set; }
        public double XWearOffset { get; set; }
        public double ZWearOffset { get; set; }
    }
}
