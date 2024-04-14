using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataTest
{
    [TestClass]
    public class BallFactoryTest
    {
        [TestMethod]
        public void CheckIfBallsAreProduced()
        {
            Data.BallFactory TestBallFactory = new Data.BallFactory();
            Data.Ball TestBall = (Data.Ball)TestBallFactory.Create(1.0, 2.0);
            Tuple<Double, Double> coordinates = TestBall.GetPosition();
            Assert.AreEqual(coordinates.Item1, 1.0);
            Assert.AreEqual(coordinates.Item2, 2.0);
        }
    }
}
