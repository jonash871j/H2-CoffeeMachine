using System;
using System.Collections.Generic;
using System.Text;

namespace Machines
{
    public class Brewage
    {
        public static Brewage ThinAir { get => new Brewage(0, 0, "thin air"); }

        public Brewage(int mlAmount, int ingredientAmount, string name)
        {
            MlAmount = mlAmount;
            Concentration = (mlAmount / 100.0) * ingredientAmount;
            Name = name;
        }

        public int MlAmount { get; private set; }
        public double Concentration { get; private set; }
        public string Name { get; private set; }

        public bool CheckIsThinAir()
        {
            if (Name == "thin air")
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"- Brewage is {Name}\n" +
                $"{MlAmount}ml\n" +
                $"{Concentration}% concentration";
        }
    }
}
