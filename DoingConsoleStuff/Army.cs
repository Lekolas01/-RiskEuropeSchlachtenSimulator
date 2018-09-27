using System;
using System.Collections.Generic;
using System.Text;

namespace RiskSchlachtenSimulator
{
    public class Army
    {
        public int numSiegeMachines { get; set; }
        public int numArchers { get; set; }
        public int numKnights { get; set; }
        public int numMeat { get; set; }

        public Army(int numSiegeMachines, int numArchers, int numKnights, int numMeat)
        {
            this.numSiegeMachines = numSiegeMachines;
            this.numArchers = numArchers;
            this.numKnights = numKnights;
            this.numMeat = numMeat;
        }
    }
}
