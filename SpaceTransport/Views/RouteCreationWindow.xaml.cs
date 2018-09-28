using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SpaceTransport.Scripts;
using SpaceTransport.Scripts.Interfaces;
using SpaceTransport.Scripts.ViewModels;

namespace SpaceTransport.Views
{
    /// <summary>
    /// Interaction logic for RouteCreation.xaml
    /// </summary>
    public partial class RouteCreationWindow : Window, ICloseable
    {
        public RouteCreationWindow()
        {
            InitializeComponent();
            //DataContext = new RouteCreationViewModel();
            RouteCreationViewModel viewModel = new RouteCreationViewModel();
            DataContext = viewModel;
            if (viewModel.CloseAction == null)
            {
                viewModel.CloseAction = new Action(this.Close);
            }

        }

        private void CombxOrigin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Orbital orbital = CombxOrigin.SelectedItem as Orbital;
            List<Orbital> orbitals = GameManager.Instance.Orbitals.Where(
                o => o.Name != orbital?.Name).ToList();
            ComboBoxDestination.ItemsSource = orbitals;
            ComboBoxDestination.DisplayMemberPath = "Name";
        }

        private void CombxVehicle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Vehicle vehicle = CombxVehicle.SelectedItem as Vehicle;
            var cargoType = Enum.GetValues(typeof(CargoType)).Cast<CargoType>().Where(
                v => v.ToString() == vehicle.CargoType.ToString());

            ComboxCargo.ItemsSource = cargoType;
        }

        private void ComboxCargo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CargoType cargoType = (CargoType)ComboxCargo.SelectedValue;
            int value;

            switch (cargoType)
            {
                case CargoType.Civilian:
                    value = 50;
                    break;
                case CargoType.Military:
                    value = 100;
                    break;
                case CargoType.Colony:
                    value = 0;
                    break;
                default:
                    value = 0;
                    break;      
            }

            LblValue.Content = value;
        }
    }
}
