
using CalculatorApp;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorApp.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void TestAdd()
        {
            Calculator calc = new Calculator();
            double result = calc.Add(2, 3);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void TestSubtract()
        {
            Calculator calc = new Calculator();
            double result = calc.Subtract(5, 2);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void TestMultiply()
        {
            Calculator calc = new Calculator();
            double result = calc.Multiply(4, 3);
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void TestDivide()
        {
            Calculator calc = new Calculator();
            double result = calc.Divide(10, 2);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void TestDivideByZero()
        {
            Calculator calc = new Calculator();
            Assert.Throws<DivideByZeroException>(() => calc.Divide(10, 0));
        }

        [TestMethod]
        public void TestAddZero()
        {
            Calculator calc = new Calculator();
            double result = calc.Add(5, 0);
            Assert.AreEqual(5, result);
        }
    }
}
