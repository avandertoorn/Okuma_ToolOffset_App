using ToolOffset_Application.Core;
using Unity;

namespace ToolOffset_Application.Views.ToolEdit
{
    public class ToolEditViewModel : BaseViewModel, IToolEditViewModel
    {
        public ToolEditViewModel(IToolEditView view, IUnityContainer container)
            : base(view, container)
        {

        }
    }
}
