using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculatorLibraryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void isMultiplyingOK()
        {
            CalculatorLibrary.MultiplyingCalculator mcalc = new CalculatorLibrary.MultiplyingCalculator();
            int result = mcalc.multiply(3, 5);
            Assert.AreEqual(15, result);
            result = mcalc.multiply(-3, -5);
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void MultiplyingBy0()
        {
            CalculatorLibrary.MultiplyingCalculator mcalc = new CalculatorLibrary.MultiplyingCalculator();
            int result = mcalc.multiply(11, 0);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void ExtremeMultiplying()
        {
            CalculatorLibrary.MultiplyingCalculator mcalc = new CalculatorLibrary.MultiplyingCalculator();
            int result = mcalc.multiply(int.MaxValue, 0);
            Assert.AreEqual(0, result);

            result = mcalc.multiply(int.MinValue, 0);
            Assert.AreEqual(0, result);

            result = mcalc.multiply(int.MinValue, int.MaxValue);
            Assert.AreEqual(int.MinValue, result);

            result = mcalc.multiply(int.MinValue, -1);
            Assert.AreEqual(int.MinValue, result);
        }
    }
}
