namespace DafDev.DafsChristmas.Domains.CalorieCounter;
public interface IObtainCalories
{
    IEnumerable<Elf> ReadCalories(string filepath);
}
