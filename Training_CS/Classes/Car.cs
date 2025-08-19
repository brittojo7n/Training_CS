using System;

public class Car
{
    public string Make { get; private set; }
    public string Model { get; private set; }
    public int Year { get; private set; }
    public int CurrentSpeed { get; private set; }

    public Car(string make, string model, int year)
    {
        if (string.IsNullOrWhiteSpace(make) || string.IsNullOrWhiteSpace(model))
        {
            throw new ArgumentException("Make and model cannot be empty.");
        }
        if (year < 1886 || year > DateTime.Now.Year + 1)
        {
            throw new ArgumentException("Invalid year provided.");
        }

        this.Make = make;
        this.Model = model;
        this.Year = year;
        this.CurrentSpeed = 0;
    }

    public void Accelerate(int amount)
    {
        if (amount > 0)
        {
            this.CurrentSpeed += amount;
            Console.WriteLine($"Accelerating. Current speed: {this.CurrentSpeed} km/h.");
        }
    }

    public void Brake(int amount)
    {
        if (amount > 0)
        {
            this.CurrentSpeed -= amount;
            if (this.CurrentSpeed < 0)
            {
                this.CurrentSpeed = 0;
            }
            Console.WriteLine($"Braking. Current speed: {this.CurrentSpeed} km/h.");
        }
    }

    public void DisplayStatus()
    {
        Console.WriteLine($"\nCar: {this.Year} {this.Make} {this.Model}");
        Console.WriteLine($"Speed: {this.CurrentSpeed} km/h");
    }
}