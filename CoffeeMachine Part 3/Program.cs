using Machines;
using System;

class Program
{
    static void Main(string[] args)
    {
        CoffeeMachine coffeMachine = new CoffeeMachine();
        Console.WriteLine(coffeMachine.TurnOn());
        Console.WriteLine(coffeMachine.InsertFilter(new Filter("Coffee", 10)));
        Console.WriteLine(coffeMachine.FillWithWater(100));
        Console.WriteLine();

        Can can = new Can();
        Console.WriteLine(coffeMachine.Brew(ref can));
        Console.WriteLine(can.Brewage.ToString());
        Console.WriteLine(coffeMachine.FilterHolder.Filter.ToString());
        Console.WriteLine();

        Console.WriteLine(coffeMachine.RemoveFilter());
        Console.WriteLine(coffeMachine.InsertFilter(new Filter("Tea", 25)));
        Console.WriteLine(coffeMachine.FillWithWater(200));
        Console.WriteLine();

        Console.WriteLine(can.Empty());
        Console.WriteLine(coffeMachine.Brew(ref can));
        Console.WriteLine(can.Brewage.ToString());
        Console.WriteLine(coffeMachine.FilterHolder.Filter.ToString());
        Console.WriteLine();


        Console.WriteLine(coffeMachine.RemoveFilter());
        Console.WriteLine(coffeMachine.InsertFilter(new Filter("Ekspresso", 50)));
        Console.WriteLine(coffeMachine.FillWithWater(50));
        Console.WriteLine();

        Cup cup = new Cup();
        Console.WriteLine(coffeMachine.Brew(ref cup));
        Console.WriteLine(cup.Brewage.ToString());
        Console.WriteLine(coffeMachine.FilterHolder.Filter.ToString());
        Console.WriteLine();

        Console.WriteLine(coffeMachine.TurnOff());
    }
}