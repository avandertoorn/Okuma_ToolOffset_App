using System.Collections.ObjectModel;
using ToolOffset_Application.Core;
using ToolOffset_Application.Events.Attach;
using ToolOffset_Application.Events.Navigation;
using ToolOffset_Application.Views.MainRegion;
using ToolOffset_MachineModels.Models;
using ToolOffset_Models.Models;
using ToolOffset_Models.Models.MountedTools.Offsets;
using ToolOffset_Models.Models.MountedTools.Positions;
using ToolOffset_Models.Models.Tools;
using ToolOffset_Services.Interfaces;
using Unity;

namespace ToolOffset_Application.Views.ToolSelectList
{
    public class ToolSelectListViewModel : BaseViewModel, IToolSelectListViewModel
    {
        public ToolSelectListViewModel() { }

        public ToolSelectListViewModel(IToolSelectListView view, IUnityContainer container,
            INavigationEventAggregator navigationEventAggregator, IAttachEventAggregator attachEventAggregator,
            IUnitOfWork unitOfWork, ILathe lathe, MountedPosition position)
        : base(view, container)
        {
            _position = position;
            _unitOfWork = unitOfWork;
            _navigationEventAggregator = navigationEventAggregator;
            _attachEventAggregator = attachEventAggregator;
            _lathe = lathe;
            AttachCommand = new DelegateCommand<object>(OnAttachExecute, AttachCanExecute);
            CancelCommand = new DelegateCommand<object>(OnCancelExecute);
            OffsetAddCommand = new DelegateCommand<object>(OnAddOffset, SelectCanExecute);
            Tools = new ObservableCollection<Tool>(_unitOfWork.ToolRepository.GetAll());
            OffsetList = new ObservableCollection<MountedToolOffset>();
        }

        private readonly ILathe _lathe;
        private readonly IUnitOfWork _unitOfWork;
        private readonly INavigationEventAggregator _navigationEventAggregator;
        private readonly IAttachEventAggregator _attachEventAggregator;
        private readonly MountedPosition _position;

        private ObservableCollection<Tool> _tools;
        public ObservableCollection<Tool> Tools
        {
            get { return _tools; }
            set
            {
                if (value != _tools)
                {
                    _tools = value;
                    OnPropertyChanged("Tools");
                }
            }
        }

        private Tool _selectedTool;
        public Tool SelectedTool
        {
            get { return _selectedTool; }
            set
            {
                if (value != _selectedTool)
                {
                    _selectedTool = value;
                    OnPropertyChanged("SelectedTool");
                    OffsetList.Clear();
                }
            }
        }

        private ToolOffset _selectedToolOffset;
        public ToolOffset SelectedToolOffset
        {
            get { return _selectedToolOffset; }
            set
            {
                if (value != _selectedToolOffset)
                {
                    _selectedToolOffset = value;
                    OnPropertyChanged("SelectedToolOffset");
                }
            }
        }

        private ObservableCollection<MountedToolOffset> _offsetList;
        public ObservableCollection<MountedToolOffset> OffsetList
        {
            get { return _offsetList; }
            set
            {
                if (value != _offsetList)
                {
                    _offsetList = value;
                    OnPropertyChanged("OffsetList");
                }
            }
        }

        private MountedToolOffset _selectedMountedToolOffset;
        public MountedToolOffset SelectedMountedToolOffset
        {
            get { return _selectedMountedToolOffset; }
            set
            {
                if (value != _selectedMountedToolOffset)
                {
                    _selectedMountedToolOffset = value;
                    OnPropertyChanged("SelectedMountedToolOffset");
                }
            }
        }

        public DelegateCommand<object> AttachCommand { get; }
        public DelegateCommand<object> CancelCommand { get; }
        public DelegateCommand<object> OffsetAddCommand { get; }
        public DelegateCommand<object> Select2Command { get; }

        private void OnAttachExecute(object arg)
        {
            _attachEventAggregator.PostMessage(
                new ToolAttachRequest(
                    SelectedTool, _position, OffsetList));

            NavigateRequest();
        }

        private bool AttachCanExecute(object arg)
        {
            if (SelectedTool != null && OffsetList.Count > 0)
                return true;

            return false;
        }

        private void OnCancelExecute(object arg)
        {
            NavigateRequest();
        }

        public bool SelectCanExecute(object arg)
        {
            if (SelectedToolOffset != null)
                return true;


            return false;
        }

        public void OnAddOffset(object arg)
        {
            //TODO: impliment factory here
            OffsetList.Add(new MainSideAxialRegularMainOffset(SelectedToolOffset, _position));
        }

        private void NavigateRequest()
        {
            _navigationEventAggregator.PostMessage(
                new WindowRegionNavigationRequest(
                    Container.Resolve<IMainRegionViewModel>()));
        }
    }
}
