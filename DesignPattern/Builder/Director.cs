namespace Builder;

public class Director
{
    private Builder _builder;

    public void SetProductBuilder(Builder builder)
    {
        _builder = builder;
    }

    public void Construct()
    {
        _builder.BuildPart1();
        _builder.BuildPart2();
    }
}