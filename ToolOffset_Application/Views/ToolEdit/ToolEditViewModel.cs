using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using ToolOffset_Application.Core;
using ToolOffset_Application.Events.Navigation;
using ToolOffset_Application.Views.MainRegion;
using ToolOffset_Application.Wrappers.ToolWrappers;
using ToolOffset_MachineModels.Models;
using ToolOffset_Models.Models;
using ToolOffset_Models.Models.Tools;
using ToolOffset_Services.Interfaces;
using Unity;

namespace ToolOffset_Application.Views.ToolEdit
{
    public class ToolEditViewModel : BaseDetailViewModel, IToolEditViewModel
    {
        public ToolEditViewModel() { }

        public ToolEditViewModel(IToolEditView view, IUnityContainer container,
            INavigationEventAggregator navigationEventAggregator, IUnitOfWork unitOfWork, ILathe lathe, int id = 0)
            : base(view, container)
        {
            ID = id;
            _navigationEventAggregator = navigationEventAggregator;
            _unitOfWork = unitOfWork;
            _lathe = lathe;
            CancelButtonCommand = new DelegateCommand<object>(OnCancelExecute);
            OffsetAddButtonCommand = new DelegateCommand<object>(OnOffsetAddExecute, OffsetAddCanExecute);
            OffsetDeleteButtonCommand = new DelegateCommand<object>(OnOffsetDeleteExecute, OffsetDeleteCanExecute);
            SaveButtonCommand = new DelegateCommand<object>(OnSaveButtonExecute, SaveButtonCanExecute);
            Tool = _unitOfWork.Tools.Get(ID);
        }

        private readonly ILathe _lathe;
        private readonly INavigationEventAggregator _navigationEventAggregator;
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


        private ToolOffset _selectedToolOffset;
        public ToolOffset SelectedToolOffset
        {
            get { return _selectedToolOffset; }
            set
            {
                if (value != _selectedToolOffset)
                {
                    _selectedToolOffset = value;
                    OnPropertyChanged("SlectedToolOffset");
                }
            }
        }

        public DelegateCommand<object> CancelButtonCommand { get; }
        public DelegateCommand<object> OffsetAddButtonCommand { get; }
        public DelegateCommand<object> OffsetDeleteButtonCommand { get; }
        public DelegateCommand<object> SaveButtonCommand { get; }


        private void OnCancelExecute(object obj)
        {
            NavigateToMainRegion();
        }

        private void OnOffsetAddExecute(object obj)
        {
            Tool.ToolOffsets.Add(new ToolOffset());
        }

        private bool OffsetAddCanExecute(object obj)
        {
            return true;
        }

        private void OnOffsetDeleteExecute(object obj)
        {
            Tool.ToolOffsets.Remove(_selectedToolOffset);
        }

        private bool OffsetDeleteCanExecute(object obj)
        {
            if (SelectedToolOffset != null)
                return !_lathe.ToolOffsetInUse(_selectedToolOffset);

            return false;
        }

        private void OnSaveButtonExecute(object obj)
        {
            //TODO: update offsets on lathe
            //TODO: added and removed offsets


            if (ID == 0)
                _unitOfWork.Tools.Add(Tool);
            else
                //TODO: Save changes

                NavigateToMainRegion();
        }

        private bool SaveButtonCanExecute(object obj)
        {
            if (Tool == null)
                return false;
            return true;
        }

        private void NavigateToMainRegion()
        {
            _navigationEventAggregator.PostMessage(new WindowRegionNavigationRequest(
                Container.Resolve<IMainRegionViewModel>()));
        }
    }
}
