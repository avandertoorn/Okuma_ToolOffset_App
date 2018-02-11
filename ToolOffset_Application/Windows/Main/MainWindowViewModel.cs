using ToolOffset_Application.Core;
using ToolOffset_Application.Views.MainContainer;
using ToolOffset_Application.Views.TurretContainer;
using Unity;

namespace ToolOffset_Application.Windows.Main
{
    public class MainWindowViewModel : BaseWindowViewModel, IMainWindowViewModel
    {
        public MainWindowViewModel(IMainWindow window, IUnityContainer container)
        : base(window, container)
        {
            ShowView<IMainContainerViewModel>();
        }
    }
}
