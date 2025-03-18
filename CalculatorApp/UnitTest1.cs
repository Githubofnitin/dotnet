using NUnit.Framework;
using CalculatorLibrary;

namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void Add_ValidInputs_ReturnsCorrectSum()
        {
            double result = _calculator.Add(5, 3);
            Assert.AreEqual(8, result);
        }

        [Test]
        public void Subtract_ValidInputs_ReturnsCorrectDifference()
        {
            double result = _calculator.Subtract(5, 3);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void Multiply_ValidInputs_ReturnsCorrectProduct()
        {
            double result = _calculator.Multiply(5, 3);
            Assert.AreEqual(15, result);
        }

        [Test]
        public void Divide_ValidInputs_ReturnsCorrectQuotient()
        {
            double result = _calculator.Divide(6, 3);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void Divide_DivideByZero_ThrowsDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(5, 0));
        }

        [Test]
        public void Add_Zero_ReturnsSameNumber()
        {
            double result = _calculator.Add(0, 5);
            Assert.AreEqual(5, result);

            result = _calculator.Add(5, 0);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void Subtract_Zero_ReturnsSameNumber()
        {
            double result = _calculator.Subtract(0, 5);
            Assert.AreEqual(-5, result);

            result = _calculator.Subtract(5, 0);
            Assert.AreEqual(5, result);
        }
    }
}
