using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTransport.Scripts
{
    public class Orbital
    {
        public string Name { get; set; }
        public double Distance { get; set; }
        public bool IsColonized { get; set; }
        public Guid Id { get; set; }

        public Orbital(string name, double distance, bool colonized)
        {
            Name = name;
            Distance = distance;
            IsColonized = colonized;
            Id = Guid.NewGuid();
        }
    }
}
