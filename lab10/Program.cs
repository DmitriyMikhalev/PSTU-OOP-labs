using System;
using System.Linq;

namespace lab10
{
    interface IRandomInit
    {
        void RandomInit();
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Task1());
            Task2();
            Task3();
        }
        public static void Task3()
        {
            Console.WriteLine("\n=======================TASK 3=======================\n");

            int valuePoint, valueBook, valueSchoolBook, valueMagazine, valuePrinting;
            IRandomInit[] array = { new Point(), new Book(), new SchoolBook(), new Magazine() };
            foreach (var obj in array)
            {
                obj.RandomInit();
                Console.WriteLine($"Генерируется объект класса {obj.GetType().Name} с помощью ДСЧ (RandomInit):");

                if (obj is Point objPoint)
                {
                    Console.WriteLine($"x = {objPoint.X}, y = {objPoint.Y}\n");
                    valuePoint = objPoint.X + objPoint.Y;
                }
                else if (obj is Printing printingg)
                {
                    Console.WriteLine(printingg.GetInfoOverride());
                    valuePrinting = printingg.Count * printingg.Price;
                }
                else if (obj is Magazine magazine)
                {
                    Console.WriteLine(magazine.GetInfoOverride());
                    valueMagazine = magazine.Count * magazine.Price;
                }
                else if (obj is Book book)
                {
                    Console.WriteLine(book.GetInfoOverride());
                    valueBook = book.Count * book.Price;
                }
                else if (obj is SchoolBook schoolBook)
                {
                    Console.WriteLine(schoolBook.GetInfoOverride());
                    valueSchoolBook = schoolBook.Count * schoolBook.Price;
                }

            }

            Console.WriteLine("\nПосле сортировки массива (по возрастанию; сравнивается сумма координат, суммарная стоимость; IComparable):\n");
            Array.Sort(array);
            foreach (var obj in array) Console.WriteLine(obj);

            Console.WriteLine("\n==========================================\n");

            Printing[] arrayPrinting = { new Book(), new SchoolBook(), new Magazine() };
            foreach (var obj in arrayPrinting) Console.WriteLine($"Создан объект {obj.GetType().Name}:\n" + obj.GetInfoOverride());

            Console.WriteLine("\nПосле сортировки массива (по возрастанию имени) с помощью IComparer:\n");
            Array.Sort(arrayPrinting, new SortByName());
            foreach (var obj in arrayPrinting) Console.WriteLine(obj.GetInfoOverride());


            Console.WriteLine("\n==========================================\n");

            Printing printing = new Printing();
            Printing printingShallow = (Printing)printing.ShallowCopy();
            Printing printingDeep = (Printing)printing.Clone();

            Console.WriteLine($"Создан объект {printing.GetType().Name}:\n" + printing.GetInfoOverride());
            Console.WriteLine($"\nСоздана копия поверхностным копированием:\n" + printingShallow.GetInfoOverride());
            Console.WriteLine($"\nСоздана копия глубоким копированием:\n" + printingDeep.GetInfoOverride());

            Console.WriteLine("\nМеняются имена у обеих копий на testShallow и testDeep\n");
            printingShallow.Name = "testShallow";
            printingDeep.Name = "testDeep";

            Console.WriteLine("Исходный объект после смены имени у копий:\n" + printing.GetInfoOverride());
            Console.WriteLine("\nИзмененные объекты:\n" + printingShallow.GetInfoOverride() + "\n\n" + printingDeep.GetInfoOverride());
            Console.WriteLine("\nВ данном случае оба копирования сработали корректно, так как атрибуты не содержат подссылки на другие объекты.");
            Console.WriteLine("\n==========================================\n");
        }
        public static void Task2()
        {
            Console.WriteLine("\n=======================TASK 2=======================\n");

            Magazine magazine1 = new Magazine(name: "Forbes", pageCount: 23, releaseYear: 2022, price: 600, cycle: "финансы", count: 94);
            Magazine magazine2 = new Magazine(name: "Космополитан", pageCount: 17, releaseYear: 2022, price: 400, cycle: "мода", count: 36);

            Book book1 = new Book(name: "Мастер и Маргарита", pageCount: 414, releaseYear: 1928, price: 971, author: "Михаил Булгаков", count: 15);
            Book book2 = new Book(name: "Война и мир", pageCount: 1274, releaseYear: 1863, price: 990, author: "Лев Толстой", count: 30);
            Book book3 = new Book(name: "Чайка по имени Джонатан Ливингстон", pageCount: 96, releaseYear: 1970, price: 301, author: "Ричард Бах", count: 5);
            Book book4 = new Book(name: "Первая научная история войны 1812 года", pageCount: 1940, releaseYear: 2017, price: 779, author: "Евгений Понасенков", count: 24);

            SchoolBook schoolBook1 = new SchoolBook(name: "Физика", pageCount: 378, releaseYear: 2019, price: 316, author: "Александр Перышкин", categoryClass: 10, count: 37);
            SchoolBook schoolBook2 = new SchoolBook(name: "История Руси", pageCount: 270, releaseYear: 2012, price: 344, author: "Евгений Ромзен", categoryClass: 7, count: 85);
            SchoolBook schoolBook3 = new SchoolBook(name: "ЕГЭ информатика 2022", pageCount: 129, releaseYear: 2022, price: 364, author: "ФГОС", categoryClass: 11, count: 112);
            SchoolBook schoolBook4 = new SchoolBook(name: "ЕГЭ русский язык 2022", pageCount: 190, releaseYear: 2022, price: 290, author: "ФГОС", categoryClass: 11, count: 19);
            SchoolBook schoolBook5 = new SchoolBook(name: "История Руси", pageCount: 270, releaseYear: 2012, price: 344, author: "Евгений Ромзен", categoryClass: 7, count: 85);

            Printing[] array = { magazine1, book1, schoolBook1, magazine2, book3, schoolBook2, schoolBook3, schoolBook4, book4, schoolBook5, book2 };
            Console.WriteLine("В наличии всего " + GetCountSchoolBooks(array) + " учебников.");
            Console.WriteLine("\n==========================================\n");
            Console.Write(GetInfoPrintings(array));
            Console.WriteLine("\n==========================================\n");
            Console.WriteLine(GetInfoBooksQuery(array, InputYear()));
            Console.WriteLine("Общая сумма имеющейся в наличии выбранной литературы: " + GetSumItems(array, InputBookName(array)));
        }
        public static string Task1()
        {
            string result = "=======================TASK 1=======================\n";

            Magazine magazine = new Magazine(name: "Forbes", pageCount: 23, releaseYear: 2022, price: 600, cycle: "финансы", count: 94);
            Book book = new Book(name: "Мастер и Маргарита", pageCount: 414, releaseYear: 1928, price: 971, author: "Михаил Булгаков", count: 15);
            SchoolBook schoolBook = new SchoolBook(name: "Физика", pageCount: 378, releaseYear: 2019, price: 316, author: "Александр Перышкин", categoryClass: 10, count: 37);

            Printing[] array = { magazine, book, schoolBook };

            result += "\nБЕЗ ИСПОЛЬЗОВАНИЯ ВИРТУАЛЬНЫХ МЕТОДОВ:\n\n";
            foreach (var obj in array) { result += obj.GetInfoNotOverride() + "\n\n"; }

            result += "С ИСПОЛЬЗОВАНИЕМ ВИРТУАЛЬНЫХ МЕТОДОВ:\n\n";
            foreach (var obj in array) { result += obj.GetInfoOverride() + "\n"; }

            result += (
                "Как видно из результата работы программы, виртуальные методы нужны для изменения логики работы метода. Таким образом, " +
                "в случае использования обычного метода будет вызван метод базового класса для каждого объекта производного класса, " +
                "что приведет к \"обработке\" только общей (базовой) части объектов. Если пробовать создать такой же метод в классе-наследнике, " +
                "компилятор выдаст предупреждение о том, что ВСЕГДА будет использован метод именно базового класса с такой же сигнатурой."
            );

            return result;
        }
        public static int GetSumItems(in Printing[] array, in string value)
        {
            int sum = 0;
            foreach (var obj in array)
            {
                if (obj.Name == value) sum += obj.Count * obj.Price;
            }

            return sum;
        }
        public static string GetInfoPrintings(in Printing[] array)
        {
            string result ="";
            foreach (var obj in array) 
            { 
                result += obj.GetInfoOverride();
                result += "\n";
            }
            return result;
        }
        static int InputYear()
        {
            bool parsed = false;
            int result = 0;
            do
            {
                Console.Write("Введите год: ");
                try
                {
                    result = Int32.Parse(Console.ReadLine());
                    parsed = true;
                }
                catch (FormatException) { Console.WriteLine("Некорректный символ, повторите ввод."); }
                catch (OverflowException) { Console.WriteLine("Некорректное значение, повторите ввод в нужном диапазоне."); }

                if (parsed)
                {
                    if (result >= 1700 && result <= DateTime.Now.Year) break;

                    else if (result > DateTime.Now.Year)
                    {
                        Console.WriteLine("Год не может быть больше текущего.");
                        parsed = false;
                    }
                    else
                    {
                        Console.WriteLine("Год не может быть меньше 1700.");
                        parsed = false;
                    }
                }
            } while (!parsed);

            return result;
        }
        public static string InputBookName(in Printing[] array)
        {
            //string[] validItems = new string[] { };
            //foreach (var obj in array) { validItems = validItems.Append(obj.Name).ToArray(); }
            var validItems = from obj in array select obj.Name;

            Console.WriteLine("\nПозиции в наличии:\n");
            foreach (var item in validItems) { Console.WriteLine("* " + item); }
            Console.WriteLine();

            string result;
            do
            {
                Console.Write("Введите название товара, общую стоимость которого необходимо высчитать: ");
                result = Console.ReadLine();
            } while (!validItems.Contains(result));
            Console.WriteLine();

            return result;
        }
        public static string GetInfoBooksQuery(in Printing[] array, in int year)
        {
            Console.WriteLine($"\nРезультат поиска по книгам с датой публикации не ранее {year}:\n");
            string result = "";
            foreach (var obj in array)
            {
                if (obj.GetType().Name == "Book" && obj.Year >= year)
                {
                    Book objBook = obj as Book;
                    result += $"* \"{objBook.Name}\" ({objBook.Year}), {objBook.Author}\n";
                }
            }
            return result;
        }
        public static int GetCountSchoolBooks(in Printing[] array)
        {
            int count = 0;
            foreach (var obj in array) { if (obj is SchoolBook) ++count; }

            return count;
        }
    }
}
