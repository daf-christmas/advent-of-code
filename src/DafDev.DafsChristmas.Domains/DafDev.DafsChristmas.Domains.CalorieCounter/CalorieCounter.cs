using Microsoft.Extensions.Logging;

namespace DafDev.DafsChristmas.Domains.CalorieCounter;

public class CalorieCounter : ICountCalories
{
    private readonly ILogger<CalorieCounter> _logger;
    private readonly IObtainCalories _obtainCalories;

    public CalorieCounter(ILogger<CalorieCounter> logger, IObtainCalories obtainCalories)
    {
        _logger = logger;
        _obtainCalories = obtainCalories;
    }

    public int DisplayHighestCalorieIntake(string filepath)
    {
        var elves = _obtainCalories.ReadCalories(filepath);
        var (ElfName, Intake) = GetElfWithHighestCalorieIntake(elves);
        _logger.LogInformation($"The Elf with the highest calori intake is {ElfName} with {Intake} calories");
        return Intake;
    }

    private static (string ElfName, int Intake) GetElfWithHighestCalorieIntake(IEnumerable<Elf> elves)
    {
        var highestIntake = 0;
        var elfName = "";
        foreach (var elf in elves)
        {
            var intakes = elf.CalorieIntakes.Sum();
            if (intakes > highestIntake)
            {
                highestIntake = intakes;
                elfName= elf.Name;
            }
        }
        return (elfName, highestIntake);
    }
}