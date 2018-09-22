using System;
using System.Collections.Generic;
using System.Text;

namespace DoingConsoleStuff
{
    class SchlachtenSimulator
    {
        internal class army
        {
            public int numSiegeMachines { get; set; }
            public int numArchers { get; set; }
            public int numKnights { get; set; }
            public int numMeat { get; set; }

            public army(int numSiegeMachines, int numArchers, int numKnights, int numMeat)
            {
                this.numSiegeMachines = numSiegeMachines;
                this.numArchers = numArchers;
                this.numKnights = numKnights;
                this.numMeat = numMeat;
            }
        }

        const double siegeMachineHitRate = 2 / 3;
        const double archerHitRate = 1 / 3;
        const double knightHitRate = 2 / 3;

        army AttackingArmy;
        army DefendingArmy;

        public SchlachtenSimulator(int siegeMachineAtt, int siegeMachineDef, int archerAtt, int archerDef, int knightAtt, int knightDef, int meatAtt, int meatDef)
        {
            AttackingArmy = new army(siegeMachineAtt, archerAtt, knightAtt, meatAtt);
            DefendingArmy = new army(siegeMachineDef, archerDef, knightDef, meatDef);
        }
        

        private bool ArmyAlive(army Army)
        {
            return (Army.numSiegeMachines != 0 || Army.numArchers != 0 || Army.numKnights != 0 || Army.numMeat != 0);
        }


        private bool BothAlive(army Army1, army Army2)
        {
            return ArmyAlive(Army1) && ArmyAlive(Army2);
        }

        public int CalculateProbability(int numIterations)
        {
            int numWinsAtt = 0;
            int numWinsDef = 0;
            int numDraws = 0;
            army StartingAttackingArmy;
            army StartingDefendingArmy;
            for (int i = 1; i <= numIterations; i++)
            {
                StartingAttackingArmy = AttackingArmy;
                StartingDefendingArmy = DefendingArmy;
                switch(Fight(StartingAttackingArmy, StartingDefendingArmy))
                {
                    case 1:
                        numWinsAtt++;
                        break;
                    case -1:
                        numWinsDef++;
                        break;
                    case 0:
                        numDraws++;
                        break;
                    default:
                        Console.WriteLine("Wrong fight Exit Code.");
                        break;
                }
            }
            return numWinsAtt / numIterations;
        }


        public int Fight(army AttackingArmy, army DefendingArmy)
        {

            while(BothAlive(AttackingArmy, DefendingArmy))
            {
                Phase1(AttackingArmy, DefendingArmy);
                if (BothAlive(AttackingArmy, DefendingArmy))
                {
                    Phase2(AttackingArmy, DefendingArmy);
                    if (BothAlive(AttackingArmy, DefendingArmy))
                    {
                        Phase3(AttackingArmy, DefendingArmy);
                        if (BothAlive(AttackingArmy, DefendingArmy))
                        {
                            Phase4(AttackingArmy, DefendingArmy);
                        };
                    };
                };
            }

            if(!ArmyAlive(AttackingArmy) && !ArmyAlive(DefendingArmy))
            {
                return 0;
            }
            if(ArmyAlive(AttackingArmy))
            {
                return 1;
            }
            return -1;
        }

        private void Phase4(army attackingArmy, army defendingArmy)
        {
            throw new NotImplementedException();
        }

        private void Phase3(army attackingArmy, army defendingArmy)
        {
            throw new NotImplementedException();
        }

        private void Phase2(army attackingArmy, army defendingArmy)
        {
            throw new NotImplementedException();
        }

        private void Phase1(army attackingArmy, army defendingArmy)
        {
            int numKillsAtt;
            int numKillsDef;

            for (int i = 0; i < 2; i++)
            {
                numKillsAtt = 0;
                numKillsDef = 0;


            }
        }
    }

}
