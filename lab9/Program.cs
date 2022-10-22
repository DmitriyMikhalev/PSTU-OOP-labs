using System;

namespace lab9
{
    class Program
    {
        private static Money Min(in MoneyArray array)
        {
            int minIndex = array.Length - 1;
            for (int i = 0; i < array.Length; ++i)
            {
                if (array[i].ToKopecks() < array[minIndex].ToKopecks()) minIndex = i;
            }
            return array[minIndex];
        }
        
        public static void Task1()
        {
            Console.WriteLine("==============================TASK #1==============================");

            Money Mon0 = new Money();
            Console.WriteLine($"\nСоздается объект Mon0, в конструктор ничего не передано\nРезультат: {Mon0.GetInfo()}");

            Money Mon1 = new Money(kopecks: 130); 
            Console.WriteLine($"\nСоздается объект Mon1, в конструктор переданы 130 копеек\nРезультат: {Mon1.GetInfo()}");

            Money Mon2 = new Money(rubles: 2, kopecks: 20);
            Console.WriteLine($"\nСоздается объект Mon2, в конструктор переданы 2 рубля и 20 копеек\nРезультат: {Mon2.GetInfo()}");

            Money Add = Mon1.AddCopecks(55);
            Console.WriteLine($"\nК объекту Mon1 добавляются 55 копеек с помощью метода класса\nТип результата: {Add.GetType()}\nРезультат: {Add.GetInfo()}");

            Add = Money.AddCopecks(Add, 15);
            Console.WriteLine($"\nК объекту Add добавляются 15 копеек с помощью статического метода класса\nТип результата: {Add.GetType()}\nРезультат: {Add.GetInfo()}");

            Console.WriteLine($"\nВсего создано объектов: {Money.Count}\n");
        }
        public static void Task2()
        {
            Console.WriteLine("==============================TASK #2==============================");

            Money Mon0 = new Money(1, 89);
            Console.WriteLine($"\nСоздается объект Mon0, в конструктор переданы 1 рубль и 89 копеек\n\nОсуществляется инкремент\nРезультат: {(++Mon0).GetInfo()}");
            Console.WriteLine($"\nОсуществляется декремент\nРезультат: {(--Mon0).GetInfo()}");

            Console.WriteLine($"\nОсуществляется явное приведение к int\nТип результата: {((int)Mon0).GetType()}\nРезультат: {(int)Mon0}");
            double Mon0Double = Mon0;
            Console.Write($"\nОсуществляется неявное приведение к double\nТип результата: {Mon0Double.GetType()}\nРезультат: "); Console.WriteLine(Mon0);

            Money Mon1 = new Money(1, 10);
            Console.WriteLine($"\nСоздается объект Mon1, в конструктор переданы 1 рубль и 10 копеек");
            Money Mon2 = new Money(2, 30);
            Console.WriteLine($"Создается объект Mon2, в конструктор переданы 2 рубля и 30 копеек");

            Money res = Mon1 + Mon2;
            Console.Write($"\nОсуществляется сложение Mon1 и Mon2\nТип результата: {res.GetType()}\nРезультат: "); Console.WriteLine(res.GetInfo());

            res = Mon2 - Mon1;
            Console.Write($"\nОсуществляется вычитание из Mon2 объекта Mon1\nТип результата: {res.GetType()}\nРезультат: "); Console.WriteLine(res.GetInfo() + "\n");

        }
        public static void Task3()
        {
            Console.WriteLine("==============================TASK #3==============================");

            uint prevCount = Money.Count;

            Console.WriteLine();
            MoneyArray array = new MoneyArray(size: 3);
            Console.WriteLine("\nСоздан массив из 3-и элементов с пользовательским вводом\nРезультат:");
            Interface.Print(array: array);

            array = new MoneyArray(size: 5, random: new Random());
            Console.WriteLine("\nСоздается массив из 5-и элементов с рандомной генерацией\nРезультат:");
            Interface.Print(array: array);

            Console.WriteLine("\nПоиск минимального значения в массиве\nРезультат: ");
            Console.WriteLine(Min(array: array).GetInfo());

            Console.WriteLine("\nОбращение к массиву через индекс 0 на чтение: ");
            Console.WriteLine(array[0].GetInfo());

            Console.WriteLine("\nОбращение к массиву через индекс 0 на запись: ");
            array[0] = new Money();
            Interface.Print(array: array);

            Console.WriteLine($"\nКоличество созданных объектов: {Money.Count - prevCount}");
        }
        static void Main(string[] args)
        {
            try
            {
                Task1();
                Task2();
                Task3();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Исключение! " + ex.Message);
            }
        }
    }
}
