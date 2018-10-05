using System.Collections.Generic;
using SpaceTransport.Scripts.EventSystem;

namespace SpaceTransport.Scripts.Managers
{
    public sealed class GameManager
    {
        static GameManager()
        {

        }

        private GameManager()
        {

        }

        public static GameManager Instance { get; } = new GameManager();

        public List<Orbital> Orbitals;

        public Company Company { get; private set; }

        public void Generate()
        {
            Company = new Company("Bob's Company");
            Orbitals = new List<Orbital>
            {
                new Orbital("Mercury", 5800, false),
                new Orbital("Venus", 10800, false),
                new Orbital("Earth", 15000, true),
                new Orbital("Mars", 22800, false)
            };

            Company.Vehicles.Add(new Vehicle(CargoType.Military, "LambHolt", 1000));

            CreateRoute();
        }

        public void CreateRoute()
        {
            RouteCreatedEvent rce = new RouteCreatedEvent()
            {
                Route = new Route(Orbitals[0], Orbitals[1], Company.Vehicles[0], 
                    new Cargo(CargoType.Military, 100))
            };
            EventManager.Invoke(rce);
        }

        public void NextTurn()
        {
            NextTurnEvent nte = new NextTurnEvent();
            EventManager.Invoke(nte);
        }
    }
}
