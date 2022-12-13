using DafDev.DafsChristmas.Domains.CalorieCounter;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DafDev.DafsChristmas.Infra.FileReader;
public class CalorieFileReader : IObtainCalories
{
    private readonly Random _random;
    private readonly ILogger<CalorieFileReader> _logger;
    public CalorieFileReader(ILogger<CalorieFileReader> logger)
    {
        _random = new Random();
        _logger = logger;
    }

    public IEnumerable<Elf> ReadCalories(string filepath)
    {
        if (string.IsNullOrWhiteSpace(filepath))
            return Enumerable.Empty<Elf>();

        var elves = new List<Elf>();
        var intakes = new List<int>();
        var lines = File.ReadAllLines(filepath);
        _logger.LogInformation("File {filepath} has been read", filepath);
        foreach (var line in lines)
        {
            if(string.IsNullOrWhiteSpace(line))
            {
                elves.Add(new(CreateRandomElfName(), intakes));
                intakes = new List<int>();
            }
            else
                intakes.Add(int.Parse(line));
        }
        //Adding last entries at the end of the file
        elves.Add(new(CreateRandomElfName(), intakes));

        return elves;
    }

    private string CreateRandomElfName()
    {
        var size = _random.Next(4, 11);
        var builder = new StringBuilder(size);

        // char is a single Unicode character  
        char offset = 'a' ;
        const int lettersOffset = 26; // a..z: length = 26  

        for (var i = 0; i < size; i++)
        {
            var letter = (char)_random.Next(offset, offset + lettersOffset);
            builder.Append(letter);
        }

        return builder.ToString();
    }
}
