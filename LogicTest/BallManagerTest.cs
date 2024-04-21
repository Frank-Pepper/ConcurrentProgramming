using Logic;
using NSubstitute;

namespace LogicTest
{
    [TestClass]
    public class BallManagerTest
    {
        [TestMethod]
        public void CheckCreateMethod()
        {
            int i = 0;
            var TestBallRepository = Substitute.For<Data.IBallRepository>();
            TestBallRepository.When(x => x.Add(Arg.Any<Data.IBall>())).Do(x => i++);
            var TestBallManager = ILogicAPI.GetBallManager(TestBallRepository);
            var balls = new List<ILogicBallEvent>();
            for(int j = 0; j < 5; j++)
            {
                balls.Add(ILogicAPI.GetLogicBallEventSubOnly(null));
            }
            TestBallManager.Create(5, 100, 100, balls);
            Assert.AreEqual(5, i);
        }
    }
}