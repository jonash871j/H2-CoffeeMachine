namespace Machines
{
    public abstract class Machine
    {
        public Machine()
        {
            IsTurnedOn = false;
        }

        public bool IsTurnedOn { get; protected set; }

        public virtual string TurnOn()
        {
            if (IsTurnedOn)
            {
                return "Machine is already turned on!";
            }
            IsTurnedOn = true;
            return "Machine was turned on";
        }

        public virtual string TurnOff()
        {
            if (!IsTurnedOn)
            {
                return "Machine is already turned off!";
            }
            IsTurnedOn = false;
            return "Machine was turned off";
        }
    }
}
