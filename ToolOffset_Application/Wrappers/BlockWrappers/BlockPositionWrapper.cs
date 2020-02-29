using ToolOffset_Application.Wrappers.Base;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Tools;

namespace ToolOffset_Application.Wrappers.BlockWrappers
{
    public class BlockPositionWrapper : ModelWrapper<BlockPosition>
    {
        public BlockPositionWrapper(BlockPosition model)
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

        public BlockPositionSide Side
        {
            get { return GetValue<BlockPositionSide>("Side"); }
            set { SetValue(value, "Side"); }
        }

        public BlockPositionHand Hand
        {
            get { return GetValue<BlockPositionHand>("Hand"); }
            set { SetValue(value, "Hand"); }
        }

        public double XOffset
        {
            get { return GetValue<double>("XOffset"); }
            set { SetValue(value, "XOffset"); }
        }

        public double YOffset
        {
            get { return GetValue<double>("YOffset"); }
            set { SetValue(value, "YOffset"); }
        }

        public double ZOffset
        {
            get { return GetValue<double>("ZOffset"); }
            set { SetValue(value, "ZOffset"); }
        }
    }
}
