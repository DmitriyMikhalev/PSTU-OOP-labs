using System;

namespace lab10
{
    public class SchoolBook : Book
    {
        private int categoryClass;
        public int Category
        {
            get { return categoryClass; }
            set
            {
                if (value >= 1 && value <= 11) categoryClass = value;
                else categoryClass = 11;
            }
        }
        public SchoolBook(in string name, in int pageCount, in int releaseYear, in int price, in int count, in string author, in int categoryClass)
            : base(name, pageCount, releaseYear, price, count, author)
        {
            if (categoryClass >= 1 && categoryClass <= 11) this.categoryClass = categoryClass;
            else this.categoryClass = 11;
        }
        public SchoolBook() { RandomInit(); }
        public override string ToString()
        {
            return (
               $"Тип объекта: {GetType().Name} " +
               $"Учебник: {name} " +
               $"Класс обучения: {categoryClass} " +
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
            string[] names = { "Физика", "История", "География", "Руссий язык", "Химия", "Литература", "Начала мат. анализа" };
            string[] authors = { "Офицерский Снэдвич", "Михаил Порноатаман", "Ашот Робокоп", "Гит Плоскостопия", "Мстислав Панк", "Саша Арматура", "Димон Ситуация" };

            name = names[random.Next(names.Length)];
            author = authors[random.Next(authors.Length)];
            pageCount = random.Next(498);
            releaseYear = random.Next(1998, DateTime.Now.Year);
            price = random.Next(1765);
            countInstances = random.Next(45);
            categoryClass = random.Next(1, 12);
        }
        public override object Clone() => new SchoolBook(name, pageCount, releaseYear, price, countInstances, author, categoryClass);
        public override object ShallowCopy() { return (SchoolBook)this.MemberwiseClone(); }
    }
}
