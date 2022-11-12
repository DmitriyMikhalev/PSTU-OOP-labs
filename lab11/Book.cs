using System;

namespace lab11
{
    public class Book : Printing
    {
        protected string author;
        public Printing BasePrinting
        {
            get
            {
                return new Printing(name, pageCount, releaseYear, price, countInstances);
            }
        }
        public string Author
        {
            get 
            { 
                return author; 
            }
            set 
            { 
                author = value; 
            }
        }
        public Book(in string name, in int pageCount, in int releaseYear, in int price, in int count, in string author)
            : base(name, pageCount, releaseYear, price, count) 
        {
            Author = author;
        }

        public Book()
        { 
            RandomInit(); 
        }
        public override string GetInfo()
        {
            return (
                $"Тип объекта: {GetType().Name}\n" +
                $"Книга: \"{Name}\"\n" +
                $"Автор: {Author}\n" +
                $"Страниц: {Pages}\n" +
                $"Год выпуска: {Year}\n" +
                $"Цена: {Price}\n" +
                $"В наличии: {Count}\n"
            );
        }
        public override void RandomInit()
        {
            string[] authors = {
                "Майн Рид", 
                "Ричард Бах", 
                "Евгений маэстро Понасенков",
                "Федор Достоевский",
                "Эрих-Мария Ремарк",
                "Лев Толстой",
                "Санька Шифер" 
            };

            Name = GetRandomString();
            Author = authors[Rnd.random.Next(authors.Length)];
            Pages = Rnd.random.Next(1500);
            Year = Rnd.random.Next(1704, DateTime.Now.Year);
            Price = Rnd.random.Next(2786);
            Count = Rnd.random.Next(60);
        }
        public override object Clone() => new Book(name, pageCount, releaseYear, price, countInstances, author);
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}