namespace ToolOffset_Application.Events.Selection
{
    public class BlockSelectionChanged
    {
        public int ID { get; }

        public BlockSelectionChanged(int id)
        {
            ID = id;
        }
    }
}
