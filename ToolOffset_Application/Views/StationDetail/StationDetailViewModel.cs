using System.Collections.Generic;
using ToolOffset_Application.Core;
using ToolOffset_Application.Events;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Machine;
using ToolOffset_Models.Models.Tools;
using Unity;

namespace ToolOffset_Application.Views.StationDetail
{
    public class StationDetailViewModel : BaseViewModel, IStationDetailViewModel
    {
        private Station _station;

        public Station Station
        {
            get { return _station; }
            set
            {
                if (value != _station)
                {
                    _station = value;
                    OnPropertyChanged("Station");
                }
            }

        }
        private IEventAggregator _eventAggregator { get; set; }

        public StationDetailViewModel()
        {
            Tool tool = new Tool(
                342, "OD Rougher", "Sandvic Trigon", ToolType.RightHandRadial, new List<ToolOffset>
            {
                new ToolOffset(1, "Main", 1.25, .0215, .031, .031, RadiusCompPattern.Front)
            }, 1, 4);

            BlockAssembly block = new BlockAssembly(
                new Block(1, "block", "Some Comment", BlockType.AxialMill),
                new List<Position>
                {
                    new Position(
                        new BlockPosition(
                            1, "Main", BlockPositionSide.Main, BlockPositionHand.RightHand, .125, 0.00, 2.543)),
                    new Position(
                        new BlockPosition(
                            2, "Second", BlockPositionSide.Main, BlockPositionHand.RightHand, .25, 0.00, 1.043)),
                }
                    
                );

            Station = new Station(1);
            Station.MountToolBlock(block, BlockOrientation.Foward);
            Station.ToolBlock.Positions[0].Tool = tool;
        }

        public StationDetailViewModel(IStationDetailView view, IUnityContainer container, IEventAggregator eventAggregator)
            : base(view, container)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.RegisterHandler<StationSelectionChanged>(SelectionChangedHandler);
        }

        private void SelectionChangedHandler(StationSelectionChanged message)
        {
            Station = message.Selection;
        }
    }
}
