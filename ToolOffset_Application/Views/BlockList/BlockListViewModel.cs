using System.Collections.ObjectModel;
using System.Linq;
using ToolOffset_Application.Core;
using ToolOffset_Application.Events.Navigation;
using ToolOffset_Application.Events.Selection;
using ToolOffset_Application.Views.BlockEdit;
using ToolOffset_Models.Models.Tools;
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
            Blocks = new ObservableCollection<BlockAssembly>(_unitOfWork.BlockRepository.GetAll().OrderBy(a => a.Block.Name));
            _navigationEventAggregator = navigationEventAggregator;
            _selectionEventAggregator = selectionEventAggregator;
            NewBlockCommand = new DelegateCommand<object>(OnNewBlockExecute);
        }

        private readonly INavigationEventAggregator _navigationEventAggregator;
        private readonly ISelectionEventAggregator _selectionEventAggregator;
        private readonly IUnitOfWork _unitOfWork;
        private ObservableCollection<BlockAssembly> _blocks;
        private BlockAssembly _selectedBlock;

        public ObservableCollection<BlockAssembly> Blocks
        {
            get { return _blocks; }
            set
            {
                if (value != _blocks)
                {
                    _blocks = value;
                    OnPropertyChanged("Blocks");
                }
            }
        }

        public BlockAssembly SelectedBlock
        {
            get { return _selectedBlock; }
            set
            {
                if (value != _selectedBlock)
                {
                    _selectedBlock = value;
                    OnPropertyChanged("SelectedBlock");
                    _selectionEventAggregator.PostMessage(new BlockSelectionChanged(SelectedBlock.Block.ID));
                }
            }
        }

        public DelegateCommand<object> NewBlockCommand { get; set; }

        public void OnNewBlockExecute(object arg)
        {
            _navigationEventAggregator.PostMessage(new WindowRegionNavigationRequest(
                Container.Resolve<IBlockEditViewModel>(new ParameterOverride("id", 0))));
        }
    }
}
