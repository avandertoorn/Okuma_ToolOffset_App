using ToolOffset_Application.Core;
using ToolOffset_Application.Events.Navigation;
using ToolOffset_Application.Events.Selection;
using ToolOffset_Application.Views.BlockEdit;
using ToolOffset_Models.Models.Tools;
using ToolOffset_Services.Interfaces;
using Unity;
using Unity.Resolution;

namespace ToolOffset_Application.Views.BlockSummary
{
    public class BlockSummaryViewModel : BaseDetailViewModel, IBlockSummaryViewModel
    {
        public BlockSummaryViewModel()
        {

        }

        public BlockSummaryViewModel(IBlockSummaryView view,
            IUnityContainer container, INavigationEventAggregator navigationEventAggregator,
            ISelectionEventAggregator selectionEventAggregator, IUnitOfWork unitOfWork)
        : base(view, container)
        {
            _navigationEventAggregator = navigationEventAggregator;
            _selectionEventAggregator = selectionEventAggregator;
            _selectionEventAggregator.RegisterHandler<BlockSelectionChanged>(SelectionChangedHandler);
            _unitOfWork = unitOfWork;
            EditCommand = new DelegateCommand<object>(OnEditExecute, EditCanExecute);
        }

        private readonly INavigationEventAggregator _navigationEventAggregator;
        private readonly ISelectionEventAggregator _selectionEventAggregator;
        private readonly IUnitOfWork _unitOfWork;

        private Block _blockAssembly;

        public Block BlockAssembly
        {
            get { return _blockAssembly; }
            set
            {
                if (value != _blockAssembly)
                {
                    _blockAssembly = value;
                    OnPropertyChanged("BlockAssembly");
                }
            }
        }

        public DelegateCommand<object> EditCommand { get; }

        private void SelectionChangedHandler(BlockSelectionChanged message)
        {
            BlockAssembly = _unitOfWork.BlockRepository.Get(message.ID);
        }

        private void OnEditExecute(object obj)
        {
            _navigationEventAggregator.PostMessage(new WindowRegionNavigationRequest(
                Container.Resolve<IBlockEditViewModel>(new ParameterOverride
                    ("id", BlockAssembly.ID))));
        }

        private bool EditCanExecute(object obj)
        {
            if (BlockAssembly != null)
                return true;

            return false;
        }
    }
}
