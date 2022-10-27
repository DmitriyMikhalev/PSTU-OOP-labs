using System;

namespace lab10
{
    public class Point : IRandomInit, IComparable
    {
        private int _x;
        private int _y;

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public Point(in int x, in int y)
        {
            _x = x;
            _y = y;
        }
        public Point() { RandomInit(); }

        public void RandomInit()
        {
            Random random = new Random();
            _x = random.Next(-100, 100);
            _y = random.Next(-100, 100);
        }

        public int CompareTo(object? obj)
        {
            if (obj is Point point) return (_x + _y).CompareTo(point.X + point.Y);
            else if (obj is Printing printing) return (_x + _y).CompareTo(printing.Count * printing.Price);

            throw new ArgumentException("Некорректное сравнение.");
        }
        public string GetInfo() { return $"x = {_x}, y = {_y}"; }
    }
}
