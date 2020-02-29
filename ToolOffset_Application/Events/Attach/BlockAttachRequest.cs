namespace ToolOffset_Application.Events.Attach
{
    public class BlockAttachRequest
    {
        public int ID { get; }

        public BlockAttachRequest(int id)
        {
            ID = id;
        }
    }
}
