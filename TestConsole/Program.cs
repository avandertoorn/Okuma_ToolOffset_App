using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolOffset_Application.Views.BlockEdit;
using ToolOffset_LatheUtilities.LatheModels;
using ToolOffset_Models.Enumerations;
using ToolOffset_Models.Models.Machine;
using ToolOffset_Models.Models.Tools;
using ToolOffset_Services.Repositories;
using ToolOffset_Services.UnitOfWork;

namespace TestConsole
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ToolRepository toolRepository = new ToolRepository();
            //Tool tool = new Tool(1, 
            //    "A Tool", 
            //    "This is a tool comment", 
            //    ToolType.RightHandRadial, 
            //    new List<ToolOffset>()
            //    {
            //        new ToolOffset(
            //            1,
            //            "First",
            //            1.233,
            //            .345,
            //            .031,
            //            .031,
            //            RadiusCompPattern.FrontLeft),
            //        new ToolOffset(
            //            2,
            //            "second",
            //            1.233,
            //            .340,
            //            .031,
            //            .031,
            //            RadiusCompPattern.FrontRight)
            //    }, 1, 3);

            //toolRepository.Add(tool);

            var tools = toolRepository.GetAll().ToList();

            tools[1].Name = "New Name";

            toolRepository.Update(tools[1]);

            Console.ReadLine();
        }
    }
}

