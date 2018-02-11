using Okuma_ToolOffset_App.Models.AppModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okuma_ToolOffset_App.Models.AppModels.Interfaces
{
    public interface IBlockPosition
    {
        int ID { get; set; }
        string Name { get; set; }
        BlockSideEnum Side { get; set; }
        BlockPositionTypeEnum Type { get; set; }
        double XOffset { get; set; }
        double YOffset { get; set; }
        double ZOffset { get; set; }
    }
}
