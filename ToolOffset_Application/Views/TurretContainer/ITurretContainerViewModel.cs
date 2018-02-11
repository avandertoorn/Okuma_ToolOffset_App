using ToolOffset_Application.Core;

namespace ToolOffset_Application.Views.TurretContainer
{
    public interface ITurretContainerViewModel : IViewModel
    {
        IView LeftView { get; }
        IView RightView { get; }
    }
}
