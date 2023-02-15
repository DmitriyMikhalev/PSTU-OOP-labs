using TwoDirectionsList;
using lab10;

namespace lab12
{
    public enum Menu
    {
        Add              = 1,
        Print            = 2,
        ActivateOriginal = 3,
        ActivateClone    = 4,
        ActivateCopy     = 5,
        RemoveByIndex    = 6,
        CloneCurrent     = 7,
        CopyCurrent      = 8,
        ChangeValue      = 9,
        Insert           = 10,
        Clear            = 11,
        Exit             = 12,
    }
    public enum CollectionTypes
    { 
        Original        = 0,
        Clone           = 1,
        Copy            = 2,
    }
    public enum PrintingTypes
    {
        Magazine        = 0,
        Book            = 1,
        SchoolBook      = 2,
    }

    public class ConsoleInterface
    {
        public void HandleMenu()
        {
            TwoDirectionsList<Printing> originalCollection = new TwoDirectionsList<Printing>();
            TwoDirectionsList<Printing> activeCollection = originalCollection;
            TwoDirectionsList<Printing>? cloneCollection = null;
            TwoDirectionsList<Printing>? copyCollection = null;

            int cmd = 0, minCmd = 1, maxCmd = 12;
            int collectionType = 0;
            string message = "1. Добавить элемент(ы) в коллекцию.\n" +
                             "2. Печать коллекции.\n" +
                             "3. Активировать коллекцию-оригинал.\n" +
                             "4. Активировать коллекцию-клон.\n" +
                             "5. Активировать коллекцию-копию (поверхностную).\n" +
                             "6. Удаление элемента коллекции по индексу.\n" +
                             "7. Создать (перезаписать) клон коллекции.\n" +
                             "8. Создать (перезаписать) поверхностную копию коллекции.\n" +
                             "9. Поменять элемент текущей коллекции.\n" +
                             "10. Вставка в коллекцию по индексу.\n" +
                             "11. Очистить текущую коллекцию.\n" +
                             "12. Выход.\n\n";

            while (cmd != maxCmd)
            {
                switch ((Menu)cmd)
                {
                    case Menu.Add:
                        ReadInt(
                            out int optionAdd,
                            message: "\n1. Добавить вручную.\n2. Добавить автоматически.\n\n",
                            errorMessage: "Это должно быть число 1 или 2, повторите ввод: ",
                            predicate: x => x >= 1 && x <= 2
                        );
                        if (optionAdd == 1)
                        {
                            ReadPrinting(out Printing obj);
                            activeCollection.Add(obj);
                            Console.WriteLine("\nЭлемент добавлен.");
                        }
                        else
                        {
                            ReadInt(
                                out int count,
                                message: "\nКоличество элементов для добавления. ",
                                errorMessage: "Количество элементов должно быть числом с 1 по 30, повторите ввод: ",
                                predicate: x => x >= 1 && x <= 30
                            );
                            for (int i = 0; i < count; ++i)
                            {
                                activeCollection.Add(GetRandomPrinting());
                            }
                            Console.WriteLine($"\nДобавлено элементов: {count}.");
                        }
                        break;

                    case Menu.Print:
                        Console.WriteLine();
                        if (activeCollection.Count > 0)
                        {
                            foreach (Printing printing in activeCollection)
                            {
                                Console.WriteLine(printing);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Коллекция пустая.");
                        }
                        break;

                    case Menu.ActivateOriginal:
                        activeCollection = originalCollection;
                        collectionType = (int)CollectionTypes.Original;
                        Console.WriteLine("\nАктивна коллекция-оригинал.");
                        break;

                    case Menu.ActivateClone:
                        if (cloneCollection is not null)
                        {
                            activeCollection = cloneCollection;
                            collectionType=1;
                            Console.WriteLine("\nАктивна коллекция-клон.");
                        }
                        else
                            Console.WriteLine("\nКлонирование не было выполнено прежде.");
                        break;

                    case Menu.ActivateCopy:
                        if (copyCollection is not null)
                        {
                            activeCollection = copyCollection;
                            collectionType = (int)CollectionTypes.Copy;
                            Console.WriteLine("\nАктивна коллекция-копия (поверхностная).");
                        }
                        else
                        {
                            Console.WriteLine("\nПоверхностное копирование не было выполнено прежде.");
                        }
                        break;

                    case Menu.RemoveByIndex:
                        if (activeCollection.Count == 0)
                        {
                            Console.WriteLine("\nКоллекция пуста, удалять нечего.");
                            break;
                        }
                        int oldCount = activeCollection.Count;                     
                        ReadInt(
                            out int index,
                            message: $"\nВведите индекс с 0 по {activeCollection.Count - 1}: ",
                            errorMessage: $"Индекс может быть числом с 0 по {activeCollection.Count - 1}, повторите ввод: ",
                            predicate: x => x >= 0 && x <= activeCollection.Count - 1
                        );
                        activeCollection.RemoveAt(index);
                        if (oldCount != activeCollection.Count)
                        {
                            Console.WriteLine("\nЭлемент удален.");
                        }
                        else
                        {
                            Console.WriteLine("\nЭлемент не был удален.");
                        }
                        break;

                    case Menu.CloneCurrent:
                        cloneCollection = new TwoDirectionsList<Printing>(activeCollection, true);
                        Console.WriteLine("\nТекущая коллекция клонирована.");
                        break;
                    case Menu.CopyCurrent:
                        copyCollection = new TwoDirectionsList<Printing>(activeCollection, false);
                        Console.WriteLine("\nТекущая коллекция cкопирована.");
                        break;

                    case Menu.ChangeValue:
                        if (activeCollection.Count == 0)
                        {
                            Console.WriteLine("\nКоллекция пуста. Менять нечего.");
                            break;
                        }
                        ReadInt(
                            out int index2,
                            message: $"\nВведите индекс с 0 по {activeCollection.Count - 1}: ",
                            errorMessage: $"Индекс может быть числом с 0 по {activeCollection.Count - 1}, повторите ввод: ",
                            predicate: x => x >= 0 && x <= activeCollection.Count - 1
                        );
                        ReadInt(
                            out int com,
                            message: "\n1. Ввести новое значение вручную.\n2. Сгенерировать автоматически.\n\n",
                            errorMessage: "Это должно быть число 1 или 2, повторите ввод: ",
                            predicate: x => x >= 1 && x <= 2
                        );
                        if (com == 1)
                        {
                            ReadInt(
                                out int newValue,
                                message: "\nВведите новую стоимость: ",
                                errorMessage: "Стоимость должна быть положительным числом, повторите ввод: ",
                                predicate: x => x > 0
                            );
                            activeCollection[index2].Price = newValue;
                        }
                        else
                        {
                            activeCollection[index2].RandomInit();
                        }
                        Console.WriteLine("\nЗначение изменено.");
                        break;

                    case Menu.Insert:
                        if (activeCollection.Count == 0)
                        {
                            Console.WriteLine("\nКоллекция пуста, индексов нет.");
                            break;
                        }
                        ReadInt(
                                out int index3,
                                message: $"\nВведите индекс с 0 по {activeCollection.Count - 1}: ",
                                errorMessage: $"Индекс может быть числом с 0 по {activeCollection.Count - 1}, повторите ввод: ",
                                predicate: x => x >= 0 && x <= activeCollection.Count - 1
                        );
                        ReadInt(
                            out int optionInsert,
                            message: "\n1. Ввести новое значение вручную.\n2. Сгенерировать автоматически.\n\n",
                            errorMessage: "Это должно быть число 1 или 2, повторите ввод: ",
                            predicate: x => x >= 1 && x <= 2
                        );
                        if (optionInsert == 1)
                        {
                            ReadPrinting(out Printing val);
                            activeCollection.Insert(index3, val);
                        }
                        else
                        {
                            activeCollection.Insert(index3, GetRandomPrinting());
                        }
                        Console.WriteLine("\nЭлемент вставлен.");
                        break;

                    case Menu.Clear:
                        activeCollection.Clear();
                        Console.WriteLine("\nКоллекция очищена.");
                        break;

                    case Menu.Exit:
                        optionAdd = maxCmd;
                        break;

                    default:
                        break;
                }
                if (cmd != 0 && cmd != maxCmd)
                {
                    Console.WriteLine("Нажмите любую кнопку для продолжения.");
                    Console.ReadKey();
                    Console.Clear();
                }
                if (cmd != maxCmd)
                {
                    Console.Write("Активна коллекция-");
                    switch ((CollectionTypes)collectionType)
                    {
                        case CollectionTypes.Original:
                            Console.WriteLine("оригинал.\n");
                            break;
                        case CollectionTypes.Clone:
                            Console.WriteLine("клон.\n");
                            break;
                        case CollectionTypes.Copy:
                            Console.WriteLine("копия.\n");
                            break;
                        default:
                            break;
                    }

                    ReadInt(
                        out cmd,
                        message: message,
                        errorMessage: "Некорректное значение, введите число от 1 до 12: ",
                        predicate: x => x >= minCmd && x <= maxCmd
                    );
                }
            }
        }
        public Printing GetRandomPrinting()
        {
            int type = Rand.random.Next(0, 3);
            Printing printing = null;
            switch ((PrintingTypes)type)
            {
                case PrintingTypes.Magazine:
                    printing = new Magazine();
                    break;
                case PrintingTypes.Book:
                    printing = new Book();
                    break;
                case PrintingTypes.SchoolBook:
                    printing = new SchoolBook(); 
                    break;
                default:
                    break;
            }
            printing.RandomInit();

            return printing;
        }
        protected void ReadInt(out int value, string message, string errorMessage, Predicate<int> predicate)
        {
            bool tryAgain = false; 
            Console.Write(message + "Введите число: ");
            do
            {
                if (tryAgain)
                {
                    Console.Write(errorMessage);
                }
                if (Int32.TryParse(Console.ReadLine(), out value) && predicate(value))
                {
                    break;
                }
                tryAgain = true;
            } while (true);
        }
        protected void ReadPrinting(out Printing obj)
        {
            obj = new Printing();
            string message = "\n1. Magazine\n2. Book\n3. SchoolBook\n\n";
            ReadInt(
                out int value,
                message: message,
                errorMessage: "Число должно быть с 1 по 3, повторите ввод: ",
                predicate: x => x >= 1 && x <= 3
            );

            switch ((PrintingTypes)value)
            {
                case PrintingTypes.Magazine:
                    obj = new Magazine();
                    break;
                case PrintingTypes.Book:
                    obj = new Book();
                    break;
                case PrintingTypes.SchoolBook:
                    obj = new SchoolBook();
                    break;
                default:
                    break;
            }

            Console.Write("\nВведите название произведения: ");
            obj.Name = Console.ReadLine() ?? "Book default";
            
            ReadInt(
                out value,
                message: "Количество страниц в произведении. ",
                errorMessage: "Количество страниц должно быть положительным числом, повторите ввод: ",
                x => x >= 1
            );
            obj.Pages = value;

            ReadInt(
                out value,
                message: "Год издания произведения. ",
                errorMessage: "Год издания должен быть положительным числом с 1700 года по текущий год, повторите ввод: ",
                x => x > 1700 && x <= DateTime.Now.Year
            );
            obj.Year = value;

            ReadInt(
                out value,
                message: "Цена произведения. ",
                errorMessage: "Цена произведения должна быть положительным числом, повторите ввод: ",
                predicate: x => x >= 1
            );
            obj.Price = value;

            ReadInt(
                out value,
                message: "Количество произведений в наличии. ",
                errorMessage: "Количество произведений \"в наличии\" должно быть положительным числом, повторите ввод: ",
                predicate: x => x >= 1
            );
            obj.Count = value;

            if (obj is Magazine magazine)
            {
                Console.Write("Цикл журнала: ");
                magazine.Cycle = Console.ReadLine() ?? "Default cycle";
            }
            if (obj is Book book)
            {
                Console.Write("Автор книги: ");
                book.Author = Console.ReadLine() ?? "Default author";
            }
            if (obj is SchoolBook schoolBook)
            {
                Console.Write("Автор учебника: ");
                schoolBook.Author = Console.ReadLine() ?? "Default author";
                ReadInt(
                    out value,
                    message: "Категория (класс) учебника. ",
                    errorMessage: "Категория учебника должна быть положительным числом с 1 по 11, повторите ввод: ",
                    x => x >= 1 && x <= 11
                );
                schoolBook.Category = value;
            }
        }
    }
}

