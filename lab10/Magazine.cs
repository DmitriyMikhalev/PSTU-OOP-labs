using System;

namespace lab10
{
    public class Magazine : Printing
    {
        private string _cycle;

        public string Cycle
        {
            get { return _cycle; }
            set { _cycle = value; }
        }
        public Magazine(in string name, in int pageCount, in int releaseYear, in int price, in int count, in string cycle)
            : base(name, pageCount, releaseYear, price, count) { _cycle = cycle; }
        public Magazine() { RandomInit(); }
        public override string GetInfoOverride()
        {
            return (
                $"Тип объекта: {GetType().Name}\n" +
                $"Журнал: \"{_name}\"\n" +
                $"Цикл: {_cycle}\n" +
                $"Страниц: {_pageCount}\n" +
                $"Год выпуска: {_releaseYear}\n" +
                $"Цена: {_price}\n" +
                $"В наличии: {_countInstances}\n"
           );
        }
        public override void RandomInit()
        {
            Random random = new Random();
            string[] names = { "Forbes", "Игромания", "New York Times", "PlayBoy", "Космополитан", "Big Guns", "Сборник судоку" };
            string[] cycles = { "Игры", "Оружие", "Финансы", "Эротика", "Мода", "Головоломки", "Комиксы" };

            _name = names[random.Next(names.Length)];
            _cycle = cycles[random.Next(cycles.Length)];
            _pageCount = random.Next(500);
            _releaseYear = random.Next(1990, DateTime.Now.Year);
            _price = random.Next(1765);
            _countInstances = random.Next(60);
        }
        public override object Clone() => new Magazine(_name, _pageCount, _releaseYear, _price, _countInstances, _cycle);
        public override object ShallowCopy() { return (Magazine)this.MemberwiseClone(); }
    }
}
