using ToolOffset_Application.Core;
using Unity;

namespace ToolOffset_Application.Views.ToolList
{
    public class ToolListViewModel : BaseViewModel, IToolListViewModel
    {
        public ToolListViewModel(IToolListView view, IUnityContainer container)
            : base(view, container)
        {

        }
    }
}
