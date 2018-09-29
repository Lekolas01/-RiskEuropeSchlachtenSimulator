using System;

namespace Project_Euler
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            double sum;
            double sum2 = 0;
            for (int j = 0; j < 100; j++)
            {
                sum = 0;
                for (int i = 0; i < 100; i++)
                {
                    sum += rnd.NextDouble();
                }
                Console.WriteLine(sum);
                sum2 += sum;
            }
            Console.WriteLine("sum2: " + sum2);
                
            Console.Read();
        }
    }
}
