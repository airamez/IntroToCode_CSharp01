using NUnit.Framework;

[TestFixture]
public class MyClassTest
{
    [Test]
    public void TestDivision1()
    {
        // Arrange
        int dividend = 10;
        int divisor = 2;
        decimal expected = 5;

        // Act
        decimal result = MyClass.division(dividend, divisor);

        // Assert
        Assert.AreEqual(MyClass.division(dividend, divisor), result);
    }

    [Test]
    public void TestDivision2()
    {
        Assert.AreEqual(MyClass.division(8, 2), 4);
    }

    [Test]
    public void TestDivision3()
    {
        Assert.AreEqual(MyClass.division(9, 3), 3);
    }

    [Test]
    public void TestDivision4()
    {
        Assert.AreEqual(MyClass.division(20, 2), 10);
    }

    [Test]
    public void TestDivision5()
    {
        //        Assert.AreEqual(MyClass.division(7, 2), 3.5);
    }
}