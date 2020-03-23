using ToolOffset_Application.Events.Attach;
using ToolOffset_Application.Events.Navigation;
using ToolOffset_Application.Events.Selection;
using ToolOffset_Application.Views.BlockEdit;
using ToolOffset_Application.Views.BlockLibrary;
using ToolOffset_Application.Views.BlockList;
using ToolOffset_Application.Views.BlockSelectList;
using ToolOffset_Application.Views.BlockSummary;
using ToolOffset_Application.Views.MainRegion;
using ToolOffset_Application.Views.Navigation;
using ToolOffset_Application.Views.StationDetail;
using ToolOffset_Application.Views.ToolEdit;
using ToolOffset_Application.Views.ToolLibrary;
using ToolOffset_Application.Views.ToolList;
using ToolOffset_Application.Views.ToolSelectList;
using ToolOffset_Application.Views.ToolSummary;
using ToolOffset_Application.Views.TurretContainer;
using ToolOffset_Application.Views.TurretMagazine;
using ToolOffset_Application.Windows.Main;
using ToolOffset_MachineModels.Models;
using ToolOffset_Services;
using ToolOffset_Services.Interfaces;
using ToolOffset_Services.Repositories;
using ToolOffset_Services.UnitOfWork;
using Unity;
using Unity.Lifetime;

namespace ToolOffset_Application
{
    public class Bootstrapper
    {
        private readonly IUnityContainer _container;

        public Bootstrapper()
        {
            _container = new UnityContainer();
        }

        public IUnityContainer Bootstrap()
        {
            Register();
            return _container;
        }

        private void Register()
        {
            _container.RegisterType<ApplicationDbContext>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IUnitOfWork, UnitOfWork>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IBlockRepository, BlockRepository>();
            _container.RegisterType<IToolRepository, ToolRepository>();
            _container.RegisterType<ITurretRepository, TurretRepository>();

            _container.RegisterType<INavigationEventAggregator, NavigationEventAggregator>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IAttachEventAggregator, AttachEventAggregator>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ISelectionEventAggregator, SelectionEventAggregator>(new ContainerControlledLifetimeManager());

            _container.RegisterType<ILathe, Lathe>(new ContainerControlledLifetimeManager());

            _container.RegisterType<IMainWindowViewModel, MainWindowViewModel>();
            _container.RegisterType<IBlockEditViewModel, BlockEditViewModel>();
            _container.RegisterType<IBlockLibraryViewModel, BlockLibraryViewModel>();
            _container.RegisterType<IBlockListViewModel, BlockListViewModel>();
            _container.RegisterType<IBlockSelectListViewModel, BlockSelectListViewModel>();
            _container.RegisterType<IBlockSummaryViewModel, BlockSummaryViewModel>();
            _container.RegisterType<IMainRegionViewModel, MainRegionViewModel>(new ContainerControlledLifetimeManager());
            _container.RegisterType<INavigationViewModel, NavigationViewModel>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IToolEditViewModel, ToolEditViewModel>();
            _container.RegisterType<IToolListViewModel, ToolListViewModel>();
            _container.RegisterType<IToolLibraryViewModel, ToolLibraryViewModel>();
            _container.RegisterType<IToolSelectListViewModel, ToolSelectListViewModel>();
            _container.RegisterType<IToolSummaryViewModel, ToolSummaryViewModel>();
            _container.RegisterType<ITurretContainerViewModel, TurretContainerViewModel>();
            _container.RegisterType<ITurretMagazineViewModel, TurretMagazineViewModel>(new ContainerControlledLifetimeManager());
            _container.RegisterType<IStationDetailViewModel, StationDetailViewModel>(new ContainerControlledLifetimeManager());

            _container.RegisterType<IMainWindow, MainWindow>();
            _container.RegisterType<IBlockEditView, BlockEditView>();
            _container.RegisterType<IBlockLibraryView, BlockLibraryView>();
            _container.RegisterType<IBlockListView, BlockListView>();
            _container.RegisterType<IBlockSelectListView, BlockSelectListView>();
            _container.RegisterType<IBlockSummaryView, BlockSummaryView>();
            _container.RegisterType<IMainRegionView, MainRegionView>();
            _container.RegisterType<INavigationView, NavigationView>();
            _container.RegisterType<IToolEditView, ToolEditView>();
            _container.RegisterType<IToolListView, ToolListView>();
            _container.RegisterType<IToolLibraryView, ToolLibraryView>();
            _container.RegisterType<IToolSelectListView, ToolSelectListView>();
            _container.RegisterType<IToolSummaryView, ToolSummaryView>();
            _container.RegisterType<ITurretContainerView, TurretContainerView>();
            _container.RegisterType<ITurretMagazineView, TurretMagazineView>();
            _container.RegisterType<IStationDetailView, StationDetailView>();
        }
    }
}
