using Okuma_ToolOffset_App.Models.AppModels;
using Okuma_ToolOffset_App.Models.MachineModels;
using Okuma_ToolOffset_App.Views.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okuma_ToolOffset_App.Views.Main
{
    public class MainViewModel
    {
        public List<Station> stations { get; set; }
        public Station selectedItem { get; set; }

        public MainViewModel()
        {
            stations = new List<Station>
            {
                new Station(1)
                {
                    ToolBlock = new MountedToolBlock()
                    {
                        ID = 1,
                        Name = "Block 1",
                        Comment = "Sandvic",
                        BlockType = Models.AppModels.Enums.BlockTypeEnum.Axial,
                        Positions = new List<MountedBlockPosition>
                        {
                            new MountedBlockPosition()
                            {
                                ID = 1,
                                Name = "Main",
                                Side = Models.AppModels.Enums.BlockSideEnum.Main,
                                Type = Models.AppModels.Enums.BlockPositionTypeEnum.RightHand,
                                XOffset = 1.5,
                                YOffset = 0,
                                ZOffset = .25,
                                MountedTool = new Tool
                                {
                                    ToolNo = 6,
                                    Name = "55Deg Dia",
                                    Comment = "mnmg insert",
                                    Length = 1.542,
                                    Width = .54,
                                    RadiusCompPattern = 3,
                                    XRadiusOffset = .015,
                                    ZRadiusOffset = .015,
                                    ToolType = Models.AppModels.Enums.ToolTypeEnum.RightHandTurn
                                }
                            },
                            new MountedBlockPosition()
                            {
                                ID = 2,
                                Name = "Sub",
                                Side = Models.AppModels.Enums.BlockSideEnum.Opposite,
                                Type = Models.AppModels.Enums.BlockPositionTypeEnum.RightHand,
                                XOffset = 1.5,
                                YOffset = 0,
                                ZOffset = 2.654,
                                MountedTool = new Tool
                                {
                                    ToolNo = 54,
                                    Name = "80Deg Rougher",
                                    Comment = "wnmxinsert",
                                    Length = 1.542,
                                    Width = .54,
                                    RadiusCompPattern = 3,
                                    XRadiusOffset = .031,
                                    ZRadiusOffset = .031,
                                    ToolType = Models.AppModels.Enums.ToolTypeEnum.RightHandTurn
                                }
                            }
                        },
                        MountPosition = Models.AppModels.Enums.MountPositionEnum.Foward
                    }

                },
                new Station(2)
                {
                    ToolBlock = new MountedToolBlock()
                    {
                        ID = 2,
                        Name = "Block 2",
                        Comment = "Velocity",
                        BlockType = Models.AppModels.Enums.BlockTypeEnum.Axial,
                        Positions = new List<MountedBlockPosition>
                        {
                            new MountedBlockPosition()
                            {
                                ID = 1,
                                Name = "Main",
                                Side = Models.AppModels.Enums.BlockSideEnum.Main,
                                Type = Models.AppModels.Enums.BlockPositionTypeEnum.RightHand,
                                XOffset = 1.75,
                                YOffset = 0,
                                ZOffset = .5,
                                MountedTool = null
                            },
                            new MountedBlockPosition()
                            {
                                ID = 2,
                                Name = "Another",
                                Side = Models.AppModels.Enums.BlockSideEnum.Main,
                                Type = Models.AppModels.Enums.BlockPositionTypeEnum.RightHand,
                                XOffset = 1.75,
                                YOffset = 0,
                                ZOffset = .5,
                                MountedTool = new Tool
                                {
                                    ToolNo = 85,
                                    Name = "Groover",
                                    Comment = "GIPI insert",
                                    Length = 1.056,
                                    Width = .005,
                                    RadiusCompPattern = 3,
                                    XRadiusOffset = .008,
                                    ZRadiusOffset = .008,
                                    ToolType = Models.AppModels.Enums.ToolTypeEnum.RightHandTurn
                                }
                            }
                        },
                        MountPosition = Models.AppModels.Enums.MountPositionEnum.Foward
                    }

                },
                new Station(3)
                {
                    ToolBlock = new MountedToolBlock
                    {

                        ID = 2,
                        Name = "AnotherBlock",
                        Comment = "Sandvic",
                        BlockType = Models.AppModels.Enums.BlockTypeEnum.Radial,
                        Positions = new List<MountedBlockPosition>
                        {
                            new MountedBlockPosition()
                            {
                                ID = 1,
                                Name = "Main",
                                Side = Models.AppModels.Enums.BlockSideEnum.Main,
                                Type = Models.AppModels.Enums.BlockPositionTypeEnum.LeftHand,
                                XOffset = 1.75,
                                YOffset = 0,
                                ZOffset = .5,
                                MountedTool = new Tool
                                {
                                    ToolNo = 85,
                                    Name = "Groover",
                                    Comment = "GIPI insert",
                                    Length = 1.056,
                                    Width = .005,
                                    RadiusCompPattern = 3,
                                    XRadiusOffset = .008,
                                    ZRadiusOffset = .008,
                                    ToolType = Models.AppModels.Enums.ToolTypeEnum.RightHandTurn
                                }
                            }
                        },
                        MountPosition = Models.AppModels.Enums.MountPositionEnum.Foward
                    }
                },
                new Station(4)
                {
                    ToolBlock = null,
                }
            };
        }

        public void DoSomething(object par)
        {

        }
    }
}
