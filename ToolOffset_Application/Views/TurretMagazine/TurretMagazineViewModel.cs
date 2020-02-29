using ToolOffset_Application.Core;
using ToolOffset_Application.Events.Selection;
using ToolOffset_MachineModels.Models;
using ToolOffset_Models.Models.Lathe;
using ToolOffset_Services.Interfaces;
using Unity;

namespace ToolOffset_Application.Views.TurretMagazine
{
    public class TurretMagazineViewModel : BaseViewModel, ITurretMagazineViewModel
    {
        public TurretMagazineViewModel(ITurretMagazineView view, IUnityContainer container,
            ISelectionEventAggregator selectionEventAggregator, IUnitOfWork unitOfWork, ILathe lathe)
            : base(view, container)
        {
            _lathe = lathe;
            Turret = _lathe.ATurret;
            _selectionEventAggregator = selectionEventAggregator;
            _unitOfWork = unitOfWork;
        }

        private readonly ISelectionEventAggregator _selectionEventAggregator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILathe _lathe;

        private Station _selectedStation;

        public Turret Turret { get; set; }

        public Station SelectedStation
        {
            get { return _selectedStation; }
            set
            {
                if (value != _selectedStation)
                {
                    _selectedStation = value;
                    OnPropertyChanged("SelectedStation");
                    _selectionEventAggregator.PostMessage(new StationSelectionChanged(SelectedStation, Turret));
                }
            }
        }

        public TurretMagazineViewModel()
        {

        }
    }
}

