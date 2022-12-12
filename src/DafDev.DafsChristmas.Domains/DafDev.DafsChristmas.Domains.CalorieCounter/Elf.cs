namespace DafDev.DafsChristmas.Domains.CalorieCounter;

public class Elf
{
    public Elf(string name, IEnumerable<int> calorieIntakes)
    {
        Name = name;
        CalorieIntakes = calorieIntakes;
    }

    public string Name { get; set; }
    public IEnumerable<int> CalorieIntakes { get; set; }

}