using ToolOffset_Application.Core;

namespace ToolOffset_Application.Views.MainRegion
{
    public interface IMainRegionViewModel : IViewModel
    {
        IView NavigationView { get; set; }
        IView MainView { get; set; }
    }
}
