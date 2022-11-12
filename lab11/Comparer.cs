using System.Collections.Generic;

namespace lab11
{
    class Comparer : IComparer<Printing>
    {
        public int Compare(Printing x, Printing y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
