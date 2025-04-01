using Iterator;

ConcreteAggregate aggregate = new ConcreteAggregate();

Iterator.Iterator iterator = aggregate.CreateIterator();
aggregate[0] = "A";
aggregate[1] = "B";
aggregate[2] = "C";
aggregate[3] = "D";

object? item = iterator.First();

while (item != null)
{
    Console.WriteLine(item);
    item = iterator.Next();
}