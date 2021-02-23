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
    }
}