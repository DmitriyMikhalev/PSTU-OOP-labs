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
                $"Òèï îáúåêòà: {obj.GetType().Name}\n" +
                $"Íàçâàíèå: \"{obj.Name}\"\n" +
                $"Ñòðàíèö: {obj.Pages}\n" +
                $"Ãîä âûïóñêà: {obj.Year}\n" +
                $"Öåíà: {obj.Price}\n" +
                $"Â íàëè÷èè: {obj.Count}"
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
                $"Òèï îáúåêòà: {obj.GetType().Name}\n" +
                $"Æóðíàë: \"{obj.Name}\"\n" +
                $"Öèêë: {obj.Cycle}\n" +
                $"Ñòðàíèö: {obj.Pages}\n" +
                $"Ãîä âûïóñêà: {obj.Year}\n" +
                $"Öåíà: {obj.Price}\n" +
                $"Â íàëè÷èè: {obj.Count}\n"
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
                $"Òèï îáúåêòà: {obj.GetType().Name}\n" +
                $"Íàçâàíèå: \"{obj.Name}\"\n" +
                $"Ñòðàíèö: {obj.Pages}\n" +
                $"Ãîä âûïóñêà: {obj.Year}\n" +
                $"Öåíà: {obj.Price}\n" +
                $"Â íàëè÷èè: {obj.Count}"
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
                $"Òèï îáúåêòà: {obj.GetType().Name}\n" +
                $"Êíèãà: \"{obj.Name}\"\n" +
                $"Àâòîð: {obj.Author}\n" +
                $"Ñòðàíèö: {obj.Pages}\n" +
                $"Ãîä âûïóñêà: {obj.Year}\n" +
                $"Öåíà: {obj.Price}\n" +
                $"Â íàëè÷èè: {obj.Count}\n"
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
                 $"Òèï îáúåêòà: {obj.GetType().Name}\n" +
                 $"Íàçâàíèå: \"{obj.Name}\"\n" +
                 $"Ñòðàíèö: {obj.Pages}\n" +
                 $"Ãîä âûïóñêà: {obj.Year}\n" +
                 $"Öåíà: {obj.Price}\n" +
                 $"Â íàëè÷èè: {obj.Count}"
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
                $"Òèï îáúåêòà: {obj.GetType().Name}\n" +
                $"Ó÷åáíèê: \"{obj.Name}\"\n" +
                $"Êëàññ îáó÷åíèÿ: {obj.Category}\n" +
                $"Àâòîð: {obj.Author}\n" +
                $"Ñòðàíèö: {obj.Pages}\n" +
                $"Ãîä âûïóñêà: {obj.Year}\n" +
                $"Öåíà: {obj.Price}\n" +
                $"Â íàëè÷èè: {obj.Count}\n"
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
                name: "Ôèçèêà",
                pageCount: 378,
                releaseYear: 2019,
                price: 316,
                author: "Àëåêñàíäð Ïåðûøêèí",
                categoryClass: 10,
                count: 37
            );
            SchoolBook schoolBook2 = new SchoolBook(
                name: "Èñòîðèÿ Ðóñè",
                pageCount: 270,
                releaseYear: 2012,
                price: 344,
                author: "Åâãåíèé Ðîìçåí",
                categoryClass: 7,
                count: 85
            );
            SchoolBook schoolBook3 = new SchoolBook(
                name: "ÅÃÝ èíôîðìàòèêà 2022",
                pageCount: 129,
                releaseYear: 2022,
                price: 364,
                author: "ÔÃÎÑ",
                categoryClass: 11,
                count: 112
            );
            SchoolBook schoolBook4 = new SchoolBook(
                name: "ÅÃÝ ðóññêèé ÿçûê 2022",
                pageCount: 190,
                releaseYear: 2022,
                price: 290,
                author: "ÔÃÎÑ",
                categoryClass: 11,
                count: 19
            );
            SchoolBook schoolBook5 = new SchoolBook(
                name: "Èñòîðèÿ Ðóñè",
                pageCount: 270,
                releaseYear: 2012,
                price: 344,
                author: "Åâãåíèé Ðîìçåí",
                categoryClass: 7,
                count: 85
            );

            Printing[] array = { schoolBook1, schoolBook2, schoolBook3, schoolBook4, schoolBook5 };

            Assert.AreEqual(expectedSum, Program.GetSumItems(array, "ÅÃÝ èíôîðìàòèêà 2022"));
        }
        [TestMethod]
        public void TestGetInfoPrintings()
        {
            string expected = (
                "Òèï îáúåêòà: SchoolBook\n" +
                "Ó÷åáíèê: \"Ôèçèêà\"\n" +
                "Êëàññ îáó÷åíèÿ: 10" +
                "\nÀâòîð: Àëåêñàíäð Ïåðûøêèí\n" +
                "Ñòðàíèö: 378\n" +
                "Ãîä âûïóñêà: 2019\n" +
                "Öåíà: 316\n" +
                "Â íàëè÷èè: 37\n\n" +
                "Òèï îáúåêòà: SchoolBook\n" +
                "Ó÷åáíèê: \"Èñòîðèÿ Ðóñè\"\n" +
                "Êëàññ îáó÷åíèÿ: 7" +
                "\nÀâòîð: Åâãåíèé Ðîìçåí\n" +
                "Ñòðàíèö: 270\n" +
                "Ãîä âûïóñêà: 2012\n" +
                "Öåíà: 344\n" +
                "Â íàëè÷èè: 85\n\n"
            );
            SchoolBook schoolBook2 = new SchoolBook(
                name: "Èñòîðèÿ Ðóñè",
                pageCount: 270,
                releaseYear: 2012,
                price: 344,
                author: "Åâãåíèé Ðîìçåí",
                categoryClass: 7,
                count: 85
            );
            SchoolBook schoolBook1 = new SchoolBook(
                name: "Ôèçèêà",
                pageCount: 378,
                releaseYear: 2019,
                price: 316,
                author: "Àëåêñàíäð Ïåðûøêèí",
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
                name: "Ôèçèêà",
                pageCount: 378,
                releaseYear: 2019,
                price: 316,
                author: "Àëåêñàíäð Ïåðûøêèí",
                categoryClass: 10,
                count: 37
            );
            SchoolBook schoolBook2 = new SchoolBook(
                name: "Èñòîðèÿ Ðóñè",
                pageCount: 270,
                releaseYear: 2012,
                price: 344,
                author: "Åâãåíèé Ðîìçåí",
                categoryClass: 7,
                count: 85
            );
            SchoolBook schoolBook3 = new SchoolBook(
                name: "ÅÃÝ èíôîðìàòèêà 2022",
                pageCount: 129,
                releaseYear: 2022,
                price: 364,
                author: "ÔÃÎÑ",
                categoryClass: 11,
                count: 112
            );
            SchoolBook schoolBook4 = new SchoolBook(
                name: "ÅÃÝ ðóññêèé ÿçûê 2022",
                pageCount: 190,
                releaseYear: 2022,
                price: 290,
                author: "ÔÃÎÑ",
                categoryClass: 11,
                count: 19
            );
            SchoolBook schoolBook5 = new SchoolBook(
                name: "Èñòîðèÿ Ðóñè",
                pageCount: 270,
                releaseYear: 2012,
                price: 344,
                author: "Åâãåíèé Ðîìçåí",
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
                "ÁÅÇ ÈÑÏÎËÜÇÎÂÀÍÈß ÂÈÐÒÓÀËÜÍÛÕ ÌÅÒÎÄÎÂ:\n\n" +
                "Òèï îáúåêòà: Magazine\nÍàçâàíèå: \"Forbes\"\n" +
                "Ñòðàíèö: 23\nÃîä âûïóñêà: 2022\n" +
                "Öåíà: 600\nÂ íàëè÷èè: 94\n\n" +
                "Òèï îáúåêòà: Book\nÍàçâàíèå: \"Ìàñòåð è Ìàðãàðèòà\"\n" +
                "Ñòðàíèö: 414\nÃîä âûïóñêà: 1928\n" +
                "Öåíà: 971\nÂ íàëè÷èè: 15\n\n" +
                "Òèï îáúåêòà: SchoolBook\nÍàçâàíèå: \"Ôèçèêà\"\n" +
                "Ñòðàíèö: 378\nÃîä âûïóñêà: 2019\n" +
                "Öåíà: 316\nÂ íàëè÷èè: 37\n\n" +
                "Ñ ÈÑÏÎËÜÇÎÂÀÍÈÅÌ ÂÈÐÒÓÀËÜÍÛÕ ÌÅÒÎÄÎÂ:\n\n" + 
                "Òèï îáúåêòà: Magazine\nÆóðíàë: \"Forbes\"\n" + 
                "Öèêë: ôèíàíñû\nÑòðàíèö: 23\n" +
                "Ãîä âûïóñêà: 2022\nÖåíà: 600\n" +
                "Â íàëè÷èè: 94\n\nÒèï îáúåêòà: Book\n"+
                "Êíèãà: \"Ìàñòåð è Ìàðãàðèòà\"\nÀâòîð: Ìèõàèë Áóëãàêîâ\n" +
                "Ñòðàíèö: 414\nÃîä âûïóñêà: 1928\n" +
                "Öåíà: 971\nÂ íàëè÷èè: 15\n\n" +
                "Òèï îáúåêòà: SchoolBook\nÓ÷åáíèê: \"Ôèçèêà\"\n" +
                "Êëàññ îáó÷åíèÿ: 10\nÀâòîð: Àëåêñàíäð Ïåðûøêèí\n" +
                "Ñòðàíèö: 378\nÃîä âûïóñêà: 2019\n" +
                "Öåíà: 316\nÂ íàëè÷èè: 37\n\n" +
                "Êàê âèäíî èç ðåçóëüòàòà ðàáîòû ïðîãðàììû, âèðòóàëüíûå ìåòîäû íóæíû äëÿ èçìåíåíèÿ ëîãèêè ðàáîòû ìåòîäà. Òàêèì îáðàçîì, " +
                "â ñëó÷àå èñïîëüçîâàíèÿ îáû÷íîãî ìåòîäà áóäåò âûçâàí ìåòîä áàçîâîãî êëàññà äëÿ êàæäîãî îáúåêòà ïðîèçâîäíîãî êëàññà, " +
                "÷òî ïðèâåäåò ê \"îáðàáîòêå\" òîëüêî îáùåé (áàçîâîé) ÷àñòè îáúåêòîâ. Åñëè ïðîáîâàòü ñîçäàòü òàêîé æå ìåòîä â êëàññå-íàñëåäíèêå, " +
                "êîìïèëÿòîð âûäàñò ïðåäóïðåæäåíèå î òîì, ÷òî ÂÑÅÃÄÀ áóäåò èñïîëüçîâàí ìåòîä èìåííî áàçîâîãî êëàññà ñ òàêîé æå ñèãíàòóðîé."
            );

            Assert.AreEqual(expected, Program.Task1());
        }
    }   
}
