void PrintStars(string input)
{
    var splitedInput = input.ToCharArray();

    var evenLines = string.Empty;
    var oddLines = string.Empty;
    foreach (var item in splitedInput)
    {
        if (item.Equals('0'))
        {
            evenLines += "***";
            oddLines += "*.*";
        }
        else
        {
            evenLines += ".*.";
            oddLines += ".*.";
        }
    }
    
    Console.WriteLine(evenLines + "\n" + oddLines + "\n" + evenLines);
}

PrintStars("0101");
PrintStars("10011");
PrintStars("0101");
