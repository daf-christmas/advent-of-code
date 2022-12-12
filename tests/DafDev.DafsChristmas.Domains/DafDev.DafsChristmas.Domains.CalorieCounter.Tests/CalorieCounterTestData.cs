namespace DafDev.DafsChristmas.Domains.CalorieCounter;
public class CalorieCounterTestData: TheoryData<IEnumerable<Elf>,int>
{
    public CalorieCounterTestData()
    {
        var elves = new List<Elf>
        {
            new("Eleanor",new[] {1000, 2000, 3000}),
            new("Arwel",new[] {4000}),
            new("Eliandrel",new[] {5000, 6000}),
            new("Aragorn",new[] {7000, 8000, 9000}),
            new("Charles",new[] {10000}),
        };
        Add(elves, 24000);
    }

}
