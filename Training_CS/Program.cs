using System;

namespace Training_CS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dispatcher dispatch = new Dispatcher();
            dispatch.Vehicle("Truck");
            dispatch.Vehicle("Truck", "Sully Morgan");
            dispatch.Vehicle("Truck", 42);
        }
    }
}