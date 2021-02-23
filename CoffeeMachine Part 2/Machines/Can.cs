using System;
using System.Collections.Generic;
using System.Text;

namespace Machines
{
    public class Can
    {
        public Can()
        {
            EmptyCan();
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
        public string EmptyCan()
        {
            Brewage = Brewage.ThinAir;
            return "Can was empty out";
        }
    }
}
