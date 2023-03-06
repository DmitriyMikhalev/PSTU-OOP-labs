using TwoDirectionsList;
using System.Collections;

namespace lab14
{
    public static class ExtensionsForList
    {
        public static IEnumerable Select<T, G>(this TwoDirectionsList<T> list, Predicate<T> predicate, Func<T, G> selector) where T : ICloneable where G : ICloneable
        {
            TwoDirectionsList<G> result = new();
            foreach (T obj in list)
            {
                if (predicate(obj))
                {
                    result.Add(selector(obj));
                }
            }
            return result;
        }
        public static int Sum<T>(this TwoDirectionsList<T> list, Func<T, int> selector) where T : ICloneable
        {
            int sum = 0;
            foreach (T obj in list)
            {
                sum += selector(obj);
            }
            return sum;
        }
        public static int Average<T>(this TwoDirectionsList<T> list, Func<T, int> selector) where T : ICloneable
        {
            int sum = 0, count = 1;
            foreach (T obj in list)
            {
                sum += selector(obj);
                ++count;
            }
            return sum / count;
        }
        public static int Max<T>(this TwoDirectionsList<T> list, Func<T, int> selector) where T : ICloneable
        {
            int max = 0;
            IEnumerator<T> enumerator = list.GetEnumerator();
            enumerator.MoveNext();
            if (enumerator.Current is not null)
            {
                max = selector(enumerator.Current);
            }
            foreach (T obj in list)
            {
                max = selector(obj) > max ? selector(obj) : max;
            }
            return max;
        }
        public static int Min<T>(this TwoDirectionsList<T> list, Func<T, int> selector) where T : ICloneable
        {
            int max = 0;
            IEnumerator<T> enumerator = list.GetEnumerator();
            enumerator.MoveNext();
            if (enumerator.Current is not null)
            {
                max = selector(enumerator.Current);
            }
            foreach (T obj in list)
            {
                max = selector(obj) < max ? selector(obj) : max;
            }
            return max;
        }
        public static T Aggregate<T>(this TwoDirectionsList<T> list, Func<T, T, T> aggregator) where T : ICloneable
        {
            T seed = default;
            if (list.Count > 0)
            {
                IEnumerator<T> enumerator = list.GetEnumerator();
                enumerator.MoveNext();
                seed = enumerator.Current;
                while (enumerator.MoveNext())
                {
                    seed = aggregator(seed, enumerator.Current);
                }
            }
            else
            {
                throw new Exception("Коллекция пуста.");
            }
            return seed;
        }
        public static TAccum Aggregate<T, TAccum>(this TwoDirectionsList<T> list, TAccum accum, Func<TAccum, T, TAccum> aggregator) where T : ICloneable
        {
            if (list.Count > 0)
            {
                IEnumerator<T> enumerator = list.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    accum = aggregator(accum, enumerator.Current);
                }
            }
            return accum;
        }
        public static IEnumerable OrderByAsc<T, TKey>(this TwoDirectionsList<T> list, Func<T, TKey> selector, Func<TKey, TKey, int> comparer) where T : ICloneable
        {
            TwoDirectionsList<T> orderedList = new(list, false);
            int patrition(TwoDirectionsList<T> list, int start, int end)
            {
                T pivot = list[end];
                int pivotIndex = start;
                for (int i = start; i < end; ++i)
                {
                    int result = comparer(selector(list[i]), selector(pivot));
                    if (result == -1 || result == 0)
                    {
                        T buffer = list[i];
                        list[i] = list[pivotIndex];
                        list[pivotIndex] = buffer;
                        ++pivotIndex;
                    }
                }

                T buff = list[pivotIndex];
                list[pivotIndex] = list[end];
                list[end] = buff;
                return pivotIndex;
            }
            void quickSort(TwoDirectionsList<T> list, int start, int end)
            {
                if (start >= end)
                {
                    return;
                }

                int pivot = patrition(list, start, end);

                quickSort(list, start, pivot - 1);
                quickSort(list, pivot + 1, end);
            }
            quickSort(orderedList, 0, orderedList.Count - 1);
            return orderedList;
        }
        public static IEnumerable OrderByDesc<T, TKey>(this TwoDirectionsList<T> list, Func<T, TKey> selector, Func<TKey, TKey, int> comparer) where T : ICloneable
        {
            TwoDirectionsList<T> orderedList = new(list, false);
            int patrition(TwoDirectionsList<T> list, int start, int end)
            {
                T pivot = list[end];
                int pivotIndex = start;
                for (int i = start; i < end; i++)
                {
                    int result = comparer(selector(list[i]), selector(pivot));
                    if (result == 1 || result == 0)
                    {
                        T buffer = list[i];
                        list[i] = list[pivotIndex];
                        list[pivotIndex] = buffer;
                        ++pivotIndex;
                    }
                }

                T buff = list[pivotIndex];
                list[pivotIndex] = list[end];
                list[end] = buff;
                return pivotIndex;
            }
            void quickSort(TwoDirectionsList<T> list, int start, int end)
            {
                if (start >= end)
                {
                    return;
                }

                int pivot = patrition(list, start, end);

                quickSort(list, start, pivot - 1);
                quickSort(list, pivot + 1, end);
            }
            quickSort(orderedList, 0, orderedList.Count - 1);
            return orderedList;
        }
    }
}
