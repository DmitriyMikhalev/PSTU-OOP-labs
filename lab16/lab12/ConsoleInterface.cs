using TwoDirectionsList;
using lab10;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace lab12
{
    public enum Menu
    {
        Add              = 1,
        Print            = 2,
        SortByName       = 3,
        FilterPrice      = 4,
        SortByPrice      = 5,
        RemoveByIndex    = 6,
        Save             = 7,
        Load             = 8,
        Change           = 9,
        Insert           = 10,
        Clear            = 11,
        Exit             = 12,
    }
    public enum FileTypes
    {
        bin              = 1,
        json             = 2,
        xml              = 3,
    }
    public enum PrintingTypes
    {
        Magazine         = 0,
        Book             = 1,
        SchoolBook       = 2,
    }

    public class ConsoleInterface
    {
        public void HandleMenu()
        {
            TwoDirectionsList<Printing> list = new TwoDirectionsList<Printing>();
            DirectoryInfo directoryInfo = new(Directory.GetCurrentDirectory() + "/data");
            int cmd = 0, minCmd = 1, maxCmd = 12;
            string message = "1. Добавить объект(ы) в коллекцию.\n" +
                             "2. Печать коллекции.\n" +
                             "3. Запрос на сортировку объектов по имени.\n" +
                             "4. Запрос на выборку объектов с ценой больше заданной.\n" +
                             "5. Запрос на сортировку объектов по цене.\n" +
                             "6. Удаление объекта коллекции по индексу.\n" +
                             "7. Сохранить коллекцию.\n" +
                             "8. Загрузить коллекцию.\n" +
                             "9. Поменять объект текущей коллекции.\n" +
                             "10. Вставка объекта в коллекцию по индексу.\n" +
                             "11. Очистить коллекцию.\n" +
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
                            list.Add(obj);
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
                                list.Add(Printing.GetRandomPrinting());
                            }
                            Console.WriteLine($"\nДобавлено элементов: {count}.");
                        }
                        break;

                    case Menu.Print:
                        Console.WriteLine();
                        if (list.Count == 0)
                        {
                            Console.WriteLine("Коллекция пуста, печатать нечего.");
                        }
                        else
                        {
                            foreach (Printing obj in list)
                            {
                                Console.WriteLine(obj);
                            }
                        }
                        break;

                    case Menu.SortByName:
                        if (list.Count == 0)
                        {
                            Console.WriteLine("\nКоллекция пуста, сортировать нечего.");
                        }
                        else
                        {
                            Console.WriteLine("\nКоллекция, сортированная по именам объектов:");
                            foreach(Printing obj in from obj in list orderby obj.Name select obj)
                            {
                                Console.WriteLine(obj);
                            }
                        }
                        break;

                    case Menu.FilterPrice:
                        if (list.Count == 0)
                        {
                            Console.WriteLine("\nКоллекция пуста, фильтровать нечего.");
                        }
                        else
                        {
                            ReadInt(
                                out int price,
                                message: "Цена книги. ",
                                errorMessage: "Цена книги это целое число большее нуля, повторите ввод: ",
                                predicate: x=>x>0 && x<int.MaxValue
                            );
                            Console.WriteLine($"Все объекты коллекции с ценой свыше {price}:");
                            foreach (Printing obj in from obj in list where(obj.Price > price) select obj)
                            {
                                Console.WriteLine(obj);
                            }
                        }
                        break;

                    case Menu.SortByPrice:
                        if (list.Count == 0)
                        {
                            Console.WriteLine("\nКоллекция пуста, сортировать нечего.");
                        }
                        else
                        {
                            Console.WriteLine("\nКоллекция, отсоритрованная по возрастанию цены объектов:");
                            foreach (Printing obj in from obj in list orderby obj.Price select obj)
                            {
                                Console.WriteLine(obj);
                            }
                        }
                        break;

                    case Menu.RemoveByIndex:
                        if (list.Count == 0)
                        {
                            Console.WriteLine("\nКоллекция пуста, удалять нечего.");
                        }
                        else
                        {
                            int oldCount = list.Count;                     
                            ReadInt(
                                out int indexRemove,
                                message: $"\nВведите индекс с 0 по {list.Count - 1}: ",
                                errorMessage: $"Индекс может быть числом с 0 по {list.Count - 1}, повторите ввод: ",
                                predicate: x => x >= 0 && x <= list.Count - 1
                            );
                            list.RemoveAt(indexRemove);
                            if (oldCount != list.Count)
                            {
                                Console.WriteLine("\nОбъект удален.");
                            }
                            else
                            {
                                Console.WriteLine("\nОбъект не удален.");
                            }
                        }
                        break;

                    case Menu.Save:
                        try
                        {
                            if (list.Count < 1)
                            {
                                throw new Exception("\nНельзя сохранить пустую коллекцию.");
                            }
                            ReadInt(
                                out int fileType,
                                message: "\n1. binary.\n2. JSON.\n3. XML.\n\n",
                                errorMessage: "Число должно быть от от 1 до 3, повторите ввод: ",
                                predicate: x => x >= 1 && x <= 3
                            );
                            FileTypes type = (FileTypes)fileType;
                            string filename = "temp_" + DateTime.Now.ToString().Replace(".", "_").Replace(":", "_").Replace(" ", "_") + '.' + type;                            
                            filename = "data/" + filename;
                            Serialize(filename, list, type);
                        }
                        catch(Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                        break;
                    case Menu.Load:
                        try
                        {
                            ReadInt(
                                out int fileType,
                                message: "\n1. binary.\n2. JSON.\n3. XML.\n\n", 
                                errorMessage: "Число должно быть от 1 до 3, повторите ввод: ",
                                predicate: x => x >= 1 && x <= 3
                            );
                            FileTypes type = (FileTypes)fileType;
                            List<string> files = new(
                                from fileInfo in directoryInfo.GetFiles()
                                where fileInfo.Name.Contains($"{type}") 
                                select fileInfo.Name
                            );
                            if (files.Count < 1)
                            {
                                throw new Exception("\nНайдено 0 файлов.");
                            }

                            string userMessage = "";
                            int counter = 1;
                            Console.WriteLine();
                            foreach(var filename in files)
                            {
                                userMessage += $"{counter}. {filename}\n";
                                ++counter;
                            }

                            ReadInt(
                                out int fileNum,
                                message: userMessage + "\n",
                                errorMessage: $"Число должно быть от 1 до {counter}: ",
                                predicate: x => x >= 1 && x <= counter - 1
                            );
                            using FileStream fileStream = new("data/" + files[fileNum - 1], FileMode.Open);
                            switch ((FileTypes)type)
                            {
                                case FileTypes.bin:
                                    BinaryFormatter binaryFormatter = new();
                                    list = (TwoDirectionsList<Printing>)binaryFormatter.Deserialize(fileStream);
                                    break;

                                case FileTypes.json:
                                    List<JsonElement> listJSON = (List<JsonElement>)JsonSerializer.Deserialize(fileStream, typeof(List<JsonElement>));
                                    foreach (var elem in listJSON)
                                    {
                                        string category = "Category";
                                        string cycle = "Cycle";
                                        string author = "Author";
                                        if (elem.TryGetProperty(category, out JsonElement prop))
                                        {
                                            SchoolBook scBook = (SchoolBook)elem.Deserialize(typeof(SchoolBook));
                                            list.Add(scBook);
                                        }
                                        else if (elem.TryGetProperty(author, out prop))
                                        {
                                            Book book = (Book)elem.Deserialize(typeof(Book));
                                            list.Add(book);
                                        }
                                        else if (elem.TryGetProperty(cycle, out prop))
                                        {
                                            Magazine magazine = (Magazine)elem.Deserialize(typeof(Magazine));
                                            list.Add(magazine);
                                        }
                                        else
                                        {
                                            throw new Exception("Неизвестный тип.");
                                        }
                                    }
                                    break;
                                case FileTypes.xml:
                                    XmlSerializer xmlSerializer = new(typeof(TwoDirectionsList<Printing>));
                                    list = (TwoDirectionsList<Printing>)xmlSerializer.Deserialize(fileStream);
                                    break;

                                default:
                                    break;
                            }
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                        break;

                    case Menu.Change:
                        if (list.Count == 0)
                        {
                            Console.WriteLine("\nКоллекция пуста. Менять нечего.");
                        }
                        else
                        {
                            ReadInt(
                                out int indexChange,
                                message: $"\nВведите индекс с 0 по {list.Count - 1}: ",
                                errorMessage: $"Индекс может быть числом с 0 по {list.Count - 1}, повторите ввод: ",
                                predicate: x => x >= 0 && x <= list.Count - 1
                            );
                            ReadInt(
                                out int changeOption,
                                message: "\n1. Ввести новое значение вручную.\n2. Сгенерировать автоматически.\n\n",
                                errorMessage: "Это должно быть число 1 или 2, повторите ввод: ",
                                predicate: x => x >= 1 && x <= 2
                            );
                            if (changeOption == 1)
                            {
                                ReadInt(
                                    out int newValue,
                                    message: "\nВведите новую стоимость: ",
                                    errorMessage: "Стоимость должна быть положительным числом, повторите ввод: ",
                                    predicate: x => x > 0
                                );
                                list[indexChange].Price = newValue;
                            }
                            else
                            {
                                list[indexChange].RandomInit();
                            }
                            Console.WriteLine("\nЗначение изменено.");
                        }
                        break;

                    case Menu.Insert:
                        ReadInt(
                                out int indexInsert,
                                message: $"\nВведите индекс с 0 по {list.Count}: ",
                                errorMessage: $"Индекс может быть числом с 0 по {list.Count}, повторите ввод: ",
                                predicate: x => x >= 0 && x <= list.Count
                        );
                        ReadInt(
                            out int optionInsert,
                            message: "\n1. Ввести новое значение вручную.\n2. Сгенерировать автоматически.\n\n",
                            errorMessage: "Это должно быть число 1 или 2, повторите ввод: ",
                            predicate: x => x >= 1 && x <= 2
                        ); 
                        if (optionInsert == 1)
                        {
                            ReadPrinting(out Printing obj);
                            list.Insert(indexInsert, obj);
                        }
                        else
                        {
                            list.Insert(indexInsert, Printing.GetRandomPrinting());
                        }
                        Console.WriteLine("\nЭлемент вставлен.");
                        break;

                    case Menu.Clear:
                        list.Clear();
                        Console.WriteLine("\nКоллекция очищена.");
                        break;

                    case Menu.Exit:
                        cmd = maxCmd;
                        break;

                    default:
                        break;
                }
                if (cmd != 0 && cmd != maxCmd)
                {
                    Console.WriteLine("\nНажмите любую кнопку для продолжения.");
                    Console.ReadKey();
                    Console.Clear();
                }
                if (cmd != maxCmd)
                {
                    ReadInt(
                        out cmd,
                        message: message,
                        errorMessage: "Некорректное значение, введите число от 1 до 12: ",
                        predicate: x => x >= minCmd && x <= maxCmd
                    );
                }
            }
        }
        public void Serialize(string filename, TwoDirectionsList<Printing> list, FileTypes filetype)
        {
            using FileStream fileStream = new(filename, FileMode.Create);
            switch (filetype)
            {
                case FileTypes.bin:
                    BinaryFormatter binaryFormatter = new();
                    binaryFormatter.Serialize(fileStream, list);
                    break;

                case FileTypes.json:
                    List<object> objs = new(list);
                    var options = new JsonSerializerOptions
                    {
                        Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                        WriteIndented = true
                    };
                    JsonSerializer.Serialize(fileStream, objs, options: options);
                    break;

                case FileTypes.xml:
                    XmlSerializer serializer = new(typeof(TwoDirectionsList<Printing>));
                    serializer.Serialize(fileStream, list);
                    break;

                default:
                    break;
            }
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

