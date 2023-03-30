# xUnit

## Parameterize

### Theory and InlineData

```cs
public class CalculatorTest
{
    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(-4, -6, -10)]
    [InlineData(-2, 2, 0)]
    [InlineData(int.MinValue, -1, int.MaxValue)]
    public void ShouldAddWith(int leftOperand, int rightOperand, int expectedValue)
    {
        var calculator = new Calculator();

        var actualValue = calculator.Add(leftOperand, rightOperand);

        Assert.Equal(expectedValue, actualValue);
    }
}
```

## Capturing Output

Unit tests have access to a special interface which replaces previous usage of Console and similar mechanisms: ITestOutputHelper. In order to take advantage of this, just add a constructor argument for this interface, and stash it so you can use it in the unit test.

To see output from `dotnet test`, pass the command line option `--logger "console;verbosity=detailed"`

```cs
public class LifeCycleTest
{
    private readonly ITestOutputHelper output;

    public LifeCycleTest(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void MyTest01() {
        output.WriteLine("MyTest01");
    }
}
```

## Life Cycle

### Constructor and Dispose

when you want a clean test context for every test (sharing the setup and cleanup code, without sharing the object instance).

```cs
public class LifeCycleTest : IDisposable
{
    private readonly ITestOutputHelper output;

    public LifeCycleTest(ITestOutputHelper output)
    {
        this.output = output;
        this.output.WriteLine("Setup");
    }

    public void Dispose()
    {
        output.WriteLine("Teardown");
    }

    [Fact]
    public void MyTest01() {
        output.WriteLine("MyTest01");
    }

    [Fact]
    public void MyTest02() {
        output.WriteLine("MyTest02");
    }
}
```

### Class Fixtures

When you want to create a single test context and share it among all the tests in the class, and have it cleaned up after all the tests in the class have finished.

```cs
public class LifeCycleTest : IClassFixture<MyFixture>, IDisposable
{
    private readonly MyFixture fixture;
    private readonly ITestOutputHelper output;

    public LifeCycleTest(MyFixture fixture, ITestOutputHelper output)
    {
        this.output = output;
        this.output.WriteLine("Setup");
        this.fixture = fixture;
    }

    ...
}
```

```cs
public class MyFixture : IDisposable
{
    private string message { get; set; }

    public MyFixture()
    {
        message = "Hello";
    }

    public void Dispose()
    {
        message = "Bye";
    }
}
```

### Collection Fixtures

When you want to create a single test context and share it among tests in several test classes, and have it cleaned up after all the tests in the test classes have finished.

```cs
[CollectionDefinition("MyFixture collection")]
public class MyCollectionFixture : ICollectionFixture<MyFixture>
{

}
```

```cs
public class LifeCycleTest : IClassFixture<MyFixture>, IDisposable
{
    private readonly MyFixture fixture;
    private readonly ITestOutputHelper output;

    public LifeCycleTest(MyFixture fixture, ITestOutputHelper output)
    {
        this.output = output;
        this.output.WriteLine("Setup");
        this.fixture = fixture;
        this.output.WriteLine(this.fixture.GetHashCode().ToString());
    }

    ...
}
```

```cs
[Collection("MyFixture collection")]
public class LifeCycleTest2 : IDisposable
{
    private readonly MyFixture fixture;
    private readonly ITestOutputHelper output;

    public LifeCycleTest2(MyFixture fixture, ITestOutputHelper output)
    {
        this.output = output;
        this.output.WriteLine("Setup");
        this.fixture = fixture;
        this.output.WriteLine(this.fixture.GetHashCode().ToString());
    }

    public void Dispose()
    {
        output.WriteLine("Teardown");
    }

    [Fact]
    public void MyTest01() {
        output.WriteLine("MyTest01");
    }

    [Fact]
    public void MyTest02() {
        output.WriteLine("MyTest02");
    }
}
```

---

## References

1. [https://xunit.net/](https://xunit.net/)
2. [https://xunit.net/docs/capturing-output](https://xunit.net/docs/capturing-output)
3. [https://xunit.net/docs/shared-context](https://xunit.net/docs/shared-context)
4. [https://andrewlock.net/creating-parameterised-tests-in-xunit-with-inlinedata-classdata-and-memberdata/](https://andrewlock.net/creating-parameterised-tests-in-xunit-with-inlinedata-classdata-and-memberdata/)
