

namespace lab13
{
    public class ConsoleInterface
    {
        public void Handle()
        {
            MyNewCollection firstCollection = new MyNewCollection();
            MyNewCollection secondCollection = new MyNewCollection();
            firstCollection.Name = "Первая";
            secondCollection.Name = "Вторая";

            Journal firstJournal = new Journal();
            Journal secondJournal = new Journal();

            firstCollection.CollectionCountChanged += firstJournal.CollectionCountChanged;
            firstCollection.CollectionReferenceChanged += firstJournal.CollectionReferenceChanged;
            firstCollection.CollectionReferenceChanged += secondJournal.CollectionReferenceChanged;
            secondCollection.CollectionReferenceChanged += secondJournal.CollectionReferenceChanged;

            firstCollection.Add(new Magazine("Бульварное чтиво", 50, 2013, 400, 16234, "Чтиво"));
            firstCollection.Add(new Book("Роман", 550, 2022, 1000, 403, "Офицерский Сэндвич"));
            firstCollection.Add(new SchoolBook("Maths", 50, 2007, 100, 10000, "Вася Ситуация" , 39));
            firstCollection[0] = new Printing("Чтиво 2", 17, 2018, 120, 9767);
            firstCollection.RemoveAt(0);

            secondCollection.Add(new Magazine("Бульварное чтиво", 50, 2013, 400, 16234, "Чтиво"));
            secondCollection.Add(new Book("Роман", 550, 2022, 1000, 403, "Офицерский Сэндвич"));
            secondCollection.Add(new SchoolBook("Maths", 50, 2007, 100, 10000, "Вася Ситуация", 39));
            secondCollection[0] = new Printing("Чтиво 2", 4, 2018, 120, 14);
            secondCollection[1] = new Printing("Чтиво 3", 6, 2012, 129, 176);

            Console.WriteLine("Записи 1 журнала:");
            foreach (JournalEntry entry in firstJournal.journal)
            {
                Console.WriteLine(entry);
            }

            Console.WriteLine();

            Console.WriteLine("Записи 2 журнала:");
            foreach (JournalEntry entry in secondJournal.journal)
            {
                Console.WriteLine(entry);
            }
        }
    }
}
