using DafDev.DafsChristmas.Domains.CalorieCounter;

namespace DafDev.DafsChristmas.Infra.Tests.FileReader;
public class CalorieFileReaderTestData : TheoryData<string, IEnumerable<Elf>>
{
    public CalorieFileReaderTestData()
    {
        var elves = new List<Elf>
        {
            new("Eleanor",new[] {1000, 2000, 3000}),
            new("Arwel",new[] {4000}),
            new("Eliandrel",new[] {5000, 6000}),
            new("Aragorn",new[] {7000, 8000, 9000}),
            new("Charles",new[] {10000}),
        };
        Add(@"C:\Users\afahd\Code\AdventOfCode2022\advent-of-code\tests\DafDev.DafsChristmas.Infra\DafDev.DafsChristmas.Infra.Tests\FileReader\data.txt", elves);
    }
}
