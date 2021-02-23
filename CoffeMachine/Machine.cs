using System;
using System.Collections.Generic;
using System.Text;

namespace Machines
{
    public abstract class Machine
    {
        public Machine(bool isTurnedOn)
        {
            IsTurnedOn = isTurnedOn;
        }

        public bool IsTurnedOn { get; protected set; }

        /// <summary>
        /// Used to turn on the machine
        /// </summary>
        /// <returns>Message process state</returns>
        public virtual string TurnOn()
        {
            if (IsTurnedOn)
            {
                return "Machine is already turned on!";
            }
            IsTurnedOn = true;
            return "Machine was turned on";
        }
        /// <summary>
        /// Used to turn off the machine
        /// </summary>
        /// <returns>Message process state</returns>
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
