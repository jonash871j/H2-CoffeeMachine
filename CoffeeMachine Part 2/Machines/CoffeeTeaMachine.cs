using System;
using System.Collections.Generic;
using System.Text;

namespace Machines
{
    public class CoffeeTeaMachine : HotDrinkFilterMachine
    {
        public int CoffeeBeansAmount { get; private set; } = 0;

        public string AddCoffeeBeans(int amount)
        {
            if (!IsFilterInserted)
            {
                return "No filter was inserted";
            }
            else
            {
                CoffeeBeansAmount += amount;
                return $"{amount} beans was added to the machine";
            }
        }

        public override string Brew(ref Can can)
        {
            if ((!IsHotDrinkFilterMachineRequirementsMet()) || (CoffeeBeansAmount <= 0))
            {
                return "Couldn't brew coffee!";
            }
            else
            {
                can.FillWithBrewage(new Brewage(WaterMlAmount, CoffeeBeansAmount, "Coffee"));

                WaterMlAmount = 0;
                CoffeeBeansAmount = 0;

                return "Coffee was brewed.";
            }
        }

        public override string ToString()
        {
            return $"IsTurnedOn     : {IsTurnedOn}\n" +
                $"IsFilterInserted  : {IsFilterInserted}\n" +
                $"WaterMlAmount     : {WaterMlAmount}\n" +
                $"CoffeeBeansAmount : {CoffeeBeansAmount}\n";
        }
    }
}
