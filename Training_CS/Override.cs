using System;

namespace Training_CS
{
    public class Power
    {
        public float power = 50;
        public virtual void Calc()
        {
            Console.WriteLine($"Power: {power}");
        }
    }

    public class Energy : Power
    {
        public override void Calc()
        {
            float energy = power * 60; 
            Console.WriteLine($"Energy: {energy}");
        }
    }

    public class Override
    {
        public void Start()
        {
            Power e = new Energy();
            e.Calc();
        }
    }
}
