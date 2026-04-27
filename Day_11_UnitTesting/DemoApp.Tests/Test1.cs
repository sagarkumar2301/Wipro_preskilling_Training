namespace DemoApp.Tests;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void TestMethod1()
    {
        //Arrange
        var calc = new Calcualtor();

        // Act
        var result = calc.Multiply(2, 3);

        //Assert
        Assert.AreEqual(6, result);
    }
}
