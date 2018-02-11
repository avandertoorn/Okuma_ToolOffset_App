using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolOffset_Models.Models.Machine;

namespace ToolOffset_Application
{
    public interface ILathe
    {
        Turret ATurret { get; }
        Turret BTurret { get; }
        Turret CTurret { get; }
    }
}
