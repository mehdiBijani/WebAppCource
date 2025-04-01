namespace Builder;

public class ConcreteProductBuilder1 : Builder
{
    public override void BuildPart1()
    {
        product.Part1 = "build1.part1";
    }

    public override void BuildPart2()
    {
        product.Part2 = "build1.part2";
    }
}