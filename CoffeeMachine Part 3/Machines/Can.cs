namespace Machines
{
    public class Can
    {
        public Can()
        {
            Empty();
        }
        public Can(Brewage brewage)
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
