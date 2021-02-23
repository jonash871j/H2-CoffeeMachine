using System;
using System.Threading;
using Machines;

class Program
{
    static HotDrinkMachine hotDrinkMachine = new HotDrinkMachine(1);

    static void HotDrinkMachineSetup(SolubleIngredient solubleIngredient)
    {
        Console.WriteLine(hotDrinkMachine.TurnOn());
        Console.WriteLine(hotDrinkMachine.InsertFilter());
        Console.WriteLine(hotDrinkMachine.AddSolubleIngredient(solubleIngredient, 10));
        Console.WriteLine(hotDrinkMachine.FillWithWater(100));
        Console.ReadKey();
    }

    static void BrewProcess()
    {
        Console.WriteLine(hotDrinkMachine.Brew());

        while (hotDrinkMachine.IsBrewing)
        {
            Console.WriteLine(hotDrinkMachine.Brew());
            Console.WriteLine(hotDrinkMachine.ToString());
            Thread.Sleep(100);
            Console.Clear();
        }
        Console.WriteLine(hotDrinkMachine.ToString());
        Console.ReadKey();
    }
    static void CleanMachine()
    {
        Console.WriteLine(hotDrinkMachine.EmptyOutBrewSolution());
        Console.WriteLine(hotDrinkMachine.RemoveFilter());
        Console.WriteLine(hotDrinkMachine.TurnOff());
        Console.WriteLine(hotDrinkMachine.ToString());
        Console.ReadKey();
    }

    static void Main(string[] args)
    {
        HotDrinkMachineSetup(SolubleIngredient.Coffee);
        BrewProcess();
        CleanMachine();

        HotDrinkMachineSetup(SolubleIngredient.Tea);
        BrewProcess();
        CleanMachine();
    }
}