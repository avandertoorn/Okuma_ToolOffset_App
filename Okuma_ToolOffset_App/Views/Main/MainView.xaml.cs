using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Okuma_ToolOffset_App.Views.Main
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        private MainViewModel _model;
        public MainView()
        {
            InitializeComponent();
            _model = new MainViewModel();
            DataContext = _model;
        }

        private void ListView_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
