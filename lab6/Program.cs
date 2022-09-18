using System;

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

                int[,] new_arr = new int[size1 - 1, size2];
                for (int i = 0; i < indexToDelete; ++i)
                {
                    for (int j = 0; j < size2; ++j)
                    {
                        new_arr[i, j] = array[i, j];
                    }
                }

                for (int i = indexToDelete + 1; i < size1; ++i)
                {
                    for (int j = 0; j < size2; j++)
                    {
                        new_arr[i - 1, j] = array[i, j];
                    }
                }
                array = new_arr;
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
        static void Main(string[] args)
        {
            Task1();
            Console.ReadLine();
        }
    }
}
