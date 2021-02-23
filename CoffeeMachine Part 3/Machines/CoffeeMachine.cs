namespace Machines
{
    public class CoffeeMachine : Machine
    {
        public FilterHolder FilterHolder { get; private set; } = new FilterHolder();
        public int WaterMlAmount { get; private set; } = 0;

        public string InsertFilter(Filter filter) => FilterHolder.InsertFilter(filter);
        public string RemoveFilter() => FilterHolder.RemoveFilter();
        public string FillWithWater(int mlAmount)
        {
            WaterMlAmount += mlAmount;
            return $"{mlAmount}ml Water was added to the machine";
        }

        public string Brew(ref Can can)
        {
            if ((!FilterHolder.HasCleanFilterWithIngredient()) || (WaterMlAmount <= 0))
            {
                return "Couldn't brew!";
            }
            else
            {
                Brewage brewage = FilterHolder.Filter.PourWater(WaterMlAmount);
                can.FillWithBrewage(brewage);

                WaterMlAmount = 0;

                return $"{FilterHolder.Filter.IngredentName} was brewed in can.";
            }
        }

        // Copy paste :(
        // Should have look like this
        // Brew(ref FillableContainer) { code... }
        // Brew(ref Can can) => Brew(can);
        // Brew(ref Cup cup) => Brew(cup);

        public string Brew(ref Cup cup)
        {
            if ((!FilterHolder.HasCleanFilterWithIngredient()) || (WaterMlAmount <= 0))
            {
                return "Couldn't brew!";
            }
            else
            {
                Brewage brewage = FilterHolder.Filter.PourWater(WaterMlAmount);
                cup.FillWithBrewage(brewage);

                WaterMlAmount = 0;

                return $"{FilterHolder.Filter.IngredentName} was brewed in cup.";
            }
        }
    }
}