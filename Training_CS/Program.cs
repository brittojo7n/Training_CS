using System;

namespace Training_CS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Factorial ft = new Factorial();
            Console.WriteLine($"Factorial: {ft.Fact(5)}");
        }
    }
}