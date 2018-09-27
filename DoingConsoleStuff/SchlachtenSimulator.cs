using System;
using System.Collections.Generic;
using System.Text;
using RiskSchlachtenSimulator;

namespace DoingConsoleStuff
{
    class SchlachtenSimulator
    {
        

        const double siegeMachineHitRate = 2 / 3;
        const double archerHitRate = 1 / 3;
        const double knightHitRate = 2 / 3;

        Army AttackingArmy;
        Army DefendingArmy;

        public SchlachtenSimulator(int siegeMachineAtt, int siegeMachineDef, int archerAtt, int archerDef, int knightAtt, int knightDef, int meatAtt, int meatDef)
        {
            AttackingArmy = new Army(siegeMachineAtt, archerAtt, knightAtt, meatAtt);
            DefendingArmy = new Army(siegeMachineDef, archerDef, knightDef, meatDef);
        }
        

        private bool ArmyAlive(Army army)
        {
            return (army.numSiegeMachines != 0 || army.numArchers != 0 || army.numKnights != 0 || army.numMeat != 0);
        }


        private bool BothAlive(Army Army1, Army Army2)
        {
            return ArmyAlive(Army1) && ArmyAlive(Army2);
        }

        public int CalculateProbability(int numIterations)
        {
            int numWinsAtt = 0;
            int numWinsDef = 0;
            int numDraws = 0;
            Army StartingAttackingArmy;
            Army StartingDefendingArmy;
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


        public int Fight(Army AttackingArmy, Army DefendingArmy)
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

        private void Phase4(Army attackingArmy, Army defendingArmy)
        {
            throw new NotImplementedException();
        }

        private void Phase3(Army attackingArmy, Army defendingArmy)
        {
            throw new NotImplementedException();
        }

        private void Phase2(Army attackingArmy, Army defendingArmy)
        {
            throw new NotImplementedException();
        }

        private void Phase1(Army attackingArmy, Army defendingArmy)
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
