namespace FactoryMethod;

public class ConcreteCreator : Creator
{
    public override ISampleService GetInstance(int i)
    {
        if (i > 0)
            return new SampleService1();
        
        return new SampleService2();
    }
}