using System.Collections.Generic;
using ToolOffset_Application.Core;
using ToolOffset_Application.Events;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Machine;
using ToolOffset_Models.Models.Tools;
using ToolOffset_Services.Interfaces;
using Unity;

namespace ToolOffset_Application.Views.TurretMagazine
{
    public class TurretMagazineViewModel : BaseViewModel, ITurretMagazineViewModel
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IUnitOfWork _unitOfWork;
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
                    _eventAggregator.PostMessage(new StationSelectionChanged(SelectedStation));
                }
            }
        }

        public TurretMagazineViewModel()
        {
            SetTempData();
        }

        public TurretMagazineViewModel(ITurretMagazineView view, IUnityContainer container, IEventAggregator eventAggregator, IUnitOfWork unitOfWork)
            : base(view, container)
        {
            SetTempData();
            _eventAggregator = eventAggregator;
            _unitOfWork = unitOfWork;
        }

        private void SetTempData()
        {
            Turret = new Turret(12, 32);
            foreach (var station in Turret.Stations)
            {
                station.ToolBlock = new MountedBlockAssembly
                {
                    Block = new Block(),
                    Positions = new List<MountedPosition>()
                };
            }
            Turret.Stations[0].ToolBlock = new MountedBlockAssembly
            {
                Block = new Block
                {
                    Name = "A Block",
                    BlockType = BlockType.RadialMill,
                    Comment = "Some Block Comment",
                    ID = 1
                },
                BlockOrientation = BlockOrientation.Foward,
                Positions = new List<MountedPosition>
                {
                    new MountedPosition
                    {
                        BlockPosition = new BlockPosition
                        {
                            ID = 1,
                            Name = "First",
                            XOffset = 1.223,
                            YOffset = 0.000,
                            ZOffset = 1.452,
                            Side = BlockPositionSide.Main,
                            Type = BlockPositionHand.NoHand
                        }
                    },
                    new MountedPosition
                    {
                        BlockPosition = new BlockPosition
                        {
                            ID = 2,
                            Name = "Second",
                            XOffset = 1.223,
                            YOffset = 0.000,
                            ZOffset = 1.452,
                            Side = BlockPositionSide.Main,
                            Type = BlockPositionHand.RightHand
                        }
                    }
                }
            };
            Turret.Stations[1].ToolBlock = new MountedBlockAssembly
            {
                Block = new Block
                {
                    Name = "B Block",
                    BlockType = BlockType.AxialTurn,
                    Comment = "Some Other Block Comment",
                    ID = 1
                },
                BlockOrientation = BlockOrientation.Foward,
                Positions = new List<MountedPosition>
                {
                    new MountedPosition
                    {
                        BlockPosition = new BlockPosition
                        {
                            ID = 1,
                            Name = "First",
                            XOffset = 1.223,
                            YOffset = 0.000,
                            ZOffset = 1.452,
                            Side = BlockPositionSide.Main,
                            Type = BlockPositionHand.NoHand
                        }
                    },
                    new MountedPosition
                    {
                        BlockPosition = new BlockPosition
                        {
                            ID = 2,
                            Name = "Second",
                            XOffset = 1.223,
                            YOffset = 0.000,
                            ZOffset = 1.452,
                            Side = BlockPositionSide.Opposite,
                            Type = BlockPositionHand.RightHand
                        }
                    }
                }
            };

            Tool tool1 = new Tool(1, "OD Rougher", "Sandvic hm14h", ToolType.RightHandRadial, 1, 2);
            Tool tool2 = new Tool(2, "OD Finisher", "Sandvic 5414h", ToolType.RightHandRadial, 1, 3);

            tool1.AddNewToolOffset(new ToolOffset(1, "Main Offset", 1.2256, .0654, .015, .015, RadiusCompPattern.FrontLeft));
            tool2.AddNewToolOffset(new ToolOffset(1, "Main Offset", 1.2256, .0654, .015, .015, RadiusCompPattern.FrontLeft));


            Turret.Stations[0].ToolBlock.Positions[0].Tool = tool1;
            Turret.Stations[0].ToolBlock.Positions[1].Tool = tool2;
            Turret.Stations[0].ToolBlock.Positions[0].OffsetNo1 = 3;
            Turret.Stations[0].ToolBlock.Positions[1].OffsetNo1 = 4;
            Turret.Stations[0].ToolBlock.Positions[0].ToolOffset1 = tool1.ToolOffsets[0];
            Turret.Stations[0].ToolBlock.Positions[1].ToolOffset1 = tool2.ToolOffsets[0];
            Turret.Offsets[2].SetOffset(1.343, 0, .23, .015, .015, 3, .0001, .0012);
        }
    }
}

