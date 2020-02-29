using ToolOffset_Application.Wrappers.Base;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Tools;

namespace ToolOffset_Application.Wrappers.BlockWrappers
{
    public class BlockWrapper : ModelWrapper<Block>
    {
        public BlockWrapper(Block model)
            : base(model)
        {
        }

        public int ID
        {
            get { return GetValue<int>("ID"); }
            set { SetValue(value, "ID"); }
        }

        public string Name
        {
            get { return GetValue<string>("Name"); }
            set { SetValue(value, "Name"); }
        }

        public string Comment
        {
            get { return GetValue<string>("Comment"); }
            set { SetValue(value, "Comment"); }
        }

        public BlockType BlockType
        {
            get { return GetValue<BlockType>("BlockType"); }
            set { SetValue(value, "BlockType"); }
        }
    }
}
