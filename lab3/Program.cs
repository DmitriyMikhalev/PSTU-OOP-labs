using System;

namespace lab2
{
    class Program
    { 
        static void Task()
        {
            double currentN, sumN;
            double currentE, sumE;
            for (double x = 0.1; x <= 1; x += 0.09)
            {
                Console.Write($"X = {x}   ");

                currentN = sumN = 1;
                currentE = sumE = 1;

                for (int n = 1; n <= 10; n++)
                {
                    currentN = currentN * ((x * x) / (4 * n * n - 2 * n));
                    sumN += currentN;
                }
                Console.Write($"Sn = {sumN}   ");

                double previous = 0;
                for (int n = 1; Math.Abs(currentE - previous) > 0.0001; ++n)
                {
                    previous = currentE;
                    currentE = previous * ((x * x) / (4 * n * n - 2 * n));
                    sumE += currentE;
                }

                Console.Write($"Se = {sumE}   ");
                Console.Write($"Y = {Math.Cosh(x)}\n");
            }
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            Task();
        }
    }
}
