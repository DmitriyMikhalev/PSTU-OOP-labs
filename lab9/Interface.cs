using System;
using System.Collections.Generic;
using System.Text;

namespace lab9
{
    class Interface
    {
        public static uint ReadUInt32(in string message, in uint minValue = System.UInt32.MinValue, in uint maxValue = System.UInt32.MaxValue)
        {
            if (maxValue < minValue) throw new ArgumentException("Минимальное значение оказалось больше максимального.");

            bool parsed = false;
            uint value = 0;
            do
            {
                Console.Write(message);
                try
                {
                    value = UInt32.Parse(Console.ReadLine());
                    parsed = true;
                }
                catch (FormatException) { Console.WriteLine("Некорректный символ, повторите ввод."); }
                catch (OverflowException) { Console.WriteLine("Некорректное значение, повторите ввод в нужном диапазоне."); }

                if (parsed)
                {
                    if (value <= maxValue) break;
                    else parsed = false;
                }

            } while (!parsed);

            return value;
        }
        public static void Print(in MoneyArray array)
        {
            for (int i = 0; i < array.Length; ++i) Console.WriteLine(array[i].GetInfo());
        }
    }
}
