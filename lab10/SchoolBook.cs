using System;

namespace lab10
{
    public class SchoolBook : Book
    {
        private int _categoryClass;
        public int Category
        {
            get { return _categoryClass; }
            set
            {
                if (value >= 1 && value <= 11) _categoryClass = value;
                else _categoryClass = 11;
            }
        }
        public SchoolBook(in string name, in int pageCount, in int releaseYear, in int price, in int count, in string author, in int categoryClass)
            : base(name, pageCount, releaseYear, price, count, author)
        {
            if (categoryClass >= 1 && categoryClass <= 11) _categoryClass = categoryClass;
            else _categoryClass = 11;
        }
        public SchoolBook() { RandomInit(); }
        public override string GetInfoOverride()
        {
            return (
               $"Тип объекта: {GetType().Name}\n" +
               $"Учебник: \"{_name}\"\n" +
               $"Класс обучения: {_categoryClass}\n" +
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
            string[] names = { "Физика", "История", "География", "Руссий язык", "Химия", "Литература", "Начала мат. анализа" };
            string[] authors = { "Офицерский Снэдвич", "Михаил Порноатаман", "Ашот Робокоп", "Гит Плоскостопия", "Мстислав Панк", "Саша Арматура", "Димон Ситуация" };

            _name = names[random.Next(names.Length)];
            _author = authors[random.Next(authors.Length)];
            _pageCount = random.Next(498);
            _releaseYear = random.Next(1998, DateTime.Now.Year);
            _price = random.Next(1765);
            _countInstances = random.Next(45);
            _categoryClass = random.Next(1, 12);
        }
        public override object Clone() => new SchoolBook(_name, _pageCount, _releaseYear, _price, _countInstances, _author, _categoryClass);
        public override object ShallowCopy() { return (SchoolBook)this.MemberwiseClone(); }
    }
}
