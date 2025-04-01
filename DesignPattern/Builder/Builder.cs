namespace Builder;

public abstract class Builder
{
    protected Product product = new();

    public abstract void BuildPart1();
    
    public abstract void BuildPart2();

    public Product GetResult()
    {
        return product;
    }
}