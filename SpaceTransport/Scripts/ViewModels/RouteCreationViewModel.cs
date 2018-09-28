using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Navigation;
using SpaceTransport.Scripts.EventSystem;
using SpaceTransport.Scripts.Interfaces;
using SpaceTransport.Views;
using EventManager = SpaceTransport.Scripts.EventSystem.EventManager;

namespace SpaceTransport.Scripts.ViewModels
{
    public class RouteCreationViewModel : BaseViewModel
    {
        private Orbital _selectedOrigin;
        private Orbital _selectedDestination;
        private Vehicle _selectedVehicle;
        private CargoType _cargoType;

        private int _totalValue;

        private RelayCommand _createRouteCommand;

        public Action CloseAction { get; set; }

        public RouteCreationViewModel()
        {
            Orbitals = GameManager.Instance.Orbitals;
            Vehicles = GameManager.Instance.Company.Vehicles;
        } 

        public List<Orbital> Orbitals { get; }

        public List<Vehicle> Vehicles { get; }

        public Orbital SelectedOrigin 
        {
            get => _selectedOrigin;
            set => SetProperty(ref _selectedOrigin, value);
        }
         
        public Orbital SelectedDestination 
        {
            get => _selectedDestination;
            set => SetProperty(ref _selectedDestination, value);
        }

        public Vehicle SelectedVehicle {
            get => _selectedVehicle;
            set => SetProperty(ref _selectedVehicle, value);
        }

        public int TotalValue 
        {
            get => _totalValue;
            set => SetProperty(ref _totalValue, value);
        }

        public CargoType CargoType
        {
            get => _cargoType;
            set => SetProperty(ref _cargoType, value);
        }

        public ICommand BtnClick => _createRouteCommand ?? (
            _createRouteCommand = new RelayCommand(
                param => CreateRoute() ));

        public void CreateRoute()
        {
            Cargo cargo = new Cargo(CargoType, TotalValue);
            Route route = new Route(SelectedOrigin, SelectedDestination, 
                SelectedVehicle, cargo);

            RouteCreatedEvent rce = new RouteCreatedEvent { Route = route };
            EventManager.Invoke(rce);

            CloseAction();

        }

    }
}