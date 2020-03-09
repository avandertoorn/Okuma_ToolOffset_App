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

        private Block _block;

        public Block Block
        {
            get { return _block; }
            set
            {
                if (value != _block)
                {
                    _block = value;
                    OnPropertyChanged("Block");
                }
            }
        }

        public DelegateCommand<object> EditCommand { get; }

        private void SelectionChangedHandler(BlockSelectionChanged message)
        {
            Block = _unitOfWork.BlockRepository.Get(message.ID);
        }

        private void OnEditExecute(object obj)
        {
            _navigationEventAggregator.PostMessage(new WindowRegionNavigationRequest(
                Container.Resolve<IBlockEditViewModel>(new ParameterOverride
                    ("id", Block.BlockNo))));
        }

        private bool EditCanExecute(object obj)
        {
            if (Block != null)
                return true;

            return false;
        }
    }
}
