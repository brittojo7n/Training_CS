using System;

namespace Training_CS
{

    public class Dispatcher
    {
        public void Vehicle(string vehicleType)
        {
            Console.WriteLine($"Dispatching a {vehicleType}.");
        }

        public void Vehicle(string vehicleType, string driver)
        {
            Console.WriteLine($"Dispatching a {vehicleType} with driver {driver}.");
        }

        public void Vehicle(string vehicleType, int routeNumber)
        {
            Console.WriteLine($"Dispatching a {vehicleType} on route #{routeNumber}.");
        }
    }
}
