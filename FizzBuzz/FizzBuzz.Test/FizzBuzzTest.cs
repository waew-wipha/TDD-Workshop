namespace FizzBuzz.Test;

public class FizzBuzzTest
{
    [Fact]
    public void Count_1_Should_Get_1()
    {
        // Arrange
        uint number = 1;

        string expacted = "1";

        FizzBuzz fizzBuzz = new FizzBuzz();


        // Act
        string actual = fizzBuzz.Count(number);

        // Assert
        Assert.Equal(expacted, actual);
    }
    
    [Fact]
    public void Count_2_Should_Get_2()
    {
        // Arrange
        uint number = 2;

        string expacted = "2";

        FizzBuzz fizzBuzz = new FizzBuzz();


        // Act
        string actual = fizzBuzz.Count(number);

        // Assert
        Assert.Equal(expacted, actual);
    }
}