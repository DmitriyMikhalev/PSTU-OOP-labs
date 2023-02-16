
namespace lab13
{
    public class JournalEntry
    {
        public string CollectionName { get; }
        public string ChangeType { get; }
        public string ObjectInfo { get; }
        public JournalEntry(string CollectionName, string ChangeType, string ObjectInfo)
        {
            this.ObjectInfo = ObjectInfo;
            this.CollectionName = CollectionName;
            this.ChangeType = ChangeType;
        }
        public override string ToString()
        {
            return $"Имя коллекции: {CollectionName}, Тип изменения: {ChangeType}, Информация об объекте: {ObjectInfo}";
        }
    }
    public class Journal
    {
        public List<JournalEntry> journal = new List<JournalEntry>();
        public void CollectionCountChanged(object source, CollectionHandlerEventArgs args)
        {
            journal.Add(new JournalEntry(args.CollectionName, args.ChangeType, args.chainedObject.ToString()));
        }
        public void CollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
        {
            journal.Add(new JournalEntry(args.CollectionName, args.ChangeType, args.chainedObject.ToString()));
        }
    }
}
