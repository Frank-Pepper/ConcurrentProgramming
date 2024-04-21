namespace DataTest
{
    [TestClass]
    public class BallTest
    {
        [TestMethod]
        public void CheckConstructing()
        {
            var TestBall = Data.IDataAPI.GetBall(1.0, 2.0, 3.0, 4.0, 5.0, null);
            Assert.IsNotNull(TestBall);
            Tuple<Double, Double> coordinates = TestBall.GetPosition();
            Assert.AreEqual(coordinates.Item1, 2.0);
            Assert.AreEqual(coordinates.Item2, 3.0);
            Tuple<Double, Double> velocity = TestBall.GetVelocity();
            Assert.AreEqual(velocity.Item1, 4.0);
            Assert.AreEqual(velocity.Item2, 5.0);
        }
    }
}
