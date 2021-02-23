namespace Machines
{
    public class Filter
    {
        public Filter(string ingredentName, int ingredientAmount)
        {
            IngredentName = ingredentName;
            IngredientAmount = ingredientAmount;
        }

        public string IngredentName { get; set; }
        public int IngredientAmount { get; set; }
        public bool IsSoaked { get; set; } = false;

        public Brewage PourWater(int mlAmount)
        {
            IsSoaked = true;
            return new Brewage(mlAmount, IngredientAmount, IngredentName);
        }

        public string ToString()
        {
            return $"The filter has {IngredientAmount}g {IngredentName} in it";
        }
    }
}
