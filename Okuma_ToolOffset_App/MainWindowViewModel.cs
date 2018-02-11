using Okuma_ToolOffset_App.Views.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Okuma_ToolOffset_App
{
    public class MainWindowViewModel
    {
        public MainView View { get; set; }
        public MainWindowViewModel()
        {
            View = new MainView();
        }
    }
}
