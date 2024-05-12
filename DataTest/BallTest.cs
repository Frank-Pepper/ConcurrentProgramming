using Data;
using System.Numerics;

namespace DataTest
{
    [TestClass]
    public class BallTest
    {
        [TestMethod]
        public void CheckBallConstructing()
        {
            var TestDataAPI = IDataAPI.GetDataApi();
            var TestBall = TestDataAPI.GetBall(1, 2, 3, new Vector2(4.0f, 5.0f), new Vector2(6.0f, 7.0f));
            Assert.IsNotNull(TestBall);
            Assert.AreEqual(TestBall.GetR(), 1);
            Assert.AreEqual(TestBall.GetM(), 2);
            Assert.AreEqual(TestBall.GetId(), 3);
            Assert.AreEqual(TestBall.GetPosition().X, 4.0f);
            Assert.AreEqual(TestBall.GetPosition().Y, 5.0f);
            Assert.AreEqual(TestBall.GetVelocity().X, 6.0f);
            Assert.AreEqual(TestBall.GetVelocity().Y, 7.0f);
        }

        [TestMethod]
        public void CheckTableConstructing()
        {
            var TestDataAPI = IDataAPI.GetDataApi();
            var TestTable = TestDataAPI.GetTable(100, 200);
            Assert.IsNotNull(TestTable);
            Assert.AreEqual(TestTable.GetRectangleWidth(), 100);
            Assert.AreEqual(TestTable.GetRectangleHeight(), 200);
        }
    }
}
