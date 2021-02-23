using System;
using System.Threading;
using Machines;

class Program
{
    static void Main(string[] args)
    {
        CoffeeMachine coffeMachine = new CoffeeMachine(1);
        Console.WriteLine(coffeMachine.TurnOn());
        Console.WriteLine(coffeMachine.InsertFilter());
        Console.WriteLine(coffeMachine.AddCoffeeBeans(10));
        Console.WriteLine(coffeMachine.FillWithWater(100));
        Console.WriteLine(coffeMachine.BrewCoffee());

        Thread.Sleep(2000);

        while (coffeMachine.IsBrewing)
        {
            Console.Clear();
            Console.WriteLine(coffeMachine.BrewCoffee());
            Console.WriteLine(coffeMachine.ToString());
            Thread.Sleep(100);
        }
    }
}