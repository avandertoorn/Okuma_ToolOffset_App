using ToolOffset_Application.Core;
using ToolOffset_Application.Events.Attach;
using ToolOffset_Application.Events.Navigation;
using ToolOffset_Application.Events.Selection;
using ToolOffset_Application.Views.BlockSelectList;
using ToolOffset_Application.Views.ToolSelectList;
using ToolOffset_MachineModels.Models;
using ToolOffset_Models.Models.Lathe;
using ToolOffset_Services.Interfaces;
using Unity;
using Unity.Resolution;

namespace ToolOffset_Application.Views.StationDetail
{
    public class StationDetailViewModel : BaseDetailViewModel, IStationDetailViewModel
    {
        public StationDetailViewModel() { }

        public StationDetailViewModel(IStationDetailView view, IUnityContainer container,
            INavigationEventAggregator navigationEventAggregator,
            ISelectionEventAggregator selectionEventAggregator,
            IAttachEventAggregator attachEventAggregator,
            IUnitOfWork unitOfWork, ILathe lathe)
            : base(view, container)
        {
            _lathe = lathe;
            _unitOfWork = unitOfWork;
            _navigationEventAggregator = navigationEventAggregator;
            _selectionEventAggregator = selectionEventAggregator;
            _attachEventAggregator = attachEventAggregator;
            _selectionEventAggregator.RegisterHandler<StationSelectionChanged>(SelectionChangedHandler);
            SelectBlockCommand = new DelegateCommand<object>(OnSelectBlockExecute, SelectBlockCanExecute);
            BlockDettachCommand = new DelegateCommand<object>(OnBlockDettachExecute, BlockDettachCanExecute);
            SelectToolCommand = new DelegateCommand<object>(OnSelectToolExecute, SelectToolCanExecute);
            ToolDettachCommand = new DelegateCommand<object>(OnToolDettachExecute, ToolDettachCanExecute);
        }

        private readonly INavigationEventAggregator _navigationEventAggregator;
        private readonly ISelectionEventAggregator _selectionEventAggregator;
        private readonly IAttachEventAggregator _attachEventAggregator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILathe _lathe;

        private Turret _turret;

        private Station _station;

        public Station Station
        {
            get { return _station; }
            set
            {
                if (value != _station)
                {
                    _station = value;
                    OnPropertyChanged("Station");
                }
            }
        }

        public DelegateCommand<object> SelectBlockCommand { get; }
        public DelegateCommand<object> BlockDettachCommand { get; }
        public DelegateCommand<object> SelectToolCommand { get; }
        public DelegateCommand<object> ToolDettachCommand { get; }


        private void SelectionChangedHandler(StationSelectionChanged message)
        {
            Station = message.Selection;
            _turret = message.Turret;
        }

        private void OnSelectBlockExecute(object arg)
        {
            _attachEventAggregator.RegisterHandler<BlockAttachRequest>(BlockAttachRequestHandler);

            _navigationEventAggregator.PostMessage(
                new WindowRegionNavigationRequest(
                    Container.Resolve<IBlockSelectListViewModel>()));
        }

        private bool SelectBlockCanExecute(object arg)
        {
            if (Station == null)
                return false;

            if (Station.ToolBlock != null)
                return false;

            return true;
        }

        private void OnBlockDettachExecute(object arg)
        {
            Station.UnMountToolBlock();
            OnPropertyChanged("Station");
        }

        private bool BlockDettachCanExecute(object arg)
        {
            if (Station == null)
                return false;

            if (Station.ToolBlock == null)
                return false;

            return true;
        }

        private void OnSelectToolExecute(object arg)
        {
            MountedPosition pos = (MountedPosition)arg;

            _attachEventAggregator.RegisterHandler<ToolAttachRequest>(ToolAttachRequestHandler);

            _navigationEventAggregator.PostMessage(
                new WindowRegionNavigationRequest(
                    Container.Resolve<IToolSelectListViewModel>(new ResolverOverride[]
                    { new ParameterOverride("position", pos) })));
        }

        public bool SelectToolCanExecute(object arg)
        {
            MountedPosition pos = (MountedPosition)arg;
            if (pos.Tool == null)
                return true;

            return false;
        }

        private void OnToolDettachExecute(object arg)
        {
            //TODO
        }

        public bool ToolDettachCanExecute(object arg)
        {
            MountedPosition pos = (MountedPosition)arg;
            if (pos.Tool == null)
                return false;

            return true;
        }

        private void BlockAttachRequestHandler(BlockAttachRequest message)
        {
            //BlockAssembly block = _unitOfWork.BlockRepository.Get(message.ID);
            //Station.MountToolBlock(block, BlockOrientation.Foward);
            //OnPropertyChanged("Station");

            //_attachEventAggregator.UnRegisterHandler<BlockAttachRequest>(BlockAttachRequestHandler);
        }

        private void ToolAttachRequestHandler(ToolAttachRequest message)
        {
            //message.Position.MountTool(message.Tool);
            //foreach (var offset in message.MountedOffsets)
            //{
            //    message.Position.AddOffset(offset);
            //}
            //_attachEventAggregator.UnRegisterHandler<ToolAttachRequest>(ToolAttachRequestHandler);
        }
    }
}
