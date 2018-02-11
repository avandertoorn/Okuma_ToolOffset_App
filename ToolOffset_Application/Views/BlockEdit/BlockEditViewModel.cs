using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using ToolOffset_Application.Core;
using ToolOffset_Models.Models.Tools;
using Unity;

namespace ToolOffset_Application.Views.BlockEdit
{
    public class BlockEditViewModel : BaseViewModel, IBlockEditViewModel
    {
        private BlockAssembly _blockAssebly;

        public BlockAssembly BlockAssembly
        {
            get { return _blockAssebly; }
            set
            {
                if(value != _blockAssebly)
                {
                    _blockAssebly = value;
                    OnPropertyChanged("BlockAssemly");
                }
            }
        }
        public string Title { get; private set; }
        public bool IsNotEditing { get; set; } = true;
        public int EditPositionID
        {
            get { return EditPositionID; }
            set
            {
                EditPositionID = value;
                OnPropertyChanged("EditPositionID");
            }
        }

        public DelegateCommand<object> DeleteButtonCommand { get; set; }
        public DelegateCommand<object> EditButtonCommand { get; set; }
        public DelegateCommand<object> SaveButtonCommand { get; set; }
        public DelegateCommand<object> NewPositionButtonCommand { get; set; }

        public BlockEditViewModel() { }

        public BlockEditViewModel(IBlockEditView view, IUnityContainer container)
            : base(view, container)
        {
            DeleteButtonCommand = new DelegateCommand<object>(OnDeleteBunttonExecute, DeleteButtonCanExecute);
            EditButtonCommand = new DelegateCommand<object>(OnEditButtonExectute, EditButtonCanExecute);
            SaveButtonCommand = new DelegateCommand<object>(OnSaveButtonExectute, SaveButtonCanExecute);
            NewPositionButtonCommand = new DelegateCommand<object>(OnNewButtonExectute, NewButtonCanExecute);
            BlockAssembly = new BlockAssembly(new Block(), new List<Position>());
        }

        public void OnDeleteBunttonExecute(object arg)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                BlockAssembly.DeletePosition((Position)arg);
            }
            else
                return;
        }

        public bool DeleteButtonCanExecute(object arg)
        {
            if (BlockAssembly.Positions.Count > 0 && IsNotEditing == true)
                return true;
            else
                return false;
        }

        private void OnEditButtonExectute(object obj)
        {
            Position pos = (Position)obj;
            EditPositionID = pos.BlockPosition.ID;
        }

        private bool EditButtonCanExecute(object obj)
        {
            return IsNotEditing;
        }

        private void OnSaveButtonExectute(object obj)
        {
            
        }

        private bool SaveButtonCanExecute(object obj)
        {
            Position pos = (Position)obj;
            if (IsNotEditing == false && pos.BlockPosition.ID == EditPositionID)
            {
                return true;
            }
            else
                return false;
        }

        private void OnNewButtonExectute(object obj)
        {
            BlockAssembly.AddNewPosition(new Position());
            IsNotEditing = false;
        }

        public bool NewButtonCanExecute(object obj)
        {
            return IsNotEditing;
        }
    }
}
