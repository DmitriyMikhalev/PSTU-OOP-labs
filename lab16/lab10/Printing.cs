using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

public enum PrintingTypes
{
    Magazine = 0,
    Book = 1,
    SchoolBook = 2,
}

namespace lab10
{
    [Serializable]
    [XmlInclude(typeof(Book))]
    [XmlInclude(typeof(Magazine))]
    public class Printing : IRandomInit, IComparable, ICloneable
    {
        protected string name;
        protected int pageCount;
        protected int releaseYear;
        protected int price;
        protected int countInstances;

        public virtual void RandomInit()
        {
            Random random = Rand.random;
            string[] names = { "Мастер Знак", "НеМастер Знак", "Мастер НеЗнак", "НеМастер НеЗнак", "Не Не", "Знак Знак", "Мастер Мастер" };

            name = names[random.Next(names.Length)];
            pageCount = random.Next(500);
            releaseYear = random.Next(1990, DateTime.Now.Year);
            price = random.Next(1765);
            countInstances = random.Next(60);
        }
        [JsonInclude]
        [XmlAttribute]
        public int Count
        {
            get { return countInstances; }
            set
            {
                if (value > 0) countInstances = value;
                else countInstances = 0;
            }
        }
        [JsonInclude]
        [XmlAttribute]
        public int Price
        {
            get { return price; }
            set
            {
                if (value >= 0) price = value;
                else price = 0;
            }
        }
        [JsonInclude]
        [XmlAttribute]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [JsonInclude]
        [XmlAttribute]
        public int Pages
        {
            get { return pageCount; }
            set
            {
                if (value > 0) pageCount = value;
                else pageCount = 0;
            }
        }
        [JsonInclude]
        [XmlAttribute]
        public int Year
        {
            get { return releaseYear; }
            set
            {
                if (value > 1700 && value < DateTime.Now.Year) releaseYear = value;
                else releaseYear = DateTime.Now.Year;
            }
        }
        public Printing(in string name, in int pageCount, in int releaseYear, in int price, in int count)
        {
            this.name = name;

            if (pageCount >= 0) this.pageCount = pageCount;
            else this.pageCount = 0;

            if (releaseYear <= DateTime.Now.Year && releaseYear >= 1700) this.releaseYear = releaseYear;
            else this.releaseYear = DateTime.Now.Year;

            if (price >= 0) this.price = price;
            else this.price = 0;

            if (count >= 0) countInstances = count;
            else countInstances = 0;
        }
        public Printing() { RandomInit(); } 
        public override string ToString()
        {
            return (
                $"Тип объекта: {GetType().Name} " +
                $"Название: {name} " +
                $"Страниц: {pageCount} " +
                $"Год выпуска: {releaseYear} " +
                $"Цена: {price} " +
                $"В наличии: {countInstances} "
            );
        }

        public int CompareTo(object? obj)
        {
            if (obj is Point point) return (price * countInstances).CompareTo(point.X * point.Y);
            else if (obj is Printing printing) return (price * countInstances).CompareTo(printing.Price * printing.Count);

            throw new ArgumentException("Некорректное сравнение");
        }
        public override bool Equals(object? obj)
        {
            bool flag = false;
            if (obj is Printing printing)
            {
                flag = name == printing.name && 
                       pageCount == printing.pageCount &&
                       releaseYear == printing.releaseYear &&
                       price == printing.price &&
                       countInstances == printing.countInstances &&
                       GetType() == printing.GetType();
            }
            return flag;
        }
        public virtual object Clone() => new Printing(name, pageCount, releaseYear, price, countInstances);
        public virtual object ShallowCopy() { return (Printing)this.MemberwiseClone(); }
        public static Printing GetRandomPrinting()
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
    }
}
