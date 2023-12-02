using System.Text.RegularExpressions;
using Xunit.Abstractions;

namespace AdventOfCode2023;

public class DayOne
{
    private readonly ITestOutputHelper _output;

    public DayOne(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void PartOne()
    {
        using var reader = new StreamReader("./Day1/Input");
        var line = reader.ReadLine();

        var sum = 0;

        while (line != null)
        {
            var numbers = Regex.Matches(line, @"\d").Select(x => x.Value).ToArray();
            if (numbers is null || numbers.Length == 0) continue;
            if (numbers.Length > 0)
            {
                sum += int.Parse($"{numbers[0]}{numbers[^1]}");
            }

            line = reader.ReadLine();
        }

        _output.WriteLine($"{sum}");
    }

    [Fact]
    public void PartOne_Refactored()
    {
        using var reader = new StreamReader("./Day1/Input");
        var line = reader.ReadLine();

        var sum = 0;

        while (line != null)
        {
            var firstDigit = Regex.Match(line, @"\d").Value;
            var lastDigit = Regex.Match(line, @"\d", RegexOptions.RightToLeft).Value;

            sum += int.Parse($"{firstDigit}{lastDigit}");

            line = reader.ReadLine();
        }

        _output.WriteLine($"{sum}");
    }

    [Fact]
    public void PartTwo()
    {
        using var reader = new StreamReader("./Day1/Input");
        var line = reader.ReadLine();

        var sum = 0;

        var dict = new Dictionary<string, int>
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 }
        };

        while (line != null)
        {
            var matches = Regex.Matches(line, @"(?=(\d|one|two|three|four|five|six|seven|eight|nine))");
            var numbers = matches.Select(x => x.Groups[1].Value).ToArray();
            if (numbers is null || numbers.Length == 0) continue;
            if (numbers.Length > 0)
            {
                var firstDigit = int.TryParse(numbers[0], out var first) ? first : dict[numbers[0]];
                var lastDigit = int.TryParse(numbers[^1], out var last) ? last : dict[numbers[^1]];

                sum += int.Parse($"{firstDigit}{lastDigit}");
            }

            line = reader.ReadLine();
        }

        _output.WriteLine($"{sum}");
    }

    [Fact]
    public void PartTwo_Refactored()
    {
        using var reader = new StreamReader("./Day1/Input");
        var line = reader.ReadLine();

        var sum = 0;

        while (line != null)
        {
            var firstDigit = Regex.Match(line, @"\d|one|two|three|four|five|six|seven|eight|nine").Value;
            var lastDigit = Regex.Match(line, @"\d|one|two|three|four|five|six|seven|eight|nine", RegexOptions.RightToLeft).Value;

            sum += int.Parse($"{Parse(firstDigit)}{Parse(lastDigit)}");

            line = reader.ReadLine();
        }

        _output.WriteLine($"{sum}");
    }

    public int Parse(string value) => value switch
    {
        "one" => 1,
        "two" => 2,
        "three" => 3,
        "four" => 4,
        "five" => 5,
        "six" => 6,
        "seven" => 7,
        "eight" => 8,
        "nine" => 9,
        _ => int.Parse(value)
    };
}