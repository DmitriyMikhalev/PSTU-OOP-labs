using System;

namespace Lab1
{
    class Program
    {
        static void InputDoubleDataTask1(out double x, string message)
        {
            bool parsed;
            do
            {
                Console.WriteLine(message);
                parsed = double.TryParse(Console.ReadLine(), out x);
            } while (!(parsed && Math.Abs(x + Math.Pow(x, 2)) <= 1));
        }
        static void InputDoubleDataTask2(out double x, string message)
        {
            bool parsed;
            do
            {
                Console.WriteLine(message);
                parsed = double.TryParse(Console.ReadLine(), out x);
            } while (!parsed);
        }
        static void InputFloatDataTask3(out float x, string message)
        {
            bool parsed;
            do
            {
                Console.WriteLine(message);
                parsed = float.TryParse(Console.ReadLine(), out x);
            } while (!parsed);
        }
        static void InputIntegerData(out int n, out int m)
        {
            bool parsedFirst, parsedSecond;
            do
            {
                Console.WriteLine("Введите целое значение n:");
                parsedFirst = int.TryParse(Console.ReadLine(), out n);

                Console.WriteLine("Введите целое значение m:");
                parsedSecond = int.TryParse(Console.ReadLine(), out m);
            } while (!(parsedFirst && parsedSecond));
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
            InputIntegerData(out int n, out int m);
            dynamic result = n++ + m--;
            Console.WriteLine($"n++ + m-- = {result}\n", result);

            InputDoubleDataTask1(out double x, "Введите значение x, (-1.61803 <~ x <~ 0,618034):");
            result = Math.Asin(x + Math.Pow(x, 2));
            Console.WriteLine($"result = {result}\n", result);

            InputIntegerData(out n, out m);
            result = n * m < n++;
            Console.WriteLine($"n*m < n++ = {result}\n", result);

            InputIntegerData(out n, out m);
            result = n-- > ++m;
            Console.WriteLine($"n-- > ++m = {result}", result);

            return;
        }
        static void Task2()
        {
            InputDoubleDataTask2(out double x, "\nВведите значение x:");
            InputDoubleDataTask2(out double y, "Введите значение y:");

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
