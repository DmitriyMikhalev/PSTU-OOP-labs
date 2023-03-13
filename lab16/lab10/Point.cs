using System;

namespace lab10
{
    public class Point : IRandomInit, IComparable
    {
        private int x;
        private int y;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public Point(in int x, in int y)
        {
            this.x = x;
            this.y = y;
        }
        public Point() { RandomInit(); }

        public void RandomInit()
        {
            Random random = Rand.random;
            x = random.Next(-100, 100);
            y = random.Next(-100, 100);
        }

        public int CompareTo(object? obj)
        {
            if (obj is Point point) return (x + y).CompareTo(point.X + point.Y);
            else if (obj is Printing printing) return (x + y).CompareTo(printing.Count * printing.Price);

            throw new ArgumentException("Некорректное сравнение.");
        }
        public string GetInfo() { return $"x = {x}, y = {y}"; }
    }
}
