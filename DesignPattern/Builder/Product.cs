namespace Builder;

public class Product
{
    public string Part1 { get; set; }
    public string Part2 { get; set; }

    public void ShowResult()
    {
        Console.WriteLine($"title1: {Part1} \ntitle2: {Part2}");
    }
}