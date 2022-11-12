using System.Collections.Generic;
using System;

namespace lab11
{
    class TestCollections
    {
        public LinkedList<string> fcString;
        public LinkedList<Printing> fcPrinting;
        public SortedDictionary<Printing, Book> scPrintingBook;
        public SortedDictionary<string, Book> scStringBook;
        public TestCollections()
        {
            fcString = new LinkedList<string>();
            fcPrinting = new LinkedList<Printing>();
            scPrintingBook = new SortedDictionary<Printing, Book>(new Comparer());
            scStringBook = new SortedDictionary<string, Book>();
        }
        public void RandomInit(in int countObjects)
        {
            Book book = null;
            for (int i = 0; i < countObjects; ++i)
            {
                book = new Book();
                fcString.AddLast(book.ToString());
                fcPrinting.AddLast(book.BasePrinting);
                scPrintingBook.Add(book.BasePrinting, book);
                scStringBook.Add(book.ToString(), book);
            }
        }
    }
}