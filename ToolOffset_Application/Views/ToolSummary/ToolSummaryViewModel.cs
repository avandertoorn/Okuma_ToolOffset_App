using ToolOffset_Application.Core;
using ToolOffset_Application.Events.Navigation;
using ToolOffset_Application.Events.Selection;
using ToolOffset_Application.Views.ToolEdit;
using ToolOffset_Models.Models.Tools;
using ToolOffset_Services.Interfaces;
using Unity;
using Unity.Resolution;

namespace ToolOffset_Application.Views.ToolSummary
{
    public class ToolSummaryViewModel : BaseDetailViewModel, IToolSummaryViewModel
    {
        public ToolSummaryViewModel()
        {

        }

        public ToolSummaryViewModel(IToolSummaryView view, IUnityContainer container,
            INavigationEventAggregator navigationEventAggregator,
            ISelectionEventAggregator selectionEventAggregator, IUnitOfWork unitOfWork)
            : base(view, container)
        {
            _unitOfWork = unitOfWork;
            _navigationEventAggregator = navigationEventAggregator;
            _selectionEventAggregator = selectionEventAggregator;
            _selectionEventAggregator.RegisterHandler<ToolSelectionChanged>(SelectionChangedHandler);
            EditCommand = new DelegateCommand<object>(OnEditExecute, EditCanExecute);
        }

        private readonly INavigationEventAggregator _navigationEventAggregator;
        private readonly ISelectionEventAggregator _selectionEventAggregator;
        private readonly IUnitOfWork _unitOfWork;

        private Tool _tool;

        public Tool Tool
        {
            get { return _tool; }
            set
            {
                if (value != _tool)
                {
                    _tool = value;
                    OnPropertyChanged("Tool");
                }
            }
        }

        public DelegateCommand<object> EditCommand { get; }

        private void SelectionChangedHandler(ToolSelectionChanged message)
        {
            Tool = _unitOfWork.ToolRepository.Get(message.ID);
        }

        private void OnEditExecute(object obj)
        {
            _navigationEventAggregator.PostMessage(new WindowRegionNavigationRequest(
                Container.Resolve<IToolEditViewModel>(new ParameterOverride
                    ("id", Tool.ToolNo))));
        }

        private bool EditCanExecute(object obj)
        {
            if (Tool != null)
                return true;

            return false;
        }
    }
}
