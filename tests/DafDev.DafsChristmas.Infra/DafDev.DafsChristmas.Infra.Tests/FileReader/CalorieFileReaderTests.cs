using DafDev.DafsChristmas.Domains.CalorieCounter;
using DafDev.DafsChristmas.Infra.Tests.FileReader;
using Microsoft.Extensions.Logging;
using Moq;

namespace DafDev.DafsChristmas.Infra.FileReader;

public class CalorieFileReaderTests
{
    private readonly Mock<ILogger<CalorieFileReader>> _mockLogger = new();
    private readonly CalorieFileReader _target;

    public CalorieFileReaderTests()
    {
        _target = new(_mockLogger.Object);
    }

    [Theory]
    [ClassData(typeof(CalorieFileReaderTestData))]
    public void ReadFile_ReturnsExpectedElves(string filePath, IEnumerable<Elf> expected)
    {
        //Act
        var actualArray = _target.ReadCalories(filePath).ToArray();
        var expectedArray = expected.ToArray();
        //Assert
        Assert.Equal(expectedArray.Length, actualArray.Length);
        for(var i = 0; i < actualArray.Length; i++)
        {
            Assert.Equal(expectedArray[i].CalorieIntakes, actualArray[i].CalorieIntakes);
        }
    }
}