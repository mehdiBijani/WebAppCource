namespace Iterator;

internal class ConcreteIterator : Iterator
{
    ConcreteAggregate aggregate;
    int current = 0;
    
    public ConcreteIterator(ConcreteAggregate aggregate)
    {
        this.aggregate = aggregate;
    }
    
    public override object First()
    {
        return aggregate[0];
    }

    public override object? Next()
    {
        object? result = null;

        if (current < aggregate.Count - 1)
            result = aggregate[++current];

        return result;
    }

    public override bool IsDone()
    {
        return current >= aggregate.Count - 1;
    }

    public override object CurrentItem()
    {
        return aggregate[current];
    }
}