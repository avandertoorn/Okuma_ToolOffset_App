using Okuma_ToolOffset_App.Models.AppModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okuma_ToolOffset_App.Models.AppModels.Interfaces
{
    public interface IToolBlock
    {
        int ID { get; set; }
        string Name { get; set; }
        string Comment { get; set; }
        BlockTypeEnum BlockType { get; set; }
        IEnumerable<IBlockPosition> Positions { get; set; }
    }
}
