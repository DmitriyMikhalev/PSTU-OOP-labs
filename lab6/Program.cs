using System;
using System.Collections.Generic;

namespace lab5
{
    class Program
    {
        public static uint HandleMenu(string message, uint maxValue = 4)
        {
            bool parsed;
            uint choosen;
            do
            {
                Console.Write(message);
                parsed = uint.TryParse(Console.ReadLine(), out choosen);
            } while (!parsed || choosen == 0 || choosen > maxValue);
            return choosen;
        }
        public static void PrintArray(ref int[,] array, int size1, int size2)
        {
            Console.WriteLine();
            for (int i = 0; i < size1; ++i)
            {
                for (int j = 0; j < size2; ++j)
                {
                    Console.Write(array[i, j].ToString() + " ");
                }
                Console.Write("\n");
            }
            Console.WriteLine();
        }
        public static void FillArray(ref int[,] array, Random rnd, int size1, int size2)
        {
            for (int i = 0; i < size1; ++i)
            {
                for (int j = 0; j < size2; ++j)
                {
                    array[i, j] = rnd.Next(-5, 10);
                }
            }
        }
        public static short CheckZeroes(ref int[,] array, int size1, int size2)
        {
            for (short i = 0; i < size1; ++i)
            {
                ushort count = 0;
                for (short j = 0; j < size2; ++j)
                {
                    if (array[i, j] == 0) ++count;

                    if (count >= 2) return i;
                }
            }
            return -1;
        }
        public static int InputNumber()
        {
            bool parsed;
            int value;
            Console.WriteLine();
            do
            {
                Console.Write("Введите элемент массива: ");
                parsed = int.TryParse(Console.ReadLine(), out value);
            } while (!parsed);
            Console.WriteLine();
            return value;
        }
        public static void InputArray(ref int[,] array, int size1, int size2)
        {
            for (int i = 0; i < size1; ++i)
            {
                for (int j = 0; j < size2; ++j)
                {
                    array[i, j] = InputNumber();
                }
            }
        }
        public static void DeleteZeroRow(ref int[,] array, ref int size1, int size2)
        {
            if (array.Length == 0)
            {
                Console.Write("\nСамый умный что ли? Массив пустой.");
                return;
            }
            short indexToDelete = CheckZeroes(ref array, size1, size2);
            if (indexToDelete != -1)
            {
                Console.WriteLine("\nИндекс нужной строки: " + CheckZeroes(ref array, size1, size2));

                int[,] newArr = new int[size1 - 1, size2];
                for (int i = 0; i < indexToDelete; ++i)
                {
                    for (int j = 0; j < size2; ++j)
                    {
                        newArr[i, j] = array[i, j];
                    }
                }

                for (int i = indexToDelete + 1; i < size1; ++i)
                {
                    for (int j = 0; j < size2; j++)
                    {
                        newArr[i - 1, j] = array[i, j];
                    }
                }
                array = newArr;
                --size1;
                Console.Write("\nРезультат: ");
                PrintArray(ref array, size1, size2);
                return;
            }
            Console.WriteLine("\nУмный самый что ли? Не видно, что удалять нечего?..\n");
            return;
        }
        public static void Task1()
        {
            Random rnd = new Random();

            uint option = 0;
            int size1 = rnd.Next(5, 8);
            int size2 = rnd.Next(3, 10);
            int[,] array = new int[size1, size2];

            while (option != 5)
            {
                option = HandleMenu
                (
                    "1. Сгенерировать двумерный массив.\n"
                    + "2. Ввести двумерный массив.\n"
                    + "3. Удалить первую строку, в которой больше 1-го 0.\n"
                    + "4. Показать массив.\n"
                    + "5. Выход.\nКоманда: ",
                    5
                );
                switch (option)
                {
                    case 1:
                        FillArray(ref array, rnd, size1, size2);
                        PrintArray(ref array, size1, size2);
                        break;
                    case 2:
                        InputArray(ref array, size1, size2);
                        Console.WriteLine("Введенный массив:");
                        PrintArray(ref array, size1, size2);
                        break;
                    case 3:
                        DeleteZeroRow(ref array, ref size1, size2);
                        break;
                    case 4:
                        Console.WriteLine("\nМассив получился такой: ");
                        PrintArray(ref array, size1, size2);
                        break;
                    case 5:
                        break;
                }
            }
        }

        public static bool ValidString(ref string str)
        {
            var patternEnd = ".!?";
            var pattern = ",:;";
            if (str.Length < 2 || !(str[0] <= 90 && str[0] >= 65)) return false; // ЕСЛИ СТРОКА МАЛЕНЬКАЯ ИЛИ НЕ С ЗАГЛАВНОЙ

            if (str.Length >= 2 && !patternEnd.Contains(str[str.Length - 1].ToString()) || str[str.Length - 2] == ' ') return false; // ЕСЛИ СТРОКА НЕ ЗАКАНЧИВАЕТСЯ СИМВОЛОМ

            for (int i = 0; i < str.Length; ++i) // ПРОВЕРКА НАЧИНКИ
            {
                char ch = str[i];
                if (i >= 2 && ch >= 65 && ch <= 90)
                {
                    if (!(str[i - 1].Equals(' ') && patternEnd.Contains(str[i - 2].ToString()))) return false; // ЕСЛИ ЗАГЛАВНАЯ, ТО ДОЛЖЕН БЫТЬ ПРОБЕЛ, ПЕРЕД НИМ .?! 
                }

                if (i >= 1 && pattern.Contains(ch.ToString()))
                {
                    if (str[i + 1] != ' ') return false; // ЕСЛИ ПОСЛЕ ,;: НЕТ ПРОБЕЛА
                }
            }

            return true;

        }
        public static bool ValidText(ref string str)
        {
            var patternEnd = ".!?";
            int sentenceCount = 0;
            for (int i = 0; i < str.Length; ++i)
            {
                var ch = str[i];
                if (patternEnd.Contains(ch.ToString())) ++sentenceCount;
            }
            if (sentenceCount == 0) return false;

            int startSentence = 0;
            string sentence;
            for (int i = 0; i < str.Length; ++i)
            {
                if (patternEnd.Contains(str[i].ToString()))
                {
                    sentence = str.Substring(startSentence, i - startSentence + 1);

                    if (!ValidString(ref sentence)) return false;
                    startSentence = i + 2;
                    ++i;
                }
            }
            return true;
        }
        public static void DeleteDuplicateSpaces(ref string str)
        {
            string newString = "";
            for (int i = 0; i < str.Length; ++i)
            {
                if (newString.Length > 2) 
                {
                    if (newString[newString.Length - 1].Equals(' ') && str[i].Equals(' ')) continue;
                }
                newString = string.Concat(newString, str[i].ToString());
            }
            str = newString;
        }
        public static string InputString()
        {
            string str;
            do
            {
                Console.WriteLine("Введите строку:");
                str = Console.ReadLine();
                str = str.Trim();
                DeleteDuplicateSpaces(ref str);
            } while (!ValidText(ref str) || !".?!".Contains(str[str.Length - 1].ToString()));
            return str;
        }
        public static void Task2()
        {
            string stringToChange = InputString();
            Console.Write($"String is: {stringToChange}");
            var result = ConcatenateList(separateSentence(stringToChange));
            Console.WriteLine($"\nResult is: {result}");
        }

        public static List<string> separateSentence(string str)
        {

            List<string> list = new List<string>();
            var pattern = " .?,;:!";
            string symbol;
            string word;
            for (int i = 0; i < str.Length; i++)
            {
                if (pattern.Contains(str[i].ToString()))
                {
                    symbol = str[i].ToString();
                    word = str.Substring(0, i);
                    if (pattern.Contains(symbol))
                    {
                        str = str.Remove(i, 1);
                    }

                    list.Add(FormatWord(word, list.Count + 1) +  symbol);
                    str = str.Substring(i);
                    str = str.Trim();

                    i = -1;
                }
            }
            return list;
        }

        public static string ConcatenateList(List<string> list)
        {
            string str = "";
            string pattern = "?.!,:;";
            for (int i = 0; i < list.Count; ++i)
            { 
                if (pattern.Contains(list[i][list[i].Length - 1].ToString())) list[i] += " ";
                str = string.Concat(str, list[i]);
            }
            return str;
        }
        public static string FormatWord(string word, int count)
        {
            for (int i = 0; i < count; i++)
            {
                word += word[0];
                word = word.Substring(1);
            }
            return word;
        }
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Console.ReadKey();
        }
    }
}
