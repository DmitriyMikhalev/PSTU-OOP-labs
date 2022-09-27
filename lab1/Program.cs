using System;
using System.Numerics;

namespace Lab1
{
    class Program
    {
        static double InputDoubleData()
        {
            string parsed;
            double res;
            do
            {
                Console.WriteLine("Введите дробное число в диапазоне +-1,5 x 10^-45 до ±3,4 x 10^38:");
                parsed = Console.ReadLine();

                if (double.TryParse(parsed, out res)) return res;
                else Console.WriteLine("Введена строка.");
            } while (true);
        }

        static double InputDoubleDataLimited(double limit1, double limit2)
        {
            string parsed;
            double res;
            do
            {
                Console.WriteLine($"Введите дробное число в диапазоне {limit1} до {limit2}:");
                parsed = Console.ReadLine();

                if (double.TryParse(parsed, out res))
                {
                    if (CorrectSectionDouble(limit1, limit2, res)) return res;
                    else Console.WriteLine("Выход за границы диапазона.");
                }
                else Console.WriteLine("Введена строка.");
            } while (true);
        }
        static bool CorrectSectionDouble(double limit1, double limit2, double value)
        {
            if (limit1 <= value && value <= limit2) return true;
            return false;
        }
        static bool CorrectSection(BigInteger value)
        {
            return int.MinValue <= value && value <= int.MaxValue;
        }
        static int InputIntegerData()
        {
            string parsed = "";
            var res = new BigInteger();
            bool isString;
            string pattern = "0123456789-,";
            double noNeed;
            do
            {
                isString = false;
                Console.WriteLine("Введите целое число в диапазоне [-2147483648; 2147483647]:");
                parsed = Console.ReadLine();

                if (BigInteger.TryParse(parsed, out res))
                {
                    if (CorrectSection(res)) return (int)res;

                    else Console.WriteLine("Слишком большое число по модулю.");
                }
                else
                {
                    foreach(char i in parsed)
                    {
                        if (!pattern.Contains(i.ToString()))
                        {
                            isString = true;
                            break;
                        }
                    }
                    if (!isString && double.TryParse(parsed, out noNeed)) Console.WriteLine("Введен double.");

                    else Console.WriteLine("Введена строка.");
                }
            } while (true);
        }
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Console.ReadKey();
        }
        static void Task1()
        {
            Console.WriteLine("Ввод значений m и n для задания 1.1");
            int n = InputIntegerData();
            int m = InputIntegerData();
            dynamic result = n++ + m--;
            Console.WriteLine($"n++ + m-- = {result}\n", result);


            Console.WriteLine("Ввод значения x для задания 1.2");
            const double LIMIT1 = -1.61803;
            const double LIMIT2 = 0.618034;
            double x = InputDoubleDataLimited(LIMIT1, LIMIT2);
            result = Math.Asin(x + Math.Pow(x, 2));
            Console.WriteLine($"result = {result}\n", result);


            Console.WriteLine("Ввод значений m и n для задания 1.3");
            n = InputIntegerData();
            m = InputIntegerData();
            result = n * m < n++;
            Console.WriteLine($"n*m < n++ = {result}\n", result);


            Console.WriteLine("Ввод значений m и n для задания 1.4");
            n = InputIntegerData();
            m = InputIntegerData();
            result = n-- > ++m;
            Console.WriteLine($"n-- > ++m = {result}", result);

            return;
        }
        static void Task2()
        {
            Console.WriteLine("\nВвод значений x и y для задания 2.");
            double x = InputDoubleData();
            double y = InputDoubleData();

            Console.Write("Точка ");
            if (!((y >= -5 && y <= -3 && x >= -7 && x <= 0) || (y >= 2 && y <= 5 && x >= 0)))
            {
                Console.Write("не ");
            }
            Console.Write("попадает в область\n");

            return;

        }
        static void Task3()
        {

            dynamic a = 1000, b = 0.0001;

            dynamic Value1 = Math.Pow((a - b), 4);
            dynamic Value2 = Math.Pow(a, 4) + 6
                            * Math.Pow(a, 2) * Math.Pow(b, 2)
                            - 4 * a * Math.Pow(b, 3);
            dynamic Value3 = Math.Pow(b, 4) - 4 * Math.Pow(a, 3) * b;

            Console.WriteLine("\n" + ((Value1 - Value2) / Value3).ToString() + " - результат в double");

            a = 1000F;
            b = 0.0001F;

            Value1 = (float)Math.Pow((a - b), 4);
            Value2 = (float)Math.Pow(a, 4) + 6
                            * Math.Pow(a, 2) * Math.Pow(b, 2)
                            - 4 * a * Math.Pow(b, 3);
            Value3 = (float)Math.Pow(b, 4) - 4 * Math.Pow(a, 3) * b;

            Console.WriteLine(((Value1 - Value2) / Value3).ToString() + " - результат во float");

            return;
        }
    }
}
