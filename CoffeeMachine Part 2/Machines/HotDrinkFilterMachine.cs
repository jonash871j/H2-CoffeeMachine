using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Machines
{
    public abstract class HotDrinkFilterMachine : Machine
    {
        public int WaterMlAmount { get; protected set; } = 0;
        public bool IsFilterInserted { get; protected set; } = false;

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

        public bool IsHotDrinkFilterMachineRequirementsMet()
        {
            return (IsTurnedOn) || (IsFilterInserted) || (WaterMlAmount > 0);
        }
        public abstract string Brew(ref Can can);
    }
}