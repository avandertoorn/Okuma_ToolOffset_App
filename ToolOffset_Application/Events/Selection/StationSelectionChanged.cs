using ToolOffset_Models.Models.Lathe;

namespace ToolOffset_Application.Events.Selection
{
    public class StationSelectionChanged
    {
        public Station Selection { get; private set; }
        public Turret Turret { get; private set; }

        public StationSelectionChanged(Station selection, Turret turret)
        {
            Selection = selection;
            Turret = turret;
        }
    }
}
