using System;
using System.Diagnostics;
using System.Collections.Generic;


namespace lab11
{
    public class Program
    {
        static void print(in bool found, string value)
        {
            Console.Write(value + " элемент");
            if (!found)
            {
                Console.Write(" не");
            }
            Console.WriteLine(" был найден.");
        }

        static void Main(string[] args)
        {
            int count = ReadInt32("Введите количество элементов в коллекциях: ");
            if (count < 1000) count = 1000;
            int middle = count / 2;
            TestCollections collections = new TestCollections();
            collections.RandomInit(count);
            bool found;

            Console.WriteLine("\nПоиск 1-го элемента в LinkedList<Printing>");
            Console.WriteLine($"t = {GetTimeList(collections.fcPrinting, (Printing)collections.fcPrinting.First.Value.Clone(), out found)} мс.");
            print(found, "1-ый");
            Console.WriteLine("Поиск центрального элемента в LinkedList<Printing>");
            Printing toFind = null;
            var current = collections.fcPrinting.First;
            for (int i = 0; i < middle; i++)
            {
                current = current.Next;
                toFind = current.Value;
            }
            Console.WriteLine($"t = {GetTimeList(collections.fcPrinting, (Printing)toFind.Clone(), out found)} мс. ");
            print(found, "Центральный");
            Console.WriteLine("Поиск последнего элемента в LinkedList<Printing>");
            Console.WriteLine($"t = {GetTimeList(collections.fcPrinting, (Printing)collections.fcPrinting.Last.Value.Clone(), out found)} мс.");
            print(found, "Последний");
            Console.WriteLine("Поиск элемента, не входящего в LinkedList<Printing>");
            Console.WriteLine($"t = {GetTimeList(collections.fcPrinting, new Printing("x", 0, 2022, 0, 0), out found)} мс.");
            print(found, "Отсутствующий");
            Console.WriteLine();


            Console.WriteLine("Поиск 1-го элемента в LinkedList<string>");
            Console.WriteLine($"t = {GetTimeList(collections.fcString, (string)collections.fcString.First.Value.Clone(), out found)} мс.");
            print(found, "1-ый");
            Console.WriteLine("Поиск центрального элемента в LinkedList<string>.");
            Console.WriteLine($"t = {GetTimeList(collections.fcString, toFind.Clone().ToString(), out found)} мс.");
            print(found, "Центральный");
            Console.WriteLine("Поиск последнего элемента в LinkedList<string>");
            Console.WriteLine($"t = {GetTimeList(collections.fcString, (string)collections.fcString.Last.Value.Clone(), out found)} мс.");
            print(found, "Последний");
            Console.WriteLine("Поиск элемента, не входящего в LinkedList<string>");
            Console.WriteLine($"t = {GetTimeList(collections.fcString, "smthng", out found)} мс.");
            print(found, "Отсутствующий");
            Console.WriteLine();

            List<Printing> keys = new List<Printing>(collections.scPrintingBook.Keys);
            Console.WriteLine("Поиск 1-го ключа в SortedDictionary<Printing, Book>");
            Console.WriteLine($"t = {GetTimeDictionaryKey(collections.scPrintingBook, (Printing)keys[0].Clone(), out found)} мс.");
            print(found, "1-ый");
            Console.WriteLine("Поиск центрального ключа в SortedDictionary<Printing, Book>");
            Console.WriteLine($"t = {GetTimeDictionaryKey(collections.scPrintingBook, (Printing)keys[count / 2].Clone(), out found)} мс.");
            print(found, "Центральный");
            Console.WriteLine("Поиск последнего ключа в SortedDictionary<Printing, Book>");
            Console.WriteLine($"t = {GetTimeDictionaryKey(collections.scPrintingBook, (Printing)keys[count - 1].Clone(), out found)} мс.");
            print(found, "Последний");
            Console.WriteLine("Поиск ключа, не входящего в SortedDictionary<Printing, Book>");
            Console.WriteLine($"t = {GetTimeDictionaryKey(collections.scPrintingBook, new Printing("x", 0, 2022, 0, 0), out found)} мс.");
            print(found, "Отсутствующий");
            Console.WriteLine();

            List<string> keysString = new List<string>(collections.scStringBook.Keys);
            Console.WriteLine("Поиск 1-го ключа в SortedDictionary<string, Book>");
            Console.WriteLine($"t = {GetTimeDictionaryKey(collections.scStringBook, (string)keysString[0].Clone(), out found)} мс.");
            print(found, "1-ый");
            Console.WriteLine("Поиск центрального ключа в SortedDictionary<string, Book>");
            Console.WriteLine($"t = {GetTimeDictionaryKey(collections.scStringBook, (string)keysString[count / 2].Clone(), out found)} мс.");
            print(found, "Центральный");
            Console.WriteLine("Поиск последнего ключа в SortedDictionary<string, Book>");
            Console.WriteLine($"t = {GetTimeDictionaryKey(collections.scStringBook, (string)keysString[count - 1].Clone(), out found)} мс.");
            print(found, "Последний");
            Console.WriteLine("Поиск ключа, не входящего в SortedDictionary<string, Book>");
            Console.WriteLine($"t = {GetTimeDictionaryKey(collections.scStringBook, "smthng", out found)} мс.");
            print(found, "Отсутствующий");
            Console.WriteLine();

            List<Book> values = new List<Book>(collections.scStringBook.Values);
            Console.WriteLine("Поиск 1-го элемента в SortedDictionary<string, Book>");
            Console.WriteLine($"t = {GetTimeDictionaryValue(collections.scStringBook, (Book)values[0].Clone(), out found)} мс.");
            print(found, "1-ый");
            Console.WriteLine("Поиск центрального элемента в SortedDictionary<string, Book>");
            Console.WriteLine($"t = {GetTimeDictionaryValue(collections.scStringBook, (Book)values[count / 2].Clone(), out found)} мс.");
            print(found, "Центральный");
            Console.WriteLine("Поиск последнего элемента в SortedDictionary<string, Book>");
            Console.WriteLine($"t = {GetTimeDictionaryValue(collections.scStringBook, (Book)values[count - 1].Clone(), out found)} мс.");
            print(found, "Последний");
            Console.WriteLine("Поиск элемента, не входящего в SortedDictionary<string, Book>");
            Console.WriteLine($"t = {GetTimeDictionaryValue(collections.scStringBook, new Book("a", 1, 2022, 1, 1, "1"), out found)} мс.");
            print(found, "Отсутствующий");
            Console.WriteLine();

            Console.ReadKey();
        }
        public static string GetTimeList<T>(LinkedList<T> list, T obj, out bool found)
        {
            Stopwatch w = new Stopwatch();
            w.Start();
            found = list.Contains(obj);
            w.Stop();
            return w.Elapsed.TotalMilliseconds.ToString();
        }
        public static string GetTimeDictionaryKey<TKey, TValue>(SortedDictionary<TKey, TValue> dict, TKey key, out bool found)
        {
            Stopwatch w = new Stopwatch();
            w.Start();
            found = dict.ContainsKey(key);
            w.Stop();
            return w.Elapsed.TotalMilliseconds.ToString();
        }
        public static string GetTimeDictionaryValue<TKey, TValue>(SortedDictionary<TKey, TValue> dict, TValue value, out bool found)
        {
            Stopwatch w = new Stopwatch();
            w.Start();
            found = dict.ContainsValue(value);
            w.Stop();
            return w.Elapsed.TotalMilliseconds.ToString();
        }
        public static int ReadInt32(in string message, in int minValue = System.Int32.MinValue, in int maxValue = System.Int32.MaxValue)
        {
            if (maxValue < minValue) throw new ArgumentException("Минимальное значение оказалось больше максимального.");

            bool parsed = false;
            int value = 0;
            do
            {
                Console.Write(message);
                try
                {
                    value = Int32.Parse(Console.ReadLine());
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
    }
    static class Rnd
    {
        public static Random random = new Random();
    }
}
