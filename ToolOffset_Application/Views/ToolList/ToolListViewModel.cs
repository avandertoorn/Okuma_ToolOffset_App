using System.Collections.ObjectModel;
using ToolOffset_Application.Core;
using ToolOffset_Application.Events.Navigation;
using ToolOffset_Application.Events.Selection;
using ToolOffset_Application.Views.ToolEdit;
using ToolOffset_Models.Models.Tools;
using ToolOffset_Services.Interfaces;
using Unity;
using Unity.Resolution;

namespace ToolOffset_Application.Views.ToolList
{
    public class ToolListViewModel : BaseViewModel, IToolListViewModel
    {
        public ToolListViewModel(IToolListView view, IUnityContainer container,
            INavigationEventAggregator navigationEventAggregator,
            ISelectionEventAggregator selectionEventAggregator, IUnitOfWork unitOfWork)
            : base(view, container)
        {
            _unitOfWork = unitOfWork;
            _navigationEventAggregator = navigationEventAggregator;
            _selectionEventAggregator = selectionEventAggregator;
            Tools = new ObservableCollection<Tool>(_unitOfWork.Tools.GetAll());
            NewToolCommand = new DelegateCommand<object>(OnNewToolExecute);
        }

        private readonly INavigationEventAggregator _navigationEventAggregator;
        private readonly ISelectionEventAggregator _selectionEventAggregator;
        private readonly IUnitOfWork _unitOfWork;

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
                    _selectionEventAggregator.PostMessage(new ToolSelectionChanged(SelectedTool.Id));
                }
            }
        }

        public DelegateCommand<object> NewToolCommand { get; set; }

        public void OnNewToolExecute(object arg)
        {
            _navigationEventAggregator.PostMessage(new WindowRegionNavigationRequest(
                Container.Resolve<IToolEditViewModel>(new ParameterOverride("id", 0))));
        }

    }
}
