using System.Collections.Generic;
using ToolOffset_Application.Core;
using ToolOffset_Application.Events.Navigation;
using ToolOffset_Application.Views.MainRegion;
using ToolOffset_Application.Wrappers.BlockWrappers;
using ToolOffset_MachineModels.Models;
using ToolOffset_Models.Models.Tools;
using ToolOffset_Services.Interfaces;
using Unity;

namespace ToolOffset_Application.Views.BlockEdit
{
    public class BlockEditViewModel : BaseDetailViewModel, IBlockEditViewModel
    {
        public BlockEditViewModel() { }

        public BlockEditViewModel(IBlockEditView view, IUnityContainer container,
            INavigationEventAggregator navigationEventAggregator, IUnitOfWork unitOfWork, ILathe lathe, int id = 0)
            : base(view, container)
        {
            ID = id;
            _unitOfWork = unitOfWork;
            _navigationEventAggregator = navigationEventAggregator;
            _lathe = lathe;
            CancelButtonCommand = new DelegateCommand<object>(OnCancelButtonExecute);
            PositionAddButtonCommand = new DelegateCommand<object>(OnPositionAddButtonExectute, PositionAddButtonCanExecute);
            PositionDeleteButtonCommand = new DelegateCommand<object>(OnPositionDeleteBunttonExecute, PositionDeleteButtonCanExecute);
            SaveButtonCommand = new DelegateCommand<object>(OnSaveButtonExectute, SaveButtonCanExecute);
            if (ID > 0)
                _blockAssembly = new BlockAssemblyWrapper(_unitOfWork.BlockRepository.Get(ID));
            else
                _blockAssembly = new BlockAssemblyWrapper(
                    new BlockAssembly(new Block(), new List<Position>()));


        }

        private readonly ILathe _lathe;
        private readonly INavigationEventAggregator _navigationEventAggregator;
        private readonly IUnitOfWork _unitOfWork;

        private BlockAssemblyWrapper _blockAssembly;

        public BlockAssemblyWrapper BlockAssembly
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

        private PositionWrapper _selectedPosition;

        public PositionWrapper SelectedPostion
        {
            get { return _selectedPosition; }
            set
            {
                if (value != _selectedPosition)
                {
                    _selectedPosition = value;
                    OnPropertyChanged("SelectedPosition");
                }
            }
        }

        public DelegateCommand<object> CancelButtonCommand { get; }
        public DelegateCommand<object> PositionAddButtonCommand { get; }
        public DelegateCommand<object> PositionDeleteButtonCommand { get; }
        public DelegateCommand<object> SaveButtonCommand { get; }


        private void OnCancelButtonExecute(object obj)
        {
            BlockAssembly.RejectChanges();
            NavigateToMainRegion();
        }

        private void OnPositionDeleteBunttonExecute(object arg)
        {
            BlockAssembly.Positions.Remove(SelectedPostion);
        }

        private bool PositionDeleteButtonCanExecute(object arg)
        {
            if (SelectedPostion != null)
                return !_lathe.BlockPositionInUse(SelectedPostion.Model);

            return false;
        }

        private void OnSaveButtonExectute(object obj)
        {
            foreach (var position in BlockAssembly.Positions.ModifiedItems)
            {
                //TODO
            }

            if (BlockAssembly.Positions.AddedItems.Count > 0)
            {
                List<Position> addedPositions = new List<Position>(BlockAssembly.Positions.AddedItems.Count);
                foreach (var pos in BlockAssembly.Positions.AddedItems)
                {
                    addedPositions.Add(pos.Model);
                }
                _lathe.BlockPositionAddedUpdate(BlockAssembly.Model, addedPositions);
            }

            if (BlockAssembly.Positions.RemovedItems.Count > 0)
            {
                List<Position> removedPositions = new List<Position>(BlockAssembly.Positions.RemovedItems.Count);
                foreach (var pos in BlockAssembly.Positions.RemovedItems)
                {
                    removedPositions.Add(pos.Model);
                }
                _lathe.BlockPositionsRemovedUpdate(BlockAssembly.Model, removedPositions);
            }

            BlockAssembly.AcceptChanges();
            _unitOfWork.BlockRepository.Update(BlockAssembly.Model, ID);
            NavigateToMainRegion();
        }

        private bool SaveButtonCanExecute(object obj)
        {
            return BlockAssembly.IsChanged;
        }

        private void OnPositionAddButtonExectute(object obj)
        {
            BlockAssembly.Positions.Add(new PositionWrapper(new Position(new BlockPosition())));
        }

        private bool PositionAddButtonCanExecute(object obj)
        {
            return true;
        }

        private void NavigateToMainRegion()
        {
            _navigationEventAggregator.PostMessage(new WindowRegionNavigationRequest(
                    Container.Resolve<IMainRegionViewModel>()));
        }


    }
}
