using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataTest
{
    [TestClass]
    public class BallRepositoryTest
    {
        [TestMethod]
        public void CheckAddingAndRemoving()
        {
            var TestBallRepository = Data.IAbstractDataAPI.GetBallRepository();
            var ball1 = Data.IAbstractDataAPI.GetBall(1.0, 1.0);
            var ball2 = Data.IAbstractDataAPI.GetBall(2.0, 2.0);
            var ball3 = Data.IAbstractDataAPI.GetBall(3.0, 3.0);
            TestBallRepository.Add(ball1);
            TestBallRepository.Add(ball2);
            TestBallRepository.Add(ball3);

            List<Data.IBall> balls = TestBallRepository.GetAll().OfType<Data.IBall>().ToList();
            Assert.AreEqual(3, balls.Count);
            TestBallRepository.Remove(ball3);
            balls = TestBallRepository.GetAll().OfType<Data.IBall>().ToList();
            Assert.AreEqual(2, balls.Count);
        }
        [TestMethod]
        public void CheckDisposing()
        {
            var TestBallRepository = Data.IAbstractDataAPI.GetBallRepository();
            var ball1 = Data.IAbstractDataAPI.GetBall(1.0, 1.0);
            TestBallRepository.Add(ball1);
            TestBallRepository.Dispose();
            List<Data.IBall> balls = TestBallRepository.GetAll().OfType<Data.IBall>().ToList();
            Assert.AreEqual(0, balls.Count);
        }
    }
}
