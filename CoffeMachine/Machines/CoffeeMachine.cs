using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Machines
{
    public class CoffeeMachine : Machine
    {
        public int WaterMlAmount { get; private set; } = 0;
        public int CoffeeBeansAmount { get; private set; } = 0;
        public bool IsFilterInserted { get; private set; } = false;

        public string InsertFilter()
        {
            IsFilterInserted = true;
            return $"Filter was inserted";
        }

        public string RemoveFilter()
        {
            IsFilterInserted = false;
            return $"Filter was removed";
        }

        public string FillWithWater(int mlAmount)
        {
            WaterMlAmount += mlAmount;
            return $"{mlAmount}ml Water was added to the machine";
        }

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

        public string Brew(ref Can can)
        {
            if ((!IsTurnedOn) || (!IsFilterInserted) || (WaterMlAmount <= 0) || (CoffeeBeansAmount <= 0))
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