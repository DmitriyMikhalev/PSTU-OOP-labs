using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace lab10
{
    [Serializable]
    public class Magazine : Printing
    {
        private string cycle;
        [JsonInclude]
        [XmlAttribute]
        public string Cycle
        {
            get { return cycle; }
            set { cycle = value; }
        }
        public Magazine(in string name, in int pageCount, in int releaseYear, in int price, in int count, in string cycle)
            : base(name, pageCount, releaseYear, price, count) { this.cycle = cycle; }
        public Magazine() { RandomInit(); }
        public override string ToString()
        {
            return (
                $"Тип объекта: {GetType().Name} " +
                $"Журнал: {name} " +
                $"Цикл: {cycle} " +
                $"Страниц: {pageCount} " +
                $"Год выпуска: {releaseYear} " +
                $"Цена: {price} " +
                $"В наличии: {countInstances} "
           );
        }
        public override void RandomInit()
        {
            Random random = Rand.random;
            string[] names = { "Forbes", "Игромания", "New York Times", "PlayBoy", "Космополитан", "Big Guns", "Сборник судоку" };
            string[] cycles = { "Игры", "Оружие", "Финансы", "Эротика", "Мода", "Головоломки", "Комиксы" };

            name = names[random.Next(names.Length)];
            cycle = cycles[random.Next(cycles.Length)];
            pageCount = random.Next(500);
            releaseYear = random.Next(1990, DateTime.Now.Year);
            price = random.Next(1765);
            countInstances = random.Next(60);
        }
        public override object Clone() => new Magazine(name, pageCount, releaseYear, price, countInstances, cycle);
        public override object ShallowCopy() { return (Magazine)this.MemberwiseClone(); }
    }
}
