using Okuma_ToolOffset_App.LatheUtilities;
using Okuma_ToolOffset_App.Models.MachineModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okuma_ToolOffset_App.Models
{
    public class LatheUnitOfWork
    {
        public Turret Turret { get; private set; }
        public IOkumaLathe Lathe { get; private set; }
        

        public LatheUnitOfWork()
        {
            Lathe = OkuamAPIFactory.GetAPI();
            Turret = new Turret(Lathe.StationCount);
        }

        public void SetOffset()
        {
        }
    }
}
