using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataTest
{
    [TestClass]
    public class BallTest
    {
        [TestMethod]
        public void CheckConstructing()
        {
            var TestBall = Data.IAbstractDataAPI.GetBall(1.0, 2.0);
            Assert.IsNotNull(TestBall);
            Tuple<Double, Double> coordinates = TestBall.GetPosition();
            Assert.AreEqual(coordinates.Item1, 1.0);
            Assert.AreEqual(coordinates.Item2, 2.0);
            // TODO Checking velocity
        }
    }
}
