using System;
using System.Text;

namespace lab11
{
    public class Printing
    {
        protected string name;
        protected int pageCount;
        protected int releaseYear;
        protected int price;
        protected int countInstances;
        public override string ToString()
        {
            return Name;
        }

        public string GetRandomString()
        {
            int stringLen = Rnd.random.Next(15, 20);
            int randValue;
            string str = "";
            char letter;
            for (int i = 0; i < stringLen; i++)
            {
                randValue = Rnd.random.Next(-30, 50);
                letter = Convert.ToChar(randValue + 65);
                str = str + letter;
            }

            return str;
        }
        public virtual void RandomInit()
        {
            Name = GetRandomString();
            Pages = Rnd.random.Next(500);
            Year = Rnd.random.Next(1990, DateTime.Now.Year);
            Price = Rnd.random.Next(1765);
            Count = Rnd.random.Next(60);
        }
        public int Count
        {
            get 
            { 
                return countInstances; 
            }
            set
            {
                if (value > 0) 
                    countInstances = value;
                else 
                    countInstances = 0;
            }
        }
        public int Price
        {
            get 
            { 
                return price; 
            }
            set
            {
                if (value >= 0) 
                    price = value;
                else 
                    price = 0;
            }
        }
        public string Name
        {
            get 
            { 
                return name; 
            }
            set 
            { 
                name = value; 
            }
        }
        public int Pages
        {
            get 
            { 
                return pageCount; 
            }
            set
            {
                if (value > 0) 
                    pageCount = value;
                else 
                    pageCount = 0;
            }
        }
        public int Year
        {
            get 
            { 
                return releaseYear; 
            }
            set
            {
                if (value > 1700 && value < DateTime.Now.Year) 
                    releaseYear = value;
                else 
                    releaseYear = DateTime.Now.Year;
            }
        }
        public Printing(in string name, in int pageCount, in int releaseYear, in int price, in int count)
        {
            Name = name;
            Pages = pageCount;
            Year = releaseYear;
            Price = price;
            Count = count;
        }
        public Printing() 
        { 
            RandomInit(); 
        }
        public virtual string GetInfo()
        {
            return (
                $"Тип объекта: {GetType().Name}\n" +
                $"Название: \"{Name}\"\n" +
                $"Страниц: {Count}\n" +
                $"Год выпуска: {Year}\n" +
                $"Цена: {Price}\n" +
                $"В наличии: {Count}\n"
            );
        }
        public virtual object Clone() => new Printing(name, pageCount, releaseYear, price, countInstances);
    }
}