using SpaceTransport.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpaceTransport.Scripts.ViewModels
{
    public class HomeScreenViewModel
    {
        private RelayCommand _routeViewCommand;

        public ICommand RouteViewCommand =>
            _routeViewCommand ?? (_routeViewCommand = new RelayCommand(
                param => OpenRouteView()));

        private static void OpenRouteView()
        {
            RouteView rw = new RouteView();
            rw.Show();
        }
    }
}
