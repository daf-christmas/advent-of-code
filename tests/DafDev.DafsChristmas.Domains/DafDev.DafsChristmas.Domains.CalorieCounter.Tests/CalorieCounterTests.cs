using Microsoft.Extensions.Logging;

namespace DafDev.DafsChristmas.Domains.CalorieCounter;
public class CalorieCounterTests
{
    private readonly Mock<IObtainCalories> _mockCalories = new();
    private readonly Mock<ILogger<CalorieCounter>> _mockLogger = new();
    private readonly CalorieCounter _target;

    public CalorieCounterTests() => _target = new(_mockLogger.Object, _mockCalories.Object);

    [Theory]
    [ClassData(typeof(CalorieCounterTestData))]
    public void DisplayHighestCalorieIntake_ReturnsHighestCalorieIntake(IEnumerable<Elf> elves, int expected)
    {
        //Arrange
        _mockCalories.Setup(c => c.ReadCalories(It.IsAny<string>())).Returns(elves);
        //Act
        var actual = _target.DisplayHighestCalorieIntake("path");
        //Assert
        Assert.Equal(expected, actual);
    }
}