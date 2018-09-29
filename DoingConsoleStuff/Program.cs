using System;

namespace RiskSchlachtenSimulator
{
    class Program
    {
        static void Main(string[] args)
        {

            Army attackingArmy = new Army(100, 100, 100, 400);
            Army defendingArmy = new Army(80, 120, 30, 650);
            SchlachtenSimulator sim = new SchlachtenSimulator();
            Console.WriteLine((sim.CalculateProbability(attackingArmy, defendingArmy, 10000) * 100)  + "%");
            System.Console.Read();
        }
    }
}
