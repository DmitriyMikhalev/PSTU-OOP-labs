using System.Collections;

namespace lab10
{
    public class SortByName : IComparer
    {
        public int Compare(object x, object y)
        {
            Printing obj1 = x as Printing;
            Printing obj2 = y as Printing;

            return string.Compare(obj1.Name, obj2.Name);
        }
    }
}
