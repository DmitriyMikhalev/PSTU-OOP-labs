using System;
using System.Linq;

namespace lab10
{
    public abstract class Printing
    {
        protected string _name;
        protected int _pageCount;
        protected int _releaseYear;
        protected int _price;
        protected int _countInstances;

        public int Count
        {
            get { return _countInstances; }
            set 
            {
                if (value > 0) _countInstances = value;
                else _countInstances = 0;
            }
        }
        public int Price
        {
            get { return _price; }
            set 
            {
                if (value >= 0) _price = value;
                else _price = 0;
            }
        }
        public string Name 
        { 
            get { return _name; }
            set { _name = value; }
        }
        public int Pages
        {
            get { return _pageCount; }
            set 
            {
                if (value > 0) _pageCount = value;
                else _pageCount = 0;
            }
        }
        public int Year
        {
            get { return _releaseYear; }
            set 
            {
                if (value > 1700 && value < DateTime.Now.Year) _releaseYear = value;
                else _releaseYear = DateTime.Now.Year;
            }
        }
        public Printing(in string name, in int pageCount, in int releaseYear, in int price, in int count)
        {
            _name = name;

            if (pageCount >= 0) _pageCount = pageCount;
            else _pageCount = 0;

            if (releaseYear <= DateTime.Now.Year && releaseYear >= 1700) _releaseYear = releaseYear;
            else _releaseYear = DateTime.Now.Year;

            if (price >= 0) _price = price;
            else _price = 0;

            if (count >= 0) _countInstances = count;
            else _countInstances = 0;
        }
        public string GetInfoNotOverride()
        {
            return (
                $"Тип объекта: {GetType().Name}\n" +
                $"Название: \"{_name}\"\n" +
                $"Страниц: {_pageCount}\n" +
                $"Год выпуска: {_releaseYear}\n" +
                $"Цена: {_price}\n" +
                $"В наличии: {_countInstances}"
            );
        }
        public abstract string GetInfoOverride();
    }

    public class Magazine : Printing
    {
        private string _cycle;

        public string Cycle 
        {
            get { return _cycle; }
            set { _cycle = value; }
        }
        public Magazine(in string name, in int pageCount, in int releaseYear, in int price, in int count, in string cycle)
            : base(name, pageCount, releaseYear, price, count) { _cycle = cycle; }
        public override string GetInfoOverride()
        {
            return (
                $"Тип объекта: {GetType().Name}\n" +
                $"Журнал: \"{_name}\"\n" +
                $"Цикл: {_cycle}\n" +
                $"Страниц: {_pageCount}\n" +
                $"Год выпуска: {_releaseYear}\n" +
                $"Цена: {_price}\n" +
                $"В наличии: {_countInstances}\n"
           );
        }
    }

    public class Book : Printing
    {
        protected string _author;
        public string Author 
        {
            get { return _author; }
            set { _author = value; } 
        }
        public Book(in string name, in int pageCount, in int releaseYear, in int price, in int count, in string author)
            : base(name, pageCount, releaseYear, price, count) { _author = author; }
        public override string GetInfoOverride()
        {
            return (
                $"Тип объекта: {GetType().Name}\n" +
                $"Книга: \"{_name}\"\n" +
                $"Автор: {_author}\n" +
                $"Страниц: {_pageCount}\n" +
                $"Год выпуска: {_releaseYear}\n" +
                $"Цена: {_price}\n" +
                $"В наличии: {_countInstances}\n"
            );
        }
    }

    public class SchoolBook : Book
    {
        private int _categoryClass;
        public int Category
        {
            get { return _categoryClass; }
            set 
            {
                if (value >= 1 && value <= 11) _categoryClass = value;
                else _categoryClass = 11;
            }
        }
        public SchoolBook(in string name, in int pageCount, in int releaseYear, in int price, in int count, in string author, in int categoryClass)
            : base(name, pageCount, releaseYear, price, count, author)
        {
            if (categoryClass >= 1 && categoryClass <= 11) _categoryClass = categoryClass;
            else _categoryClass = 11;
        }
        public override string GetInfoOverride()
        {
             return (
                $"Тип объекта: {GetType().Name}\n" +
                $"Учебник: \"{_name}\"\n" +
                $"Класс обучения: {_categoryClass}\n" +
                $"Автор: {_author}\n" +
                $"Страниц: {_pageCount}\n" +
                $"Год выпуска: {_releaseYear}\n" +
                $"Цена: {_price}\n" +
                $"В наличии: {_countInstances}\n"
            );
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
        }
        static void Task2()
        {
            Console.WriteLine("\n=======================TASK 2=======================\n");

            Magazine magazine1 = new Magazine(
                name: "Forbes",
                pageCount: 23,
                releaseYear: 2022,
                price: 600,
                cycle: "финансы",
                count: 94
            );
            Magazine magazine2 = new Magazine(
                name: "Космополитан",
                pageCount: 17,
                releaseYear: 2022,
                price: 400,
                cycle: "мода",
                count: 36
            );


            Book book1 = new Book(
                name: "Мастер и Маргарита",
                pageCount: 414,
                releaseYear: 1928,
                price: 971,
                author: "Михаил Булгаков",
                count: 15
            );
            Book book2 = new Book(
                name: "Война и мир",
                pageCount: 1274,
                releaseYear: 1863,
                price: 990,
                author: "Лев Толстой",
                count: 30
            );
            Book book3 = new Book(
                name: "Чайка по имени Джонатан Ливингстон",
                pageCount: 96,
                releaseYear: 1970,
                price: 301,
                author: "Ричард Бах",
                count: 5
            );
            Book book4 = new Book(
                name: "Первая научная история войны 1812 года",
                pageCount: 1940,
                releaseYear: 2017,
                price: 779,
                author: "Евгений Понасенков",
                count: 24
            );


            SchoolBook schoolBook1 = new SchoolBook(
                name: "Физика",
                pageCount: 378,
                releaseYear: 2019,
                price: 316,
                author: "Александр Перышкин",
                categoryClass: 10,
                count: 37
            );
            SchoolBook schoolBook2 = new SchoolBook(
                name: "История Руси",
                pageCount: 270,
                releaseYear: 2012,
                price: 344,
                author: "Евгений Ромзен",
                categoryClass: 7,
                count: 85
            );
            SchoolBook schoolBook3 = new SchoolBook(
                name: "ЕГЭ информатика 2022",
                pageCount: 129,
                releaseYear: 2022,
                price: 364,
                author: "ФГОС",
                categoryClass: 11,
                count: 112
            );
            SchoolBook schoolBook4 = new SchoolBook(
                name: "ЕГЭ русский язык 2022",
                pageCount: 190,
                releaseYear: 2022,
                price: 290,
                author: "ФГОС",
                categoryClass: 11,
                count: 19
            );
            SchoolBook schoolBook5 = new SchoolBook(
                name: "История Руси",
                pageCount: 270,
                releaseYear: 2012,
                price: 344,
                author: "Евгений Ромзен",
                categoryClass: 7,
                count: 85
            );

        

            Printing[] array = { magazine1, book1, schoolBook1, magazine2, book3, schoolBook2, schoolBook3, schoolBook4, book4, schoolBook5, book2 };
            Console.WriteLine("В наличии всего " + GetCountSchoolBooks(array) + " учебников.\n");
            Console.Write(GetInfoPrintings(array));
            GetInfoBooksQuery(array);
            Console.WriteLine("Общая сумма имеющейся в наличии выбранной литературы: " + GetSumItems(array, null));
        }

        public static int GetSumItems(in Printing[] array, in string value = "ЕГЭ информатика 2022")
        {
            //string[] validItems = new string[] { };
            //foreach (var obj in array) { validItems = validItems.Append(obj.Name).ToArray(); }
            var validItems = from obj in array select obj.Name;

            Console.WriteLine("\nПозиции в наличии:\n");
            foreach (var item in validItems) { Console.WriteLine("* " + item); }
            Console.WriteLine();

            string result = value;
            if (result == null)
            {
                do
                {
                    Console.Write("Введите название товара, общую стоимость которого необходимо высчитать: ");
                    result = Console.ReadLine();
                } while (!validItems.Contains(result));
                Console.WriteLine();
            }

            int sum = 0;
            foreach (var obj in array)
            {
                if (obj.Name == result) sum += obj.Count * obj.Price;
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
        static void GetInfoBooksQuery(in Printing[] array)
        {
            int year = InputYear();
            Console.WriteLine($"\nРезультат поиска по книгам с датой публикации не ранее {year}:\n");

            foreach (var obj in array)
            {
                if (obj.GetType().Name == "Book" && obj.Year >= year)
                {
                    Book objBook = obj as Book;
                    Console.WriteLine("* \"" + objBook.Name + $"\" ({objBook.Year}), " + objBook.Author);
                }
            }
        }
        public static int GetCountSchoolBooks(in Printing[] array)
        {
            int count = 0;
            foreach (var obj in array) { if (obj is SchoolBook) ++count; }

            return count;
        }
        static void Task1() 
        {
            Console.WriteLine("=======================TASK 1=======================");

            Magazine magazine = new Magazine(
                name: "Forbes",
                pageCount: 23,
                releaseYear: 2022,
                price: 600,
                cycle: "финансы",
                count: 94
            );

            Book book = new Book(
                name: "Мастер и Маргарита",
                pageCount: 414,
                releaseYear: 1928,
                price: 971,
                author: "Михаил Булгаков",
                count: 15
            );

            SchoolBook schoolBook = new SchoolBook(
                name: "Физика",
                pageCount: 378,
                releaseYear: 2019,
                price: 316,
                author: "Александр Перышкин",
                categoryClass: 10,
                count: 37
            );

            Printing[] array = { magazine, book, schoolBook };

            Console.WriteLine("\nБЕЗ ИСПОЛЬЗОВАНИЯ ВИРТУАЛЬНЫХ МЕТОДОВ:\n");
            foreach (var obj in array) 
            { 
                Console.WriteLine(obj.GetInfoNotOverride() + "\n");
            }

            Console.WriteLine("С ИСПОЛЬЗОВАНИЕМ ВИРТУАЛЬНЫХ МЕТОДОВ:\n");
            foreach (var obj in array) { Console.WriteLine(obj.GetInfoOverride()); }

            Console.WriteLine(
                "Как видно из результата работы программы, виртуальные методы нужны для изменения логики работы метода. Таким образом, " +
                "в случае использования обычного метода будет вызван\nметод базового класса для каждого объекта производного класса, " +
                "что приведет к \"обработке\" только общей (базовой) части объектов. Если пробовать создать такой же метод в\nклассе-наследнике, " +
                "компилятор выдаст предупреждение о том, что ВСЕГДА будет использован метод именно базового класса с такой же сигнатурой."
            );
        }
    }
}
