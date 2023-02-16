

using TwoDirectionsList;

namespace lab13
{
    public class CollectionHandlerEventArgs : EventArgs
    {
        public string CollectionName { get; }
        public string ChangeType { get; }
        public Printing chainedObject { get; }
        public CollectionHandlerEventArgs(string CollectionName, string ChangeType, Printing chainedObject)
        {
            this.CollectionName = CollectionName;
            this.ChangeType = ChangeType;
            this.chainedObject = chainedObject;
        }
        public override string ToString()
        {
            return $"Имя коллекции: {CollectionName}, тип изменения: {ChangeType}";
        }
    }
    public class MyNewCollection : TwoDirectionsList<Printing>
    {
        public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);
        public event CollectionHandler CollectionCountChanged;
        public event CollectionHandler CollectionReferenceChanged;
        public override Printing this[int index]
        {
            get
            {
                return base[index];
            }
            set
            {
                base[index] = value;
                OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs(Name, "изменение", value));
            }
        }
        public string Name { get; set; }
        public MyNewCollection()
        {
            Count = 0;
            Name = "MyNewCollection";
        }
        public override void Add(Printing obj)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(Name, "добавление", obj));
            base.Add(obj);
        }
        public override bool Remove(Printing data)
        {
            Printing obj = data;
            bool wasRemoved = base.Remove(data);
            if (wasRemoved)
            {
                OnCollectionCountChanged(this, new CollectionHandlerEventArgs(Name, "удаление", obj));
            }
            return wasRemoved;
            
        }
        public override void RemoveAt(int index)
        {
            Printing obj = this[index];
            if (base.Remove(obj))
            {
                OnCollectionCountChanged(this, new CollectionHandlerEventArgs(Name, "удаление", obj));
            }
        }
        public void OnCollectionCountChanged(object source, CollectionHandlerEventArgs args)
        {
            CollectionCountChanged?.Invoke(this, args); // уведомление подписчиков о произошедшем событии
        }
        public void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
        {
            CollectionReferenceChanged?.Invoke(this, args);
        }
    }
}
