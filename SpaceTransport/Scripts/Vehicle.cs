using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTransport.Scripts
{
    public class Vehicle
    {
        public CargoType CargoType { get; set; }
        public Cargo CurrentCargo { get; set; }
        public double Speed { get; set; }
        public string VehicleClass { get; set; }

        public Vehicle(CargoType cargoType,  string vClass, double speed, Cargo cargo = null)
        {
            CargoType = cargoType;
            CurrentCargo = cargo;
            Speed = speed;
            VehicleClass = vClass;
            
        }
    }
}
