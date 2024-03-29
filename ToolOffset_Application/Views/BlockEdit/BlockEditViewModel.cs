﻿using System.Collections.Generic;
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

            //TODO: Initialize Wrapper
        }

        private readonly ILathe _lathe;
        private readonly INavigationEventAggregator _navigationEventAggregator;
        private readonly IUnitOfWork _unitOfWork;

        private BlockWrapper _block;

        public BlockWrapper Block
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
            Block.RejectChanges();
            NavigateToMainRegion();
        }

        private void OnPositionDeleteBunttonExecute(object arg)
        {
            Block.Positions.Remove(SelectedPostion);
        }

        private bool PositionDeleteButtonCanExecute(object arg)
        {
            if (SelectedPostion != null)
                return !_lathe.BlockPositionInUse(SelectedPostion.Model);

            return false;
        }

        private void OnSaveButtonExectute(object obj)
        {
            foreach (var position in Block.Positions.ModifiedItems)
            {
                //TODO
            }

            if (Block.Positions.AddedItems.Count > 0)
            {
                List<Position> addedPositions = new List<Position>(Block.Positions.AddedItems.Count);
                foreach (var pos in Block.Positions.AddedItems)
                {
                    addedPositions.Add(pos.Model);
                }
            }

            if (Block.Positions.RemovedItems.Count > 0)
            {
                List<Position> removedPositions = new List<Position>(Block.Positions.RemovedItems.Count);
                foreach (var pos in Block.Positions.RemovedItems)
                {
                    removedPositions.Add(pos.Model);
                }
            }

            Block.AcceptChanges();
            //TODO:
            //_unitOfWork.BlockRepository.Update(Block.Model);
            NavigateToMainRegion();
        }

        private bool SaveButtonCanExecute(object obj)
        {
            return Block.IsChanged;
        }

        private void OnPositionAddButtonExectute(object obj)
        {
            //Block.Positions.Add(new PositionWrapper(new Position()));
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
