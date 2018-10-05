using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTransport.Scripts
{
    public class Cargo
    {
        public CargoType CargoType { get; set; }
        public int Value { get; set; }

        public Cargo(CargoType ct, int value)
        {
            CargoType = ct;
            Value = value;
        }
    }
}
