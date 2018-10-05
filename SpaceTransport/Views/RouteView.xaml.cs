using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SpaceTransport.Scripts.ViewModels;

namespace SpaceTransport.Views
{
    /// <summary>
    /// Interaction logic for RouteView.xaml
    /// </summary>
    public partial class RouteView : Window
    {
        public RouteView()
        {
            InitializeComponent();
            //DataContext = new RouteViewModel();
        }
    }
}
