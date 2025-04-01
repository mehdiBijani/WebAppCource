namespace Builder;

public class ConcreteProductBuilder2 : Builder
{
    public override void BuildPart1()
    {
        product.Part1 = "build2.part1";
    }

    public override void BuildPart2()
    {
        product.Part2 = "build2.part2";
    }
}