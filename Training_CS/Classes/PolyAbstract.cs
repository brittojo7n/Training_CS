using System;

namespace Training_CS.Classes
{

    public interface IChargeable
    {
        int BatteryLevel { get; }
        void Charge();
    }

    public abstract class Device : IChargeable
    {
        public string ModelName { get; protected set; }
        public int BatteryLevel { get; protected set; }

        public virtual void TurnOn()
        {
            if (BatteryLevel > 0)
            {
                Console.WriteLine($"\n{ModelName} screen lights up.");
            }
            else
            {
                Console.WriteLine($"\n{ModelName} needs to be charged.");
            }
        }

        public void Charge()
        {
            this.BatteryLevel = 100;
            Console.WriteLine($"\n{ModelName} has been fully charged.");
        }

        public abstract string GetStatus();
    }

    public class Smartphone : Device, IChargeable
    {

        public Smartphone(string model, int initialBattery)
        {
            this.ModelName = model;
            this.BatteryLevel = initialBattery;
        }

        public override string GetStatus()
        {
            return $"Smartphone ({ModelName}) - Battery: {BatteryLevel}%";
        }
    }

    public class Laptop : Device
    {
        public Laptop(string model, int initialBattery)
        {
            this.BatteryLevel = initialBattery;
            this.ModelName = model;
        }

        public override string GetStatus()
        {
            return $"Laptop ({ModelName}) - Battery: {BatteryLevel}%";
        }
    }
}
