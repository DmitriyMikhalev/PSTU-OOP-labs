using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using lab10;

namespace lab10
{
    [TestClass]
    public class TestMagazineClass
    {
        [TestMethod]
        public void TestConstructorCorrect()
        {
            string expectedName = "test";
            string expectedCycle = "test_cycle";
            int expectedPages = 1;
            int expectedYear = 2020;
            int expectedCount = 17;
            int expectedPrice = 100;

            Magazine obj = new Magazine(
                name: expectedName,
                pageCount: expectedPages,
                releaseYear: expectedYear,
                price: expectedPrice,
                count: expectedCount,
                cycle: expectedCycle
            );

            Assert.AreEqual(expectedName, obj.Name);
            Assert.AreEqual(expectedCycle, obj.Cycle);
            Assert.AreEqual(expectedPages, obj.Pages);
            Assert.AreEqual(expectedYear, obj.Year);
            Assert.AreEqual(expectedCount, obj.Count);

            Assert.IsInstanceOfType(obj, typeof(Printing));
        }

        [TestMethod]
        public void TestConstructorIncorrect()
        {
            string expectedName = "test";
            string expectedCycle = "test_cycle";
            int expectedYear = DateTime.Now.Year;
            int expectedPages = 0;
            int expectedCount = 0;
            int expectedPrice = 0;

            Magazine obj1 = new Magazine(
                name: expectedName,
                pageCount: -1,
                releaseYear: -1,
                price: -1,
                count: -1,
                cycle: expectedCycle
            );
            Magazine obj2 = new Magazine(
                name: expectedName,
                pageCount: -1,
                releaseYear: 2999,
                price: -1,
                count: -1,
                cycle: expectedCycle
            );

            Assert.AreEqual(expectedName, obj1.Name);
            Assert.AreEqual(expectedCycle, obj1.Cycle);
            Assert.AreEqual(expectedPages, obj1.Pages);
            Assert.AreEqual(expectedYear, obj1.Year);
            Assert.AreEqual(expectedCount, obj1.Count);
            Assert.AreEqual(expectedPrice, obj1.Price);

            Assert.AreEqual(expectedYear, obj2.Year);
        }

        [TestMethod]
        public void TestPropertiesSetCorrect()
        {
            Magazine obj = new Magazine("test", 1, 2020, 100, 17, "test_cycle");
            string expectedName = "name";
            string expectedCycle = "cycle";
            int expectedPages = 18;
            int expectedYear = 2020;
            int expectedCount = 3;
            int expectedPrice = 100;

            obj.Name = expectedName;
            obj.Cycle = expectedCycle;
            obj.Pages = expectedPages;
            obj.Year = expectedYear;
            obj.Count = expectedCount;
            obj.Price = expectedPrice;

            Assert.AreEqual(expectedName, obj.Name);
            Assert.AreEqual(expectedCycle, obj.Cycle);
            Assert.AreEqual(expectedPages, obj.Pages);
            Assert.AreEqual(expectedYear, obj.Year);
            Assert.AreEqual(expectedCount, obj.Count);
            Assert.AreEqual(expectedPrice, obj.Price);
        }
        [TestMethod]
        public void TestPropertiesSetIncorrect()
        {
            Magazine obj = new Magazine("test", 1, 2020, 100, 17, "test_cycle");

            int expectedPages = 0;
            obj.Pages = -100;
            Assert.AreEqual(expectedPages, obj.Pages);

            int expectedYear = DateTime.Now.Year;
            obj.Year = 9999;
            Assert.AreEqual(expectedYear, obj.Year);
            obj.Year = -199;
            Assert.AreEqual(expectedYear, obj.Year);

            int expectedPrice = 0;
            obj.Price = -9;
            Assert.AreEqual(expectedPrice, obj.Price);

            int expectedCount = 0;
            obj.Count = -9;
            Assert.AreEqual(expectedCount, obj.Count);
        }

        [TestMethod]
        public void TestGetInfoNotOverride()
        {
            Magazine obj = new Magazine(
                name: "test",
                pageCount: 1,
                releaseYear: 2020,
                price: 100,
                count: 17,
                cycle: "test_cycle"
            );

            string expected = (
                $"Тип объекта: {obj.GetType().Name}\n" +
                $"Название: \"{obj.Name}\"\n" +
                $"Страниц: {obj.Pages}\n" +
                $"Год выпуска: {obj.Year}\n" +
                $"Цена: {obj.Price}\n" +
                $"В наличии: {obj.Count}"
            );

            Assert.AreEqual(expected, obj.GetInfoNotOverride());
        }
        [TestMethod]
        public void TestGetInfoOverride()
        {
            Magazine obj = new Magazine(
                name: "test",
                pageCount: 1,
                releaseYear: 2020,
                price: 100,
                count: 17,
                cycle: "test_cycle"
            );

            string expected = (
                $"Тип объекта: {obj.GetType().Name}\n" +
                $"Журнал: \"{obj.Name}\"\n" +
                $"Цикл: {obj.Cycle}\n" +
                $"Страниц: {obj.Pages}\n" +
                $"Год выпуска: {obj.Year}\n" +
                $"Цена: {obj.Price}\n" +
                $"В наличии: {obj.Count}\n"
           );

            Assert.AreEqual(expected, obj.GetInfoOverride());
        }

    }

    [TestClass]
    public class TestBookClass
    {
        [TestMethod]
        public void TestPropertiesSetCorrect()
        {
            Book obj = new Book(
                name: "test",
                pageCount: 1,
                releaseYear: 2020,
                price: 100,
                count: 17,
                author: "test_author"
            );

            int expectedPrice = 103;
            string expectedAuthor = "smth";
            obj.Price = expectedPrice;
            obj.Author = expectedAuthor;

            Assert.AreEqual(expectedPrice, obj.Price);
            Assert.AreEqual(expectedAuthor, obj.Author);
        }

        [TestMethod]
        public void TestGetInfoNotOverride()
        {
            Book obj = new Book(
                name: "test",
                pageCount: 1,
                releaseYear: 2020,
                price: 100,
                count: 17,
                author: "test_author"
            );

            string expected = (
                $"Тип объекта: {obj.GetType().Name}\n" +
                $"Название: \"{obj.Name}\"\n" +
                $"Страниц: {obj.Pages}\n" +
                $"Год выпуска: {obj.Year}\n" +
                $"Цена: {obj.Price}\n" +
                $"В наличии: {obj.Count}"
            );

            Assert.AreEqual(expected, obj.GetInfoNotOverride());
        }
        [TestMethod]
        public void TestGetInfoOverride()
        {
            Book obj = new Book(
                name: "test",
                pageCount: 1,
                releaseYear: 2020,
                price: 100,
                count: 17,
                author: "test_author"
            );

            string expected = (
                $"Тип объекта: {obj.GetType().Name}\n" +
                $"Книга: \"{obj.Name}\"\n" +
                $"Автор: {obj.Author}\n" +
                $"Страниц: {obj.Pages}\n" +
                $"Год выпуска: {obj.Year}\n" +
                $"Цена: {obj.Price}\n" +
                $"В наличии: {obj.Count}\n"
            );

            Assert.AreEqual(expected, obj.GetInfoOverride());
        }
    }

    [TestClass]
    public class TestSchoolBookClass
    {
        [TestMethod]
        public void TestConstructorIncorrect()
        {
            int expectedCategory = 11;
            SchoolBook obj1 = new SchoolBook(
                name: "test",
                pageCount: 1,
                releaseYear: 2020,
                price: 100,
                count: 17,
                author: "test_author",
                categoryClass: -1
            );
            SchoolBook obj2 = new SchoolBook(
                name: "test",
                pageCount: 1,
                releaseYear: 2020,
                price: 100,
                count: 17,
                author: "test_author",
                categoryClass: 12
            );

            Assert.AreEqual(expectedCategory, obj1.Category);
            Assert.AreEqual(expectedCategory, obj2.Category);
        }
        [TestMethod]
        public void TestPropertiesSetCorrect()
        {
            SchoolBook obj = new SchoolBook(
                name: "test",
                pageCount: 1,
                releaseYear: 2020,
                price: 100,
                count: 17,
                author: "test_author",
                categoryClass: 11
            );
            int expectedCategory = 9;
            obj.Category = expectedCategory;
          
            Assert.AreEqual(expectedCategory, obj.Category);
        }
        [TestMethod]
        public void TestPropertiesSetIncorrect()
        {
            SchoolBook obj = new SchoolBook(
                name: "test",
                pageCount: 1,
                releaseYear: 2020,
                price: 100,
                count: 17,
                author: "test_author",
                categoryClass: 11
            );

            int expectedCategory = 11;
            obj.Category = -8;
            Assert.AreEqual(expectedCategory, obj.Category);

            expectedCategory = 11;
            obj.Category = 12;
            Assert.AreEqual(expectedCategory, obj.Category);
        }
        [TestMethod]
        public void TestGetInfoNotOverride()
        {
            SchoolBook obj = new SchoolBook(
                name: "test",
                pageCount: 1,
                releaseYear: 2020,
                price: 100,
                count: 17,
                author: "test_author",
                categoryClass: 11
            );

            string expected = (
                 $"Тип объекта: {obj.GetType().Name}\n" +
                 $"Название: \"{obj.Name}\"\n" +
                 $"Страниц: {obj.Pages}\n" +
                 $"Год выпуска: {obj.Year}\n" +
                 $"Цена: {obj.Price}\n" +
                 $"В наличии: {obj.Count}"
             );

            Assert.AreEqual(expected, obj.GetInfoNotOverride());
        }
        [TestMethod]
        public void TestGetInfoOverride()
        {
            SchoolBook obj = new SchoolBook(
                name: "test",
                pageCount: 1,
                releaseYear: 2020,
                price: 100,
                count: 17,
                author: "test_author",
                categoryClass: 11
            );

            string expected = (
                $"Тип объекта: {obj.GetType().Name}\n" +
                $"Учебник: \"{obj.Name}\"\n" +
                $"Класс обучения: {obj.Category}\n" +
                $"Автор: {obj.Author}\n" +
                $"Страниц: {obj.Pages}\n" +
                $"Год выпуска: {obj.Year}\n" +
                $"Цена: {obj.Price}\n" +
                $"В наличии: {obj.Count}\n"
            );

            Assert.AreEqual(expected, obj.GetInfoOverride());
        }
    }
    [TestClass]
    public class TestProgramClass
    {
        [TestMethod]
        public void TestGetSumItems()
        {
            int expectedSum = 40768;
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

            Printing[] array = { schoolBook1, schoolBook2, schoolBook3, schoolBook4, schoolBook5 };

            Assert.AreEqual(expectedSum, Program.GetSumItems(array, "ЕГЭ информатика 2022"));
        }
        [TestMethod]
        public void TestGetInfoPrintings()
        {
            string expected = (
                "Тип объекта: SchoolBook\n" +
                "Учебник: \"Физика\"\n" +
                "Класс обучения: 10" +
                "\nАвтор: Александр Перышкин\n" +
                "Страниц: 378\n" +
                "Год выпуска: 2019\n" +
                "Цена: 316\n" +
                "В наличии: 37\n\n" +
                "Тип объекта: SchoolBook\n" +
                "Учебник: \"История Руси\"\n" +
                "Класс обучения: 7" +
                "\nАвтор: Евгений Ромзен\n" +
                "Страниц: 270\n" +
                "Год выпуска: 2012\n" +
                "Цена: 344\n" +
                "В наличии: 85\n\n"
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
            SchoolBook schoolBook1 = new SchoolBook(
                name: "Физика",
                pageCount: 378,
                releaseYear: 2019,
                price: 316,
                author: "Александр Перышкин",
                categoryClass: 10,
                count: 37
            );
            Printing[] array = { schoolBook1, schoolBook2 };

            Assert.AreEqual(expected, Program.GetInfoPrintings(array));
        }
        [TestMethod]
        public void TestGetCountSchoolBooks()
        {
            int expectedCount = 5;
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

            Printing[] array = { schoolBook1, schoolBook2, schoolBook3, schoolBook4, schoolBook5 };

            Assert.AreEqual(expectedCount, Program.GetCountSchoolBooks(array));
        }

        [TestMethod]
        public void TestGetInfoBooksQuery()
        {
            Book obj1 = new Book(
                name: "test",
                pageCount: 1,
                releaseYear: 2020,
                price: 100,
                count: 17,
                author: "test_author"
            );
            string expected = "* \"" + obj1.Name + $"\" ({obj1.Year}), " + obj1.Author + "\n";

            Book obj2 = new Book(
                name: "dfgdfg",
                pageCount: 1,
                releaseYear: 2000,
                price: 100,
                count: 17,
                author: "test_asd"
            );

            Printing[] array = { obj1, obj2 };

            Assert.AreEqual(expected, Program.GetInfoBooksQuery(array, 2001));
        }

        [TestMethod]
        public void TestTask1()
        {
            string expected = (
                "=======================TASK 1=======================\n\n" +
                "БЕЗ ИСПОЛЬЗОВАНИЯ ВИРТУАЛЬНЫХ МЕТОДОВ:\n\n" +
                "Тип объекта: Magazine\nНазвание: \"Forbes\"\n" +
                "Страниц: 23\nГод выпуска: 2022\n" +
                "Цена: 600\nВ наличии: 94\n\n" +
                "Тип объекта: Book\nНазвание: \"Мастер и Маргарита\"\n" +
                "Страниц: 414\nГод выпуска: 1928\n" +
                "Цена: 971\nВ наличии: 15\n\n" +
                "Тип объекта: SchoolBook\nНазвание: \"Физика\"\n" +
                "Страниц: 378\nГод выпуска: 2019\n" +
                "Цена: 316\nВ наличии: 37\n\n" +
                "С ИСПОЛЬЗОВАНИЕМ ВИРТУАЛЬНЫХ МЕТОДОВ:\n\n" + 
                "Тип объекта: Magazine\nЖурнал: \"Forbes\"\n" + 
                "Цикл: финансы\nСтраниц: 23\n" +
                "Год выпуска: 2022\nЦена: 600\n" +
                "В наличии: 94\n\nТип объекта: Book\n"+
                "Книга: \"Мастер и Маргарита\"\nАвтор: Михаил Булгаков\n" +
                "Страниц: 414\nГод выпуска: 1928\n" +
                "Цена: 971\nВ наличии: 15\n\n" +
                "Тип объекта: SchoolBook\nУчебник: \"Физика\"\n" +
                "Класс обучения: 10\nАвтор: Александр Перышкин\n" +
                "Страниц: 378\nГод выпуска: 2019\n" +
                "Цена: 316\nВ наличии: 37\n\n" +
                "Как видно из результата работы программы, виртуальные методы нужны для изменения логики работы метода. Таким образом, " +
                "в случае использования обычного метода будет вызван метод базового класса для каждого объекта производного класса, " +
                "что приведет к \"обработке\" только общей (базовой) части объектов. Если пробовать создать такой же метод в классе-наследнике, " +
                "компилятор выдаст предупреждение о том, что ВСЕГДА будет использован метод именно базового класса с такой же сигнатурой."
            );

            Assert.AreEqual(expected, Program.Task1());
        }
    }   

}
