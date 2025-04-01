namespace Iterator;

internal class ConcreteAggregate : Aggregate
{
    List<object> itemList = new();

    public override Iterator CreateIterator()
    {
        return new ConcreteIterator(this);
    }

    public int Count => itemList.Count;

    public object this[int index]
    {
        get => itemList[index];
        set => itemList.Insert(index, value);
    }
}