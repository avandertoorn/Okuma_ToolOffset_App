using ToolOffset_Application.Core;
using ToolOffset_Application.Events.Navigation;
using ToolOffset_Application.Views.StationDetail;
using ToolOffset_Application.Views.TurretMagazine;
using Unity;

namespace ToolOffset_Application.Views.TurretContainer
{
    public class TurretContainerViewModel : BaseViewModel, ITurretContainerViewModel
    {

        public TurretContainerViewModel(ITurretContainerView view,
            IUnityContainer container, INavigationEventAggregator navigationEventAggregator)
            : base(view, container)
        {
            _navigationEventAggregator = navigationEventAggregator;
            _navigationEventAggregator.RegisterHandler<TurretLeftRegionNavigationRequest>(NavigationRequestHandler);
            RightView = Container.Resolve<IStationDetailViewModel>().View;
            LeftView = Container.Resolve<ITurretMagazineViewModel>().View;
        }

        private readonly INavigationEventAggregator _navigationEventAggregator;

        private IView _leftView;

        public IView LeftView
        {
            get { return _leftView; }
            set
            {
                if (value != _leftView)
                {
                    _leftView = value;
                    OnPropertyChanged("LeftView");
                }
            }
        }

        private IView _rightView;

        public IView RightView
        {
            get { return _rightView; }
            set
            {
                if (value != _rightView)
                {
                    _rightView = value;
                    OnPropertyChanged("RightView");
                }
            }
        }

        public TurretContainerViewModel()
        {
        }

        private void NavigationRequestHandler(TurretLeftRegionNavigationRequest request)
        {
            LeftView = request.ViewModel.View;
        }
    }
}
