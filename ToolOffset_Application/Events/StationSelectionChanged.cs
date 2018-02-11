using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToolOffset_Models.Models.Machine;

namespace ToolOffset_Application.Events
{
    public class StationSelectionChanged
    {
        public Station Selection { get; private set; }

        public StationSelectionChanged(Station selection)
        {
            Selection = selection;
        }
    }
}
