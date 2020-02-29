using ToolOffset_Application.Wrappers.Base;
using ToolOffset_Models.Models.MountedTools.Blocks;

namespace ToolOffset_Application.Wrappers.BlockWrappers
{
    public class MountedBlockAssemblyWrapper : ModelWrapper<IMountedBlockAssembly>
    {
        public MountedBlockAssemblyWrapper(IMountedBlockAssembly model)
            : base(model)
        {
        }

        public BlockWrapper Block { get; private set; }
    }
}
