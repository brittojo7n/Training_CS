using System;

namespace Training_CS.Classes
{

    public class ESwap
    {
        static void Swap(ref int x, ref int y)
        {
            Console.WriteLine($"Before: x = {x}, y = {y}");

            x = x + y;
            y = x - y;
            x = x - y;

            Console.WriteLine($"After: x = {x}, y = {y}");
        }

        public void Start()
        {
            int a = 10;
            int b = 99;

            Console.WriteLine($"Original values (Before): a = {a}, b = {b}");

            Swap(ref a, ref b);

            Console.WriteLine($"Original values (After):  a = {a}, b = {b}");
        }
    }
}
