using SpaceTransport.Scripts.EventSystem;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTransport.Scripts
{
    public class Company
    {
        public string Name { get; set; }
        public double Value { get; set; }

        public List<Vehicle> Vehicles;
        public List<Route> Routes;

        public Company(string name)
        {
            EventManager.RegisterListener<RouteCreatedEvent>(OnRouteCreated);
            EventManager.RegisterListener<RouteCompletedEvent>(OnRouteCompleted);

            this.Name = name;
            this.Value = 0;
            this.Vehicles = new List<Vehicle>();
            this.Routes = new List<Route>();
        }

        void OnRouteCreated(RouteCreatedEvent rce)
        {
            Routes.Add(rce.Route);
            Debug.Print($"{rce.Route} route Created!");
        }

        void OnRouteCompleted(RouteCompletedEvent rce)
        {
            Routes.Remove(rce.Route);

            Value += rce.Route.RouteValue;
            Debug.Print(
                $"{rce.Route} route complete! Company Value: {Value}");
        }
    }
}
