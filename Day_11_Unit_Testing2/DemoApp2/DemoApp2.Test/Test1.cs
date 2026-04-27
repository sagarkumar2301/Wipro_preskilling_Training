namespace DemoApp2.Test
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            var calculator = new Calcualtor();

            //Act
            var result = calculator.Multiply(2, 3);

            //Assert
            Assert.AreEqual(6, result);
        }
    }
}
