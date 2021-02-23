using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Machines
{
    public class HotDrinkMachine : Machine
    {
        public HotDrinkMachine(int sizeFactor)
            : base()
        {
            SolubleIngredient = SolubleIngredient.Coffee;
            MaxWaterMlAmount = 100 * sizeFactor;
            MaxSolubleIngredient = 10 * sizeFactor;

            WaterMlAmount = 0;
            SolubleIngredientAmount = 0;
            BrewSolutionMlAmount = 0;
            IsFilterInserted = false;
        }

        public SolubleIngredient SolubleIngredient { get; set; }
        public int MaxWaterMlAmount {get; private set; }
        public int MaxSolubleIngredient {get; private set; }
        public int WaterMlAmount { get; private set; }
        public int SolubleIngredientAmount { get; private set; }
        public int BrewSolutionMlAmount { get; private set; }
        public bool IsFilterInserted { get; private set; }
        public bool IsBrewing { get; private set; }

        /// <summary>
        /// Used to insert filter
        /// </summary>
        /// <returns>Message process state</returns>
        public string InsertFilter()
        {
            if (IsBrewing)
            {
                return "Machine is brewing, don't change anything!";
            }
            else if (IsFilterInserted)
            {
                return $"Filter is already inserted";
            }
            IsFilterInserted = true;
            return $"Filter was inserted";
        }

        /// <summary>
        /// Used to remove filter
        /// </summary>
        /// <returns>Message process state</returns>
        public string RemoveFilter()
        {
            if (IsBrewing)
            {
                return "Machine is brewing, don't change anything!";
            }
            else if (!IsFilterInserted)
            {
                return $"No filter was removed";
            }
            IsFilterInserted = false;
            return $"Filter was removed";
        }

        /// <summary>
        /// Used fill machine with water
        /// </summary>
        /// <returns>Message process state</returns>
        public string FillWithWater(int mlAmount)
        {
            if (IsBrewing)
            {
                return "Machine is brewing, don't change anything!";
            }
            else if (WaterMlAmount + mlAmount > MaxWaterMlAmount)
            {
                return $"You tried to add to much water max is {WaterMlAmount}ml!";
            }
            else
            {
                WaterMlAmount += mlAmount;
                return $"{mlAmount}ml Water was added to the machine";
            }
        }

        /// <summary>
        /// Used add soluble ingredient to filter
        /// </summary>
        /// <returns>Message process state</returns>
        public string AddSolubleIngredient(SolubleIngredient solubleIngredient, int amount)
        {
            if (IsBrewing)
            {
                return "Machine is brewing, don't change anything!";
            }
            else if (!IsFilterInserted)
            {
                return "No filter was inserted";
            }
            else if (SolubleIngredientAmount + amount > MaxWaterMlAmount)
            {
                return $"You tried to add to much of the {SolubleIngredient} to the filter!";
            }
            else
            {
                SolubleIngredient = solubleIngredient;
                SolubleIngredientAmount += amount;
                return $"{amount}g {SolubleIngredient} was added to the machine";
            }
        }

        /// <summary>
        /// Used to empty all brew solution out of the can
        /// </summary>
        /// <returns>Message process state</returns>
        public string EmptyOutBrewSolution()
        {
            if (BrewSolutionMlAmount <= 0)
            {
                return $"No {SolubleIngredient} to empty out!";
            }
            BrewSolutionMlAmount = 0;
            return $"{SolubleIngredient} can was empty out";
        }

        /// <summary>
        /// Used to brew the solution
        /// </summary>
        /// <returns>Message of the brewing process</returns>
        public string Brew()
        {
            if ((!IsTurnedOn) || (!IsFilterInserted) || (WaterMlAmount - 10 < 0) || (SolubleIngredientAmount - 1 < 0))
            {
                IsBrewing = false;
                return  $"Couldn't brew {SolubleIngredient}!";
            }
            else
            {
                IsBrewing = true;

                WaterMlAmount -= 10;
                SolubleIngredientAmount -= 1;
                BrewSolutionMlAmount++;

                if (BrewSolutionMlAmount >= MaxWaterMlAmount)
                {
                    BrewSolutionMlAmount--;
                    return $"{SolubleIngredient} is overflowing!";
                }

                return $"Brewing {SolubleIngredient}...";
            }
        }

        public override string ToString()
        {
            return $" - HotDrinkMachine states\n" +
                $"IsTurnedOn: {IsTurnedOn}\n" +
                $"IsFilterInserted: {IsFilterInserted}\n" +
                $"WaterMlAmount: {WaterMlAmount}\n" +
                $"{SolubleIngredient}: {SolubleIngredientAmount}g\n" +
                $"BrewSolution: {BrewSolutionMlAmount}ml\n";
        }
    }
}