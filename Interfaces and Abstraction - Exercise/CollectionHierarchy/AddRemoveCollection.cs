namespace CollectionHierarchy
{
    public class AddRemoveCollection : CustomCollection, IRemove
    {
        public override int Add(string item)
        {
            base.Data.Insert(0, item);

            return 0;
        }

        public virtual string Remove()
        {
            string element = Data[Data.Count - 1];
            base.Data.Remove(element);

            return element;
        }
    }
}