namespace Machines
{
    public class Cup
    {
        public Cup()
        {
            Empty();
        }
        public Cup(Brewage brewage)
        {
            Brewage = brewage;
        }

        public Brewage Brewage { get; private set; }

        public void FillWithBrewage(Brewage brewage)
        {
            Brewage = brewage;
        }
        public string Empty()
        {
            Brewage = Brewage.ThinAir;
            return "Can was empty out";
        }
    }
}
