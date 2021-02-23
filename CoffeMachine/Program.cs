using System;
using System.Threading;
using Machines;

class Program
{
    static void Main(string[] args)
    {
        CoffeeMachine coffeMachine = new CoffeeMachine();
        Console.WriteLine(coffeMachine.TurnOn());
        Console.WriteLine(coffeMachine.InsertFilter());
        Console.WriteLine(coffeMachine.AddCoffeeBeans(10));
        Console.WriteLine(coffeMachine.FillWithWater(100));

        Can can = new Can();
        Console.WriteLine(coffeMachine.Brew(ref can));
        Console.WriteLine(can.Brewage.ToString());
    }
}