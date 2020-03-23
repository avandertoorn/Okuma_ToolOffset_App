using System.Collections.ObjectModel;
using ToolOffset_Application.Core;
using ToolOffset_Application.Events.Attach;
using ToolOffset_Application.Events.Navigation;
using ToolOffset_Application.Views.MainRegion;
using ToolOffset_Models.Models.Tools;
using ToolOffset_Services.Interfaces;
using Unity;

namespace ToolOffset_Application.Views.BlockSelectList
{
    public class BlockSelectListViewModel : BaseViewModel, IBlockSelectListViewModel
    {
        public BlockSelectListViewModel() { }

        public BlockSelectListViewModel(IBlockSelectListView view, IUnityContainer container,
            IUnitOfWork unitOfWork, INavigationEventAggregator navigationEventAggregator,
            IAttachEventAggregator attachEventAggregator)
            : base(view, container)
        {
            _navigationEventAggregator = navigationEventAggregator;
            _attachEventAggregator = attachEventAggregator;
            _unitOfWork = unitOfWork;
            AttachCommand = new DelegateCommand<object>(OnAttachExecute, AttachCanExecute);
            CancelCommand = new DelegateCommand<object>(OnCancelExecute);
            Blocks = new ObservableCollection<Block>(_unitOfWork.Blocks.GetAll());
        }


        private readonly INavigationEventAggregator _navigationEventAggregator;
        private readonly IAttachEventAggregator _attachEventAggregator;
        private readonly IUnitOfWork _unitOfWork;

        private ObservableCollection<Block> _blocks;

        public ObservableCollection<Block> Blocks
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

        private Block _selectedBlock;

        public Block SelectedBlock
        {
            get { return _selectedBlock; }
            set
            {
                if (value != _selectedBlock)
                {
                    _selectedBlock = value;
                    OnPropertyChanged("SelectedBlock");
                }
            }
        }

        public DelegateCommand<object> AttachCommand { get; }
        public DelegateCommand<object> CancelCommand { get; }

        private void OnAttachExecute(object arg)
        {
            _attachEventAggregator.PostMessage(
                new BlockAttachRequest(SelectedBlock.BlockNo));

            NavigateRequest();
        }

        private bool AttachCanExecute(object arg)
        {
            if (SelectedBlock != null)
                return true;

            return false;
        }

        private void OnCancelExecute(object arg)
        {
            NavigateRequest();
        }

        private void NavigateRequest()
        {
            _navigationEventAggregator.PostMessage(
                new WindowRegionNavigationRequest(
                    Container.Resolve<IMainRegionViewModel>()));
        }
    }
}
