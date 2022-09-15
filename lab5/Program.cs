using System;

namespace lab5
{
    class Program
    {
        public static uint HandleMenu(string message, uint maxValue=4)
        {
            bool parsed;
            uint choosen;
            do
            {
                Console.WriteLine(message);
                parsed = uint.TryParse(Console.ReadLine(), out choosen);
            } while (!parsed || choosen == 0 || choosen > maxValue);
            return choosen;
        }
        public static int[] FillArray(ref int[] array, Random rnd)
        { 
            for (int i = 0; i < array.Length; ++i)
            {
                array[i] = rnd.Next(-10, 100);
            }
            return array;
        }
        public static int[] FillArray(ref int[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                bool parsed;
                int value;
                do
                {
                    Console.Write("Введите элемент массива: ");
                    parsed = int.TryParse(Console.ReadLine(), out value);
                } while (!parsed);
                array[i] = value;
            }
            return array;
        }
        public static void PrintArray(ref int[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                Console.Write(array[i].ToString() + " ");
            }
            Console.Write("\n");
        }
        public static void PrintArray(ref int[,] array, int size1, int size2)
        {
            for (int i = 0; i < size1; ++i)
            {
                for (int j = 0; j < size2; ++j)
                {
                    Console.Write(array[i, j].ToString() + " ");
                }
                Console.Write("\n");
            }
        }
        public static void FillArray(ref int[,] array, Random rnd, int size)
        {
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    array[i, j] = rnd.Next(-5, 10);
                }
            }
        }
        public static void AddZeroes(ref int[] array)
        {
            int arrayLength = array.Length;
            int[] new_arr = new int[arrayLength + arrayLength / 2];

            int skipIndex = 2;
            int count = 0;
            for (int i = 0; i < new_arr.Length; i++)
            {
                if (i == skipIndex)
                {
                    skipIndex += 3;
                    count++;
                }
                else
                {
                    new_arr[i] = array[i - count];
                }
            }
            array = new_arr;
        }
        public static int[] CheckZeroes(ref int[,] arrayArrays, int size)
        {
            int[] arr = new int[size];
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    if (arrayArrays[i, j] == 0)
                    {
                        arr[i] = 1;
                        break;
                    }
                }
            }
            return arr;
        }
        public static void DeleteZeroRows(ref int[,] arrayArrays, ref int arrayArraysSize1)
        {
            int[] toDeleteRows = CheckZeroes(ref arrayArrays, arrayArraysSize1);
            int new_size = 0;
            for (int i = 0; i < toDeleteRows.Length; ++i)
            {
                if (toDeleteRows[i] == 0)
                {
                    ++new_size;             
                }
            }
            int[,] new_arr = new int[new_size, arrayArraysSize1];
            int count = 0;
            for (int i = 0; i < arrayArraysSize1; ++i)
            {
                if (toDeleteRows[i] == 1)
                {
                    count++;
                    continue;
                }
                for (int j = 0; j < arrayArraysSize1; ++j)
                {
                    new_arr[i - count, j] = arrayArrays[i, j];
                }
            }
            PrintArray(ref new_arr, new_size, arrayArraysSize1);
        }
        public static void FillArray(ref int[][] reapedArray, int size, Random rnd)
        {
            for (int i = 0; i < size; ++i)
            {
                reapedArray[i] = new int[rnd.Next(1, 6)];
            }

            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < reapedArray[i].Length; ++j)
                {
                    reapedArray[i][j] = rnd.Next(-5, 10);
                }
            }
        }
        public static void PrintArray(ref int[][] array, int size)
        {
            try
            {
                for (int i = 0; i < size; ++i)
                {
                    for (int j = 0; j < array[i].Length; ++j)
                    {
                        Console.Write(array[i][j].ToString() + " ");
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        public static void AddKRows(ref int[][] array, Random rnd, ref int size)
        {
            int new_size = size + rnd.Next(1, 5);
            int[][] new_arr = new int[new_size][];
            for (int i = 0; i < size; ++i)
            {
                new_arr[i] = array[i];
            }
            for (int i = size; i < new_size; ++i)
            {
                new_arr[i] = new int[rnd.Next(1, 7)];
                for (int j = 0; j < new_arr[i].Length; ++j)
                {
                    new_arr[i][j] = rnd.Next(-5, 10);
                }
            }
            size = new_size;
            array = new_arr;
        }

        public static void Task()
        {
            Random rnd = new Random();
            uint option = 0;
            while (option != 4)
            {
                option = HandleMenu
                (
                    "1. Одномерный массив.\n"
                    + "2. Двумерный массив.\n"
                    + "3. Рваный массив.\n"
                    + "4. Выход."
                );
                switch (option)
                {
                    case 1:
                        int[] array = new int[rnd.Next(3, 5)];
                        uint case1Option = 0;
                        while (case1Option != 4)
                        {
                            case1Option = HandleMenu
                            (
                                "1. Сгенерировать одномерный массив.\n"
                                + "2. Ввести одномерный массив.\n"
                                + "3. Добавить после каждого четного элемента 0.\n"
                                + "4. Назад в меню."
                            );
                            switch (case1Option)
                            {
                                case 1:
                                    FillArray(ref array, rnd);
                                    PrintArray(ref array);
                                    break;
                                case 2:
                                    FillArray(ref array);
                                    PrintArray(ref array);
                                    break;
                                case 3:
                                    AddZeroes(ref array);
                                    PrintArray(ref array);
                                    break;
                                case 4:
                                    break;
                            }
                        }
                        break;
                    case 2:
                        int arrayArraysSize1, arrayArraysSize2;
                        arrayArraysSize1 = arrayArraysSize2 = rnd.Next(3, 6);
                        int[,] arrayArays = new int[arrayArraysSize1, arrayArraysSize2];

                        uint case2Option = 0;
                        while (case2Option != 3)
                        {
                            case2Option = HandleMenu
                            (
                                "1. Сгенерировать двумерный массив.\n"
                                + "2. Удалить строки, в которых есть 0.\n"
                                + "3. Назад в меню.",
                                3
                            );
                            switch (case2Option)
                            {
                                case 1:
                                    FillArray(ref arrayArays, rnd, arrayArraysSize2);
                                    PrintArray(ref arrayArays, arrayArraysSize1, arrayArraysSize2);
                                    break;
                                case 2:
                                    DeleteZeroRows(ref arrayArays, ref arrayArraysSize1);
                                    break;
                                case 3:

                                    break;
                            }
                        }
                        break;
                    case 3:
                        uint case3Option = 0;
                        int reapedArrSize = rnd.Next(3, 6);
                        int[][] reapedArr = new int[reapedArrSize][];

                        while (case3Option != 3)
                        {
                            case3Option = HandleMenu
                            (
                                "1. Сгенерировать рваный массив.\n"
                                + "2. Добавить К строк в конец массива.\n"
                                + "3. Назад в меню.",
                                3
                            );
                            switch (case3Option)
                            {
                                case 1:
                                    FillArray(ref reapedArr, reapedArrSize, rnd);
                                    PrintArray(ref reapedArr, reapedArrSize);
                                    break;
                                case 2:
                                    AddKRows(ref reapedArr, rnd, ref reapedArrSize);
                                    PrintArray(ref reapedArr, reapedArrSize);
                                    break;
                                case 3:
                                    break;
                            }
                        }
                        break;
                    case 4:
                        return;
                }
            }
        }
        static void Main(string[] args)
        {
            Task();
            Console.ReadLine();
        }
    }
}
