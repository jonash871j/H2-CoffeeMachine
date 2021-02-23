using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Machines
{
    public class CoffeeMachine : Machine
    {
        public CoffeeMachine(int sizeFactor)
            : base(isTurnedOn: false)
        {
            MaxWaterMlAmount = 100 * sizeFactor;
            MaxCoffeBeans = 10 * sizeFactor;

            WaterMlAmount = 0;
            CoffeeBeansAmount = 0;
            CoffeeMlAmount = 0;
            IsFilterInserted = false;
        }

        public int MaxWaterMlAmount {get; private set; }
        public int MaxCoffeBeans {get; private set; }
        public int WaterMlAmount { get; private set; }
        public int CoffeeBeansAmount { get; private set; }
        public int CoffeeMlAmount { get; private set; }
        public bool IsFilterInserted { get; private set; }
        public bool IsBrewing { get; private set; }

        public string InsertFilter()
        {
            if (IsFilterInserted)
            {
                return $"Filter is already inserted";
            }
            IsFilterInserted = true;
            return $"Filter was inserted";
        }
        public string RemoveFilter()
        {
            if (!IsFilterInserted)
            {
                return $"No filter was removed";
            }
            IsFilterInserted = false;
            return $"Filter was removed";
        }

        public string FillWithWater(int mlAmount)
        {
            if (WaterMlAmount + mlAmount > MaxWaterMlAmount)
            {
                return $"You tried to add to much water max is {WaterMlAmount}ml!";
            }
            else
            {
                WaterMlAmount += mlAmount;
                return $"{mlAmount}ml Water was added to the machine";
            }
        }

        public string AddCoffeeBeans(int amount)
        {
            if (!IsFilterInserted)
            {
                return "No filter was inserted";
            }

            if (CoffeeBeansAmount + amount > MaxWaterMlAmount)
            {
                return $"You tried to add to many coffee beans max is {CoffeeBeansAmount} beans!";
            }
            else
            {
                CoffeeBeansAmount += amount;
                return $"{amount} beans was added to the machine";
            }
        }

        public string EmptyOutCoffeCan()
        {
            if (CoffeeMlAmount <= 0)
            {
                return "No coffee to empty out!";
            }
            CoffeeMlAmount = 0;
            return "Coffee can was empty out";
        }

        public string BrewCoffee()
        {
            if ((!IsTurnedOn) || (!IsFilterInserted) || (WaterMlAmount - 10 <= 0) || (CoffeeBeansAmount - 1 <= 0))
            {
                IsBrewing = false;
                return "Couldn't brew coffee!";
            }
            else
            {
                IsBrewing = true;

                WaterMlAmount -= 10;
                CoffeeBeansAmount -= 1;
                CoffeeMlAmount++;

                if (CoffeeMlAmount >= MaxWaterMlAmount)
                {
                    CoffeeMlAmount--;
                    return "Coffee is overflowing!";
                }

                return "Brewing coffee...";
            }
        }

        public override string ToString()
        {
            return $"IsTurnedOn     : {IsTurnedOn}\n" +
                $"IsFilterInserted  : {IsFilterInserted}\n" +
                $"WaterMlAmount     : {WaterMlAmount}\n" +
                $"CoffeeBeansAmount : {CoffeeBeansAmount}\n" +
                $"CoffeeMlAmount    : {CoffeeMlAmount}\n";
        }
    }
}