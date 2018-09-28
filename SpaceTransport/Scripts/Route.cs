using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceTransport.Scripts.EventSystem;

namespace SpaceTransport.Scripts
{
    public class Route
    {
        public Orbital Origin { get; set; }
        public Orbital Destination { get; set; }

        public double Distance { get; private set; }
        public int TurnsToCompletion { get; private set; }
        public int RouteValue { get; private set; }

        public Vehicle Vehicle { get; set; }
        public Cargo Cargo { get; set; }

        public Route(Orbital origin, Orbital destination, Vehicle v, Cargo c)
        {
            EventManager.RegisterListener<NextTurnEvent>(OnNextTurn);

            Origin = origin;
            Destination = destination;
            Vehicle = v;
            Cargo = c;
            RouteValue = c.Value;

            Distance = Math.Abs(origin.Distance - destination.Distance);
            TurnsToCompletion = (int)Math.Ceiling(Distance / Vehicle.Speed);
        }

        private void OnNextTurn(NextTurnEvent nte)
        {
            TurnsToCompletion--;
            if (TurnsToCompletion <= 0)
            {
                EventManager.UnregisterListener<NextTurnEvent>(OnNextTurn);

                RouteCompletedEvent rce = new RouteCompletedEvent()
                {
                    Route = this
                };
                EventManager.Invoke(rce);
            }
        }

        public override string ToString()
        {
            return $"{Origin.Name} --> {Destination.Name}";
        }
    }
}
