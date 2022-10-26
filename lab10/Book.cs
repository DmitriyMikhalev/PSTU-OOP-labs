using System;

namespace lab10
{
    public class Book : Printing
    {
        protected string _author;
        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }
        public Book(in string name, in int pageCount, in int releaseYear, in int price, in int count, in string author)
            : base(name, pageCount, releaseYear, price, count) { _author = author; }

        public Book() { RandomInit(); }
        public override string GetInfoOverride()
        {
            return (
                $"Тип объекта: {GetType().Name}\n" +
                $"Книга: \"{_name}\"\n" +
                $"Автор: {_author}\n" +
                $"Страниц: {_pageCount}\n" +
                $"Год выпуска: {_releaseYear}\n" +
                $"Цена: {_price}\n" +
                $"В наличии: {_countInstances}\n"
            );
        }
        public override void RandomInit()
        {
            Random random = new Random();
            string[] names = { "Мастер и Маргарита", "Война и мир", "80 дней вокруг света", "Тропа войны", "Жизнь взаймы", "Всадник без головы", "Первая научная история войны 1812 года" };
            string[] authors = { "Майн Рид", "Ричард Бах", "Евгений маэстро Понасенков", "Федор Достоевский", "Эрих-Мария Ремарк", "Лев Толстой", "Санька Шифер" };

            _name = names[random.Next(names.Length)];
            _author = authors[random.Next(authors.Length)];
            _pageCount = random.Next(1500);
            _releaseYear = random.Next(1704, DateTime.Now.Year);
            _price = random.Next(2786);
            _countInstances = random.Next(60);
        }
        public override object Clone() => new Book(_name, _pageCount, _releaseYear, _price, _countInstances, _author);
        public override object ShallowCopy() { return (Book)this.MemberwiseClone(); }
    }
}
