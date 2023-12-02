using System.Text.RegularExpressions;
using Xunit.Abstractions;

namespace AdventOfCode2023;

public class DayTwo
{
    private readonly ITestOutputHelper _output;

    public DayTwo(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void PartOne()
    {
        using var reader = new StreamReader("./Day2/Input");
        var line = reader.ReadLine();

        int sum = 0;

        while (line != null)
        {
            var game = Regex.Match(line, @"Game \d+").Value;
            var gameId = int.Parse(game.Split(' ')[1]);
            var red = Regex.Matches(line, @"\d+ red").ToArray();
            var green = Regex.Matches(line, @"\d+ green").ToArray();
            var blue = Regex.Matches(line, @"\d+ blue").ToArray();

            var redValid = red.All(m => int.Parse(m.Value[..2]) <= 12);
            var greenValid = green.All(m => int.Parse(m.Value[..2]) <= 13);
            var blueValid = blue.All(m => int.Parse(m.Value[..2]) <= 14);

            if (redValid && greenValid && blueValid) sum += gameId;

            line = reader.ReadLine();
        }

        _output.WriteLine($"{sum}");
    }

    [Fact]
    public void PartOne_Refactored()
    {

    }

    [Fact]
    public void PartTwo()
    {
        using var reader = new StreamReader("./Day2/Input");
        var line = reader.ReadLine();

        int sum = 0;

        while (line != null)
        {
            var red = Regex.Matches(line, @"\d+ red").ToArray();
            var green = Regex.Matches(line, @"\d+ green").ToArray();
            var blue = Regex.Matches(line, @"\d+ blue").ToArray();

            var redMin = red.Max(m => int.Parse(m.Value[..2]));
            var greenMin = green.Max(m => int.Parse(m.Value[..2]));
            var blueMin = blue.Max(m => int.Parse(m.Value[..2]));

            sum += (redMin * greenMin * blueMin);

            line = reader.ReadLine();
        }

        _output.WriteLine($"{sum}");
    }

    [Fact]
    public void PartTwo_Refactored()
    {

    }
}
 