using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using lab11;
using System;

namespace TestProject1
{
    [TestClass]
    public class TestTestCollections
    {
        [TestMethod]
        public void TestLinkedListPrinting()
        {
            TestCollections collections = new TestCollections();
            Printing p1 = new Printing("1", 1, 2022, 1, 1);
            Printing p2 = new Printing("2", 2, 2022, 2, 2);
            Printing p3 = new Printing("3", 3, 2022, 3, 3);
            collections.fcPrinting.AddLast(p1);
            collections.fcPrinting.AddLast(p2);
            collections.fcPrinting.AddLast(p3);
            bool found;
            Program.GetTimeList(collections.fcPrinting, (Printing)collections.fcPrinting.First.Value.Clone(), out found);
            Assert.AreEqual(true, found);

            Program.GetTimeList(collections.fcPrinting, (Printing)p2.Clone(), out found);
            Assert.AreEqual(true, found);

            Program.GetTimeList(collections.fcPrinting, (Printing)collections.fcPrinting.Last.Value.Clone(), out found);
            Assert.AreEqual(true, found);
            
            Program.GetTimeList(collections.fcPrinting, new Printing("x", 0, 2022, 0, 0), out found);
            Assert.AreEqual(false, found);
        }
        [TestMethod]
        public void TestLinkedListString()
        {
            TestCollections collections = new TestCollections();
            Printing p1 = new Printing("1", 1, 2022, 1, 1);
            Printing p2 = new Printing("2", 2, 2022, 2, 2);
            Printing p3 = new Printing("3", 3, 2022, 3, 3);
            collections.fcString.AddLast(p1.ToString());
            collections.fcString.AddLast(p2.ToString());
            collections.fcString.AddLast(p3.ToString());
            bool found;

            Program.GetTimeList(collections.fcString, (string)collections.fcString.First.Value.Clone(), out found);
            Assert.AreEqual(true, found);

            Program.GetTimeList(collections.fcString, p2.Clone().ToString(), out found);
            Assert.AreEqual(true, found);

            Program.GetTimeList(collections.fcString, (string)collections.fcString.Last.Value.Clone(), out found);
            Assert.AreEqual(true, found);

            Program.GetTimeList(collections.fcString, "x", out found);
            Assert.AreEqual(false, found);
        }
        [TestMethod]
        public void TestSortedDictionaryPrintingBook()
        {
            TestCollections collections = new TestCollections();
            Book b1 = new Book("1", 1, 2022, 1, 1, "1");
            Book b2 = new Book("2", 2, 2022, 2, 2, "2");
            Book b3 = new Book("3", 3, 2022, 3, 3, "3");
            collections.scPrintingBook.Add(b1.BasePrinting, b1);
            collections.scPrintingBook.Add(b2.BasePrinting, b2);
            collections.scPrintingBook.Add(b3.BasePrinting, b3);
            List<Printing> keys = new List<Printing>(collections.scPrintingBook.Keys);
            bool found;

            Program.GetTimeDictionaryKey(collections.scPrintingBook, (Printing)keys[0].Clone(), out found);
            Assert.AreEqual(true, found);

            Program.GetTimeDictionaryKey(collections.scPrintingBook, (Printing)keys[1].Clone(), out found);
            Assert.AreEqual(true, found);

            Program.GetTimeDictionaryKey(collections.scPrintingBook, (Printing)keys[2].Clone(), out found);
            Assert.AreEqual(true, found);

            Program.GetTimeDictionaryKey(collections.scPrintingBook, new Printing("x", 0, 2022, 0, 0), out found);
            Assert.AreEqual(false, found);
        }
        [TestMethod]
        public void TestSortedDictionaryStringBookKey()
        {
            TestCollections collections = new TestCollections();
            Book b1 = new Book("3", 1, 2022, 1, 1, "1");
            Book b2 = new Book("2", 2, 2022, 2, 2, "2");
            Book b3 = new Book("1", 3, 2022, 3, 3, "3");
            collections.scStringBook.Add(b1.ToString(), b1);
            collections.scStringBook.Add(b2.ToString(), b2);
            collections.scStringBook.Add(b3.ToString(), b3);
            bool found;

            Program.GetTimeDictionaryKey(collections.scStringBook, b1.Clone().ToString(), out found);
            Assert.AreEqual(true, found);

            Program.GetTimeDictionaryKey(collections.scStringBook, b2.Clone().ToString(), out found);
            Assert.AreEqual(true, found);

            Program.GetTimeDictionaryKey(collections.scStringBook, b3.Clone().ToString(), out found);
            Assert.AreEqual(true, found);

            Program.GetTimeDictionaryKey(collections.scStringBook, "x", out found);
            Assert.AreEqual(false, found);
        }
        [TestMethod]
        public void TestSortedDictionaryStringBookValue()
        {
            TestCollections collections = new TestCollections();
            Book b1 = new Book("3", 1, 2022, 1, 1, "1");
            Book b2 = new Book("2", 2, 2022, 2, 2, "2");
            Book b3 = new Book("1", 3, 2022, 3, 3, "3");
            collections.scStringBook.Add(b1.ToString(), b1);
            collections.scStringBook.Add(b2.ToString(), b2);
            collections.scStringBook.Add(b3.ToString(), b3);
            bool found;

            Program.GetTimeDictionaryValue(collections.scStringBook, (Book)b1.Clone(), out found);
            Assert.AreEqual(true, found);

            Program.GetTimeDictionaryValue(collections.scStringBook, (Book)b2.Clone(), out found);
            Assert.AreEqual(true, found);

            Program.GetTimeDictionaryValue(collections.scStringBook, (Book)b3.Clone(), out found);
            Assert.AreEqual(true, found);

            Program.GetTimeDictionaryValue(collections.scStringBook, new Book("a", 1, 2022, 1, 1, "1"), out found);
            Assert.AreEqual(false, found);
        }
    }
}
