using ToolOffset_Application.Core;
using Unity;

namespace ToolOffset_Application.Views.BlockList
{
    public class BlockListViewModel : BaseViewModel, IBlockListViewModel
    {
        public BlockListViewModel(IBlockListView view, IUnityContainer container)
            : base(view, container)
        {

        }
    }
}
