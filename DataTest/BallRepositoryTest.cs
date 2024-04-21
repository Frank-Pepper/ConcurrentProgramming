namespace DataTest
{
    [TestClass]
    public class BallRepositoryTest
    {
        [TestMethod]
        public void CheckAddingAndRemoving()
        {
            var TestBallRepository = Data.IDataAPI.GetBallRepository();
            var ball1 = Data.IDataAPI.GetBall(1.0, 1.0, 1.0, 1.0, 1.0);
            var ball2 = Data.IDataAPI.GetBall(2.0, 2.0, 2.0, 2.0, 2.0);
            var ball3 = Data.IDataAPI.GetBall(2.0, 2.0, 2.0, 2.0, 2.0);
            TestBallRepository.Add(ball1);
            TestBallRepository.Add(ball2);
            TestBallRepository.Add(ball3);

            List<Data.IBall> balls = TestBallRepository.GetAll();
            Assert.AreEqual(3, balls.Count);
            TestBallRepository.Remove(ball3);
            balls = TestBallRepository.GetAll();
            Assert.AreEqual(2, balls.Count);
        }
        [TestMethod]
        public void CheckDisposing()
        {
            var TestBallRepository = Data.IDataAPI.GetBallRepository();
            var ball1 = Data.IDataAPI.GetBall(1.0, 1.0, 1.0, 1.0, 1.0);
            TestBallRepository.Add(ball1);
            TestBallRepository.Dispose();
            List<Data.IBall> balls = TestBallRepository.GetAll();
            Assert.AreEqual(0, balls.Count);
        }
    }
}
