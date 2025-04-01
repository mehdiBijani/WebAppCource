namespace Strategy;

public class Context
{
    private Strategy _strategy;

    public Context(Strategy strategy)
    {
        _strategy = strategy;
    }

    public void Operation()
    {
        _strategy.Algorithm();
    }
}