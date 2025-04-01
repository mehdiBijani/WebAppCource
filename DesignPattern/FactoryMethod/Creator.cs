namespace FactoryMethod;

public abstract class Creator
{
    public abstract ISampleService GetInstance(int i);
}