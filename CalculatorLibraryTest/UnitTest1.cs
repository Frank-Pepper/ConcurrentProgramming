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
            Assert.IsTrue(true);
        }
    }
}
