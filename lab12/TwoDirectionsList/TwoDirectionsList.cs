using System.Collections;

namespace TwoDirectionsList
{
    public class TwoDirectionsListNode<T> where T: ICloneable
    {
        public T data;
        public TwoDirectionsListNode <T>? next = null;
        public TwoDirectionsListNode <T>? prev = null;
        public TwoDirectionsListNode()
        {
            data = default;
        }
        public TwoDirectionsListNode(T data)
        {
            this.data = data;
        }
        public TwoDirectionsListNode(T data, TwoDirectionsListNode<T> node, bool isNext)
        {
            this.data = data;
            if (isNext)
            {
                next = node;
                prev = null;
            }
            else
            {
                next = null;
                prev = node;
            }
        }  
        public TwoDirectionsListNode(T data, TwoDirectionsListNode<T> prev, TwoDirectionsListNode<T> next)
        {
            this.data = data;
            this.next = next;
            this.prev = prev;
        }
        public TwoDirectionsListNode(in TwoDirectionsListNode<T> node, in TwoDirectionsListNode<T>? prev, bool isClone)
        {
            if (isClone)
            {
                data = (T)node.data.Clone();
            }
            else
            {
                data = node.data;
            }
            if (node.next is not null)
            {
                next = new TwoDirectionsListNode<T>(node.next, this, isClone);
            }
            else
            {
                next = null;
            }
            this.prev = prev;
        }
    }

    public class TwoDirectionsList<T> : IList <T> where T: ICloneable
    {
        protected TwoDirectionsListNode <T>? head = null;
        protected TwoDirectionsListNode <T>? tail = null;
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentException("Выход индекса за границы.");
                }
                return Find(index).data;
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentException("Выход индекса за границы.");
                }
                Find(index).data = value;
            }
        }
        public bool IsReadOnly { get => false; }
        public int Count { get; protected set; }
        public TwoDirectionsList()
        {
            Count = 0;
        }
        public TwoDirectionsList(IEnumerable<T> objects)
        {
            foreach(T elem in objects)
            {
                Add(elem);
            }
        }
        public TwoDirectionsList(in TwoDirectionsList<T> collection, bool isClone)
        {
            if (collection.Count > 0)
            {
                Count = collection.Count;
                head = new(collection.head, null, isClone);

                TwoDirectionsListNode<T> current = head;

                while (current.next is not null)
                {
                    current = current.next;
                }
                tail = current;
            }
        }
        public void Add(T data)
        {
            if (Count == 0)
            {
                head = new(data);
                tail = head;
            }
            else
            {
                TwoDirectionsListNode<T> newNode = new TwoDirectionsListNode<T>(data, tail, false);
                tail.next = newNode;
                tail = newNode;
            }
            ++Count;
        }
        public bool Remove(T data)
        {
            bool flag = false;
            TwoDirectionsListNode<T>? current = head;

            while (current is not null)
            {
                if (current.data.Equals(data))
                {
                    if (current.next is null)
                    {
                        DeleteTail();
                    }
                    else if (current.prev is null)
                    {
                        DeleteHead();
                    }
                    else
                    {
                        current.prev.next = current.next;
                        current.next.prev = current.prev;
                    }
                    current = null;
                    flag = true;
                }
                else
                {
                    current = current.next;
                }
                --Count;
            }
            return flag;
        }
        public void RemoveAt(int index)
        {
            if (Count > 0)
            {
                if (index < 0 || index >= Count)
                {
                    throw new ArgumentException("Выход индекса за границы.");
                }
                if (index == 0)
                {
                    DeleteHead();
                }
                else if (index == Count - 1)
                {
                    DeleteTail();
                }
                else
                {
                    TwoDirectionsListNode<T> current = Find(index);
                    current.prev.next = current.next;
                    current.next.prev = current.prev;
                    --Count;
                }
            }
        }
        public TwoDirectionsListNode<T>? Find(int index)
        {
            bool isNext = index > ((Count - 1) / 2);
            TwoDirectionsListNode<T>? current = null;
            if (isNext)
            {
                current = head;
            }
            else
            {
                current = tail;
            }
            if (Count > 0)
            {
                int currentIndex = 0;
                if (!isNext)
                {
                    currentIndex = Count - 1;
                }
                while (currentIndex != index)
                {
                    if (isNext)
                    {
                        current = current.next;
                        currentIndex = currentIndex + 1;
                    }
                    else
                    {
                        current = current.prev;
                        currentIndex = currentIndex - 1;
                    }
                }
            }
            return current;
        }
        public int IndexOf(T data)
        {
            int index = -1, currentIndex = 0; 
            foreach (T obj in this)
            {
                if (obj.Equals(data))
                {
                    index = currentIndex;
                    break; 
                }
                ++currentIndex;
            }
            return index;
        }
        public void Insert(int index, T data)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentException("Некорректный индекс.");
            }
            TwoDirectionsListNode<T> current = Find(index);
            TwoDirectionsListNode <T> newNode = new(data);
            if (index == 0)
            {
                head.prev = newNode;
                newNode.next = head;
                head = newNode;
            }
            else
            {
                newNode.prev = current.prev;
                newNode.next = current;
                current.prev.next = newNode;
                current.prev = newNode;
            }
            ++Count;
        }
        public void DeleteHead()
        {
            if(Count>0)
            {
                head = head.next;
                if (head is not null)
                {
                    head.prev = null;
                }
                --Count;
            }
        }
        public void DeleteTail()
        {
            if (Count > 0)
            {
                tail = tail.prev;
                if (tail is not null)
                {
                    tail.next = null;
                }
                --Count;
            }
        }
        public void Clear()
        {
            Count = 0;
            head = null;
            tail = null;
        }
        public bool Contains(T data)
        {
            bool flag = false;
            foreach (T elem in this)
            {
                if (elem.Equals(data))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array is null)
            {
                throw new ArgumentNullException("Массив не может быть пустым.");
            }
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("Индекс для копирования в массив не может быть меньше 0.");
            }
            if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentException("Массив не может быть меньше копируемой последовательности.");
            }
            int index = 0;
            foreach (T value in this)
            {
                array[index + arrayIndex] = value;
                ++index;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            TwoDirectionsListNode<T>? current = head;

            while(current is not null)
            {
                yield return current.data;
                current = current.next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public override string ToString()
        {
            string str = "";
            foreach(T obj in this)
            {
                str += obj + "\n";
            }
            return str;
        }
    }
}