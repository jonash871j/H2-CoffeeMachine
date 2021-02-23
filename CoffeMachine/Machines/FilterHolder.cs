namespace Machines
{
    public class FilterHolder
    {
        public Filter Filter { get; set; } = null;

        public string InsertFilter(Filter filter)
        {
            if (Filter != null)
            {
                return "There is already a filter in the holder!";
            }
            else
            {
                Filter = filter;
                return $"Filter was inserted";
            }
        }

        public string RemoveFilter()
        {
            Filter = null;
            return $"Filter was removed";
        }

        public bool HasCleanFilterWithIngredient()
        {
            return (Filter != null) && (!Filter.IsSoaked) && (Filter.IngredientAmount > 0);
        }

        public override string ToString()
        {
            if (Filter == null)
            {
                return "No filter in the holder";
            }
            return "Filter in the holder";
        }
    }

}
