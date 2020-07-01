using ToolOffset_Application.Core;
using ToolOffset_Application.Events.Navigation;
using ToolOffset_Application.Events.Selection;
using ToolOffset_Application.Views.BlockEdit;
using ToolOffset_Services.Interfaces;
using Unity;
using Unity.Resolution;

namespace ToolOffset_Application.Views.BlockList
{
    public class BlockListViewModel : BaseViewModel, IBlockListViewModel
    {
        public BlockListViewModel(IBlockListView view, IUnityContainer container,
            IUnitOfWork unitOfWork, INavigationEventAggregator navigationEventAggregator,
            ISelectionEventAggregator selectionEventAggregator)
            : base(view, container)
        {
            _unitOfWork = unitOfWork;
            _navigationEventAggregator = navigationEventAggregator;
            _selectionEventAggregator = selectionEventAggregator;
            NewBlockCommand = new DelegateCommand<object>(OnNewBlockExecute);
        }

        private readonly INavigationEventAggregator _navigationEventAggregator;
        private readonly ISelectionEventAggregator _selectionEventAggregator;
        private readonly IUnitOfWork _unitOfWork;

        public DelegateCommand<object> NewBlockCommand { get; set; }

        public void OnNewBlockExecute(object arg)
        {
            _navigationEventAggregator.PostMessage(new WindowRegionNavigationRequest(
                Container.Resolve<IBlockEditViewModel>(new ParameterOverride("id", 0))));
        }
    }
}
