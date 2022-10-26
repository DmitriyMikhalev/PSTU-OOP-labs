using System;

namespace lab10
{
    public class Printing : IRandomInit, IComparable, ICloneable
    {
        protected string _name;
        protected int _pageCount;
        protected int _releaseYear;
        protected int _price;
        protected int _countInstances;

        public virtual void RandomInit()
        {
            Random random = new Random();
            string[] names = { "Мастер Знак", "НеМастер Знак", "Мастер НеЗнак", "НеМастер НеЗнак", "Не Не", "Знак Знак", "Мастер Мастер" };

            _name = names[random.Next(names.Length)];
            _pageCount = random.Next(500);
            _releaseYear = random.Next(1990, DateTime.Now.Year);
            _price = random.Next(1765);
            _countInstances = random.Next(60);
        }
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
        public Printing() { RandomInit(); }
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
        public virtual string GetInfoOverride()
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

        public int CompareTo(object? obj)
        {
            if (obj is Point point) return (_price * _countInstances).CompareTo(point.X * point.Y);
            else if (obj is Printing printing) return (_price * _countInstances).CompareTo(printing.Price * printing.Count);

            throw new ArgumentException("Некорректное сравнение");
        }

        public virtual object Clone() => new Printing(_name, _pageCount, _releaseYear, _price, _countInstances);
        public virtual object ShallowCopy() { return (Printing)this.MemberwiseClone(); }
    }
}
