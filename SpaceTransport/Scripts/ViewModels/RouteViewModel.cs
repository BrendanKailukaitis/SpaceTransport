using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SpaceTransport.Scripts.Managers;
using SpaceTransport.Views;

namespace SpaceTransport.Scripts.ViewModels
{
    public class RouteViewModel : BaseViewModel
    {
        public RouteViewModel()
        {
            Routes = GameManager.Instance.Company.Routes;
        }

        public List<Route> Routes { get; }

        private Route _selectedRoute;

        public Route SelectedRoute
        {
            get => _selectedRoute;
            set => SetProperty(ref _selectedRoute, value);
        }

        private RelayCommand _openRouteCreationView;

        public ICommand OpenRouteCreationView =>
            _openRouteCreationView ?? (_openRouteCreationView = 
            new RelayCommand(param => OpenRouteCreation()));

        private void OpenRouteCreation()
        {
            RouteCreationView rcv = new RouteCreationView();
            rcv.Show();
        }
    }
}
