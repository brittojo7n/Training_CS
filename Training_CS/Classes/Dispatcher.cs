using System;

namespace Training_CS
{

    public class Dispatcher
    {
        public string VehicleType { get; set; }
        public int Route { get; set; }
        public string Driver { get; set; }

        public Dispatcher(string vehicleType, int route, string driver)
        {
            this.VehicleType = vehicleType;
            this.Route = route;
            this.Driver = driver;
        }
        public void Vehicle()
        {
            Console.WriteLine($"Dispatching a {VehicleType} with driver {Driver} on Route {Route}.");
        }

        public void Vehicle(string driver)
        {
            this.Driver = driver;
            Console.WriteLine($"Updated:\t Dispatching a {VehicleType} with driver {Driver}.");
        }

        public void Vehicle(int route)
        {
            this.Route = route;
            Console.WriteLine($"Updated:\t Dispatching a {VehicleType} on Route {Route}.");
        }
    }
}
