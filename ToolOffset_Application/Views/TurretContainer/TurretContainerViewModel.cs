using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using ToolOffset_Application.Core;
using ToolOffset_Application.Views.StationDetail;
using ToolOffset_Application.Views.TurretMagazine;
using Unity;

namespace ToolOffset_Application.Views.TurretContainer
{
    public class TurretContainerViewModel : BaseViewModel, ITurretContainerViewModel
    {
        public IView LeftView { get; private set; }
        public IView RightView { get; private set; }

        public TurretContainerViewModel()
        {
            LeftView = new TurretMagazineView();
            RightView = new StationDetailView();
        }

        public TurretContainerViewModel(ITurretContainerView view, IUnityContainer container)
            : base(view, container)
        {
            ShowLeftView<ITurretMagazineViewModel>();
            ShowRightView<IStationDetailViewModel>();
        }

        public void ShowLeftView<T>() where T : IViewModel
        {
            LeftView = Container.Resolve<T>().View;
        }

        public void ShowRightView<T>() where T : IViewModel
        {
            RightView = Container.Resolve<T>().View;
        }
    }
}
