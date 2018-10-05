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
using SpaceTransport.Scripts.Managers;
using SpaceTransport.Views;
using EventManager = SpaceTransport.Scripts.EventSystem.EventManager;

namespace SpaceTransport.Scripts.ViewModels
{
    public class RouteCreationViewModel : BaseViewModel
    {
        #region Constructor

        public RouteCreationViewModel()
        {
            OriginOrbitals = GameManager.Instance.Orbitals;
            Vehicles = GameManager.Instance.Company.Vehicles;
        }

        #endregion

        #region Fields

        private Orbital _selectedOrigin;
        private Orbital _selectedDestination;
        private Vehicle _selectedVehicle;
        private CargoType _cargoType;
        private int _totalValue;
        private RelayCommand _createRouteCommand;
        private RelayCommand _filterOrbitalsCommand;

        #endregion

        #region Properties

        // Contains all orbitals for selecting origin.
        public List<Orbital> OriginOrbitals { get; }

        // Filtered list of all orbitals for destination minus the origin.
        public List<Orbital> DestinationOrbitals { get; private set; }

        public List<Vehicle> Vehicles { get; }

        public Orbital SelectedOrigin {
            get => _selectedOrigin;
            set => SetProperty(ref _selectedOrigin, value);
        }

        public Orbital SelectedDestination {
            get => _selectedDestination;
            set => SetProperty(ref _selectedDestination, value);
        }

        public Vehicle SelectedVehicle {
            get => _selectedVehicle;
            set => SetProperty(ref _selectedVehicle, value);
        }

        public int TotalValue {
            get => _totalValue;
            set => SetProperty(ref _totalValue, value);
        }

        public CargoType CargoType {
            get => _cargoType;
            set => SetProperty(ref _cargoType, value);
        }

        public ICommand BtnClick {
            get {
                return _createRouteCommand ?? (
                  _createRouteCommand = new RelayCommand(
                      param => CreateRoute()));
            }
        }

        public ICommand FilterOrbitalsCommand {
            get {
                return _filterOrbitalsCommand ?? (
                    _filterOrbitalsCommand = new RelayCommand(
                        param => SetDestinationOrbitals()));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the Destination orbitals to be a filtered list where the
        /// selected origin orbital is filtered out of the possible orbitals.
        /// </summary>
        private void SetDestinationOrbitals()
        {
            DestinationOrbitals = OriginOrbitals.Where(
                o => o.Id != SelectedDestination.Id).ToList();
        }

        private void SetCargo()
        {
            
        }

        /// <summary>
        /// Creates a new route with the selected items and closes
        /// the route creation window.
        /// </summary>
        private void CreateRoute()
        {
            Cargo cargo = new Cargo(CargoType, TotalValue);
            Route route = new Route(SelectedOrigin, SelectedDestination,
                SelectedVehicle, cargo);

            RouteCreatedEvent rce = new RouteCreatedEvent { Route = route };
            EventManager.Invoke(rce);

            WindowManager.CloseWindow(ViewGuid);
        }

        #endregion
    }
}