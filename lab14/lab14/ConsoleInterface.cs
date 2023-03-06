using lab10;
using TwoDirectionsList;
using System.Collections;

namespace lab14
{
    public class ConsoleInterface
    {
        public void Handle()
        {
            const int listsCount = 3, listsElementsCount = 6, listElementsCount = 10, minRandomNum = 0, maxRandomNum = 3;
            Queue<List<Printing>> lists = new();
            for (int i = 0; i < listsCount; ++i)
            {
                lists.Enqueue(new List<Printing>(listsElementsCount));
                RandomInit(lists.ToArray()[lists.Count - 1], listsElementsCount);
            }
            Console.WriteLine($"Исходные данные ({listsCount} коллекции):");
            foreach (var list in lists)
            {
                foreach (var printing in list)
                {
                    Console.WriteLine(printing);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nРезультат выборки имен всех произведений с ценой до 800:");
            foreach (var printing in LINQSelect(lists))
            {
                Console.WriteLine(printing);
            }
            Console.WriteLine($"\nКоличество произведений типа Book: {ExtensionCount(lists)}");
            Console.WriteLine($"\nОбъединение {listsCount} коллекций:");
            foreach (var printing in LINQUnion(lists))
            {
                Console.WriteLine(printing);
            }
            Console.WriteLine($"\nСуммарное количество страниц всех произведений: {ExtensionAggregate(lists)}");
            Console.WriteLine("\nГруппировка изданий по именам");
            foreach (IGrouping<string, Printing> group in LINQGroup(lists))
            {
                Console.WriteLine(group.Key);
                foreach (var printing in group)
                {
                    Console.WriteLine(" *" + printing);
                }
            }
            TwoDirectionsList<Printing> printings = new TwoDirectionsList<Printing>();
            for (int i = 0; i < listElementsCount; ++i)
            {
                int randomNumber = Rand.random.Next(minRandomNum, maxRandomNum);
                Printing printing = null;
                switch (randomNumber)
                {
                    case 0:
                        printing = new Magazine();
                        break;
                    case 1:
                        printing = new Book();
                        break;
                    case 2:
                        printing = new SchoolBook();
                        break;
                }
                printing?.RandomInit();
                printings.Add(printing);
            }
            Console.WriteLine("\n\n\t\t\tEXTENSIONS\n");
            Console.WriteLine("\nИсходные данные элементов списка:");
            foreach (Printing printing in printings)
            {
                Console.WriteLine(printing);
            }
            Console.WriteLine("\nВыборка названий произведений типа Book со стоимостью менее 850:");
            foreach (var Name in printings.Select(x => x is Book && x.Price < 850, x => x.Name))
            {
                Console.WriteLine(Name);
            }

            int accum = 0;

            Console.WriteLine($"\nСуммарная стоимость произведений в списке: {printings.Aggregate(accum, (x, obj) => x + obj.Price)}");
            Console.WriteLine($"Максимальная стоимость произведения в списке: {printings.Max(x => x.Price)}");
            Console.WriteLine($"Минимальная стоимость произведения в списке: {printings.Min(x => x.Price)}");
            Console.WriteLine($"Средняя стоимость произведения в списке: {printings.Average(x => x.Price)}");
            Console.WriteLine("\nСписок книг, отсортрованных по возрастанию цены:");
            foreach (var printing in printings.OrderByAsc(x => x.Price, (x, y) => x > y ? 1 : x == y ? 0 : -1))
            {
                Console.WriteLine(printing);
            }
            Console.WriteLine("\nСписок книг, отсортрованных по убыванию цены:");
            foreach (var printing in printings.OrderByDesc(x => x.Price, (x, y) => x > y ? 1 : x == y ? 0 : -1))
            {
                Console.WriteLine(printing);
            }
        }
        public IEnumerable LINQSelect(Queue<List<Printing>> lists)
        {
            const int MaxPrice = 800;
            var result = from list in lists
                         from printing in list
                         where printing.Price < MaxPrice
                         select printing.Name;
            return result;
        }
        public IEnumerable ExtensionSelect(Queue<List<Printing>> lists)
        {
            const int MaxPrice = 800;
            return lists.SelectMany(list => list.Where(printing => (printing.Price<MaxPrice)).Select(printing => printing.Name));
        }
        public int LINQCount(Queue<List<Printing>> lists)
        {
            var result = from list in lists
                         from printing in list
                         where printing is Book
                         select printing;
            return result.Count();
        }
        public int ExtensionCount(Queue<List<Printing>> lists)
        {
            return lists.SelectMany(list => list.Where(printing => printing is Book)).Count();
        }
        public IEnumerable LINQUnion(Queue<List<Printing>> lists)
        {
            var result = from list in lists
                         from printing in list
                         select printing;
            return result.Distinct();
        }
        public IEnumerable ExtensionUnion(Queue<List<Printing>> lists)
        {
            var result = lists.SelectMany(list => list);
            return result.Union(result);
        }
        public int LINQAggregate(Queue<List<Printing>> lists)
        {
            var result = from list in lists
                         from printing in list
                         select printing.Pages;
            return result.Sum();
        }
        public int ExtensionAggregate(Queue<List<Printing>> lists)
        {
            int accum = 0;
            return lists.SelectMany(list => list).Aggregate(accum, (acc, x) => acc + x.Pages);
        }
        public IEnumerable LINQGroup(Queue<List<Printing>> lists)
        {
            var result = from list in lists
                         from printing in list
                         group printing by printing.Name;
            return result;
        }
        public IEnumerable ExtensionGroup(Queue<List<Printing>> lists)
        {
            return lists.SelectMany(list => list).GroupBy(printing => printing.Name);
        }
        public void RandomInit(List<Printing> list, int elementsCount)
        {
            for (int i = 0; i < elementsCount; ++i)
            {
                int rnd = Rand.random.Next(0, 3);
                Printing printing = null;
                switch (rnd)
                {
                    case 0:
                        printing = new Magazine();
                        break;
                    case 1:
                        printing = new Book();
                        break;
                    case 2:
                        printing = new SchoolBook();
                        break;
                }
                printing?.RandomInit();
                list.Add(printing);
            }
        }
    }
}
