namespace ToolOffset_Application.Events.Selection
{
    public class ToolSelectionChanged
    {
        public int ID { get; }

        public ToolSelectionChanged(int id)
        {
            ID = id;
        }
    }
}
