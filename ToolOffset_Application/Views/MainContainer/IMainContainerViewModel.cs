using ToolOffset_Application.Core;

namespace ToolOffset_Application.Views.MainContainer
{
    public interface IMainContainerViewModel : IViewModel
    {
        IView NavigationView { get; set; }
        IView MainView { get; set; }
    }
}
