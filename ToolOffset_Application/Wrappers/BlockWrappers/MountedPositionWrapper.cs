using ToolOffset_Application.Wrappers.Base;
using ToolOffset_Models.Models.MountedTools.Positions;

namespace ToolOffset_Application.Wrappers.BlockWrappers
{
    public class MountedPositionWrapper : ModelWrapper<IMountedPosition>
    {
        public MountedPositionWrapper(IMountedPosition model)
            : base(model)
        {
        }


    }
}
