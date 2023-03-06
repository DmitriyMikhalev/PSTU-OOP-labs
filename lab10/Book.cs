using System;

namespace lab10
{
    public class Book : Printing
    {
        protected string author;
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public Book(in string name, in int pageCount, in int releaseYear, in int price, in int count, in string author)
            : base(name, pageCount, releaseYear, price, count) { this.author = author; }

        public Book() { RandomInit(); }
        public override string ToString()
        {
            return (
                $"Тип объекта: {GetType().Name} " +
                $"Книга: {name} " +
                $"Автор: {author} " +
                $"Страниц: {pageCount} " +
                $"Год выпуска: {releaseYear} " +
                $"Цена: {price} " +
                $"В наличии: {countInstances} "
            );
        }
        public override void RandomInit()
        {
            Random random = Rand.random;
            string[] names = { "Мастер и Маргарита", "Война и мир", "80 дней вокруг света", "Тропа войны", "Жизнь взаймы", "Всадник без головы", "Первая научная история войны 1812 года" };
            string[] authors = { "Майн Рид", "Ричард Бах", "Евгений маэстро Понасенков", "Федор Достоевский", "Эрих-Мария Ремарк", "Лев Толстой", "Санька Шифер" };

            name = names[random.Next(names.Length)];
            author = authors[random.Next(authors.Length)];
            pageCount = random.Next(1500);
            releaseYear = random.Next(1704, DateTime.Now.Year);
            price = random.Next(2786);
            countInstances = random.Next(60);
        }
        public override object Clone() => new Book(name, pageCount, releaseYear, price, countInstances, author);
        public override object ShallowCopy() { return (Book)this.MemberwiseClone(); }
    }
}
