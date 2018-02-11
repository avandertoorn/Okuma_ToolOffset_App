using ToolOffset_Application.Core;
using ToolOffset_Application.Views.BlockEdit;
using ToolOffset_Application.Views.BlockLibrary;
using ToolOffset_Application.Views.BlockList;
using ToolOffset_Application.Views.MainContainer;
using ToolOffset_Application.Views.Navigation;
using ToolOffset_Application.Views.StationDetail;
using ToolOffset_Application.Views.ToolEdit;
using ToolOffset_Application.Views.ToolLibrary;
using ToolOffset_Application.Views.ToolList;
using ToolOffset_Application.Views.TurretContainer;
using ToolOffset_Application.Views.TurretMagazine;
using ToolOffset_Application.Windows.Main;
using ToolOffset_Services.Interfaces;
using ToolOffset_Services.Repositories;
using ToolOffset_Services.UnitOfWork;
using Unity;
using Unity.Lifetime;

namespace ToolOffset_Application
{
    public class Bootstrapper
    {
        public IUnityContainer Bootstrap()
        {
            return Register();
        }
        
        public IUnityContainer Register()
        {
            var container = new UnityContainer();

            container.RegisterType<IUnitOfWork, UnitOfWork>(new ContainerControlledLifetimeManager());
            container.RegisterType<IBlockRepository, BlockRepository>();
            container.RegisterType<IToolRepository, ToolRepository>();
            container.RegisterType<ITurretRepository, TurretRepository>();
            container.RegisterType<IEventAggregator, EventAggregator>(new ContainerControlledLifetimeManager());

            container.RegisterType<IMainWindowViewModel, MainWindowViewModel>();
            container.RegisterType<IBlockEditViewModel, BlockEditViewModel>();
            container.RegisterType<IBlockLibraryViewModel, BlockLibraryViewModel>();
            container.RegisterType<IBlockListViewModel, BlockListViewModel>();
            container.RegisterType<IMainContainerViewModel, MainContainerViewModel>();
            container.RegisterType<INavigationViewModel, NavigationViewModel>();
            container.RegisterType<IToolEditViewModel, ToolEditViewModel>();
            container.RegisterType<IToolListViewModel, ToolListViewModel>();
            container.RegisterType<IToolLibraryViewModel, ToolLibraryViewModel>();
            container.RegisterType<ITurretContainerViewModel, TurretContainerViewModel>();
            container.RegisterType<ITurretMagazineViewModel, TurretMagazineViewModel>(new ContainerControlledLifetimeManager());
            container.RegisterType<IStationDetailViewModel, StationDetailViewModel>();

            container.RegisterType<IMainWindow, MainWindow>();
            container.RegisterType<IBlockEditView, BlockEditView>();
            container.RegisterType<IBlockLibraryView, BlockLibraryView>();
            container.RegisterType<IBlockListView, BlockListView>();
            container.RegisterType<IMainContainerView, MainContainerView>();
            container.RegisterType<INavigationView, NavigationView>();
            container.RegisterType<IToolEditView, ToolEditView>();
            container.RegisterType<IToolListView, ToolListView>();
            container.RegisterType<IToolLibraryView, ToolLibraryView>();
            container.RegisterType<ITurretContainerView, TurretContainerView>();
            container.RegisterType<ITurretMagazineView, TurretMagazineView>();
            container.RegisterType<IStationDetailView, StationDetailView>();

            return container;
        }
    }
}
