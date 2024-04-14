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
            Data.BallRepository TestBallRepository = new Data.BallRepository();
            Data.Ball ball1 = new Data.Ball(1.0, 1.0);
            Data.Ball ball2 = new Data.Ball(2.0, 2.0);
            Data.Ball ball3 = new Data.Ball(3.0, 3.0);
            TestBallRepository.Add(ball1);
            TestBallRepository.Add(ball2);
            TestBallRepository.Add(ball3);
            List<Data.Ball> balls = TestBallRepository.GetAll().OfType<Data.Ball>().ToList();
            Assert.AreEqual(3, balls.Count);
            TestBallRepository.Remove(ball3);
            balls = TestBallRepository.GetAll().OfType<Data.Ball>().ToList();
            Assert.AreEqual(2, balls.Count);
        }
        [TestMethod]
        public void CheckDisposing()
        {
            Data.BallRepository TestBallRepository = new Data.BallRepository();
            Data.Ball ball1 = new Data.Ball(1.0, 1.0);
            TestBallRepository.Add(ball1);
            TestBallRepository.Dispose();
            List<Data.Ball> balls = TestBallRepository.GetAll().OfType<Data.Ball>().ToList();
            Assert.AreEqual(0, balls.Count);
        }
    }
}
