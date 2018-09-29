using System;
using System.Collections.Generic;
using System.Text;
using RiskSchlachtenSimulator;

namespace RiskSchlachtenSimulator
{
    public class SchlachtenSimulator
    {
        
        const double siegeMachineHitRate = (double)2 / (double)3;
        const double archerHitRate = 1 / 3;
        const double knightHitRate = 2 / 3;
        Random rnd = new Random();

        public SchlachtenSimulator()
        {
        }
        

        private bool ArmyAlive(Army army)
        {
            return (army.numSiegeMachines != 0 || army.numArchers != 0 || army.numKnights != 0 || army.numMeat != 0);
        }
        

        public double CalculateProbability(Army AttackingArmy, Army DefendingArmy, int numIterations)
        {

            int numWinsAtt = 0;
            int numWinsDef = 0;
            int numDraws = 0;
            Army StartingAttackingArmy;
            Army StartingDefendingArmy;

            for (int i = 0; i < numIterations; i++)
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
            double probability = numWinsAtt / numIterations;
            return probability;
        }


        private int Fight(Army AttackingArmy, Army DefendingArmy)
        {
            while (ArmyAlive(AttackingArmy) && ArmyAlive(DefendingArmy))
            {
                Phase1(AttackingArmy, DefendingArmy);
                if (ArmyAlive(AttackingArmy) && ArmyAlive(DefendingArmy))
                {
                    Phase2(AttackingArmy, DefendingArmy);
                    if (ArmyAlive(AttackingArmy) && ArmyAlive(DefendingArmy))
                    {
                        Phase3(AttackingArmy, DefendingArmy);
                        if (ArmyAlive(AttackingArmy) && ArmyAlive(DefendingArmy))
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

        int DamageArmyType(int numUnits, int numKills)
        {
            return numUnits -= Math.Min(numUnits, numKills);

        }
        

        private void DamageArmy(Army army, int numKills)
        {
            if (numKills > 0) {
                army.numMeat = DamageArmyType(army.numMeat, numKills);
                if (numKills > 0)
                {
                    army.numArchers = DamageArmyType(army.numArchers, numKills);
                    if(numKills > 0)
                    {
                        army.numKnights = DamageArmyType(army.numKnights, numKills);
                        if (numKills > 0)
                        {
                            army.numSiegeMachines = DamageArmyType(army.numSiegeMachines, numKills);
                        }
                    }
                }
            }
        }


        private void TradeDamage(Army AttackingArmy, int AttackerKills, Army DefendingArmy, int DefenderKills)
        {

            DamageArmy(AttackingArmy, DefenderKills);
            DamageArmy(DefendingArmy, AttackerKills);
        }


        private int Phase1To3(int numHits, int hitRate)
        {
            int count = 0;
            for (int i = 1; i <= numHits; i++)
            {
                if (hitRate >= rnd.NextDouble())
                {
                    count++;
                }
            }
            return count;
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
            int numKillsAtt = 0;
            int numKillsDef = 0;

            for (int i = 1; i <= attackingArmy.numSiegeMachines * 2; i++)
            {
                if (siegeMachineHitRate >= rnd.NextDouble()) {
                    numKillsAtt++;
                };
            }
              
            for (int i = 1; i <= defendingArmy.numSiegeMachines * 2; i++)
            {
                if (siegeMachineHitRate >= rnd.NextDouble())
                {
                    numKillsDef++;
                };
            }
            TradeDamage(attackingArmy, numKillsAtt, defendingArmy, numKillsDef);
        }
    }

}
