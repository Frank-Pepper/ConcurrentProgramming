using Logic;
using Data;
using NSubstitute.Core;
using System.Numerics;
using System.Diagnostics;

namespace LogicTest
{
    internal class TestDataAPI : IDataAPI
    {
        public IBall GetBall(int r, Vector2 pos, float vx, float vy, Action<Vector2>? _subscriber = null)
        {
            return new TestBall(r, pos, vx, vy, _subscriber);
        }
    }

    internal class TestBall : IBall 
    {
        private int R;
        private Vector2 Position;
        private Vector2 Speed;
        private Boolean isRunning;
        public override event EventHandler<DataEventArgs>? ChangedPosition;

        private readonly Action<Vector2>? _subscriber;
        public TestBall(int r, Vector2 pos, float vx, float vy, Action<Vector2>? subscriber)
        {
            R = r;
            Position = pos;
            Speed = new Vector2(vx, vy);
            _subscriber = subscriber;
            isRunning = true;
            Task.Run(StartMoving);
        }

        public override void StartMoving()
        {
            while (isRunning)
            {
                Move();
                Thread.Sleep(5);
                Notify();
            }
        }
        private void SetPosition(Vector2 pos)
        {
            Position = pos;
        }

        private void SetVelocity(Vector2 sped)
        {
            Speed = sped;
        }
        public override void Move()
        {
            Position += Speed;
            DataEventArgs args = new DataEventArgs(Position, Speed, SetPosition, SetVelocity, Dispose);
            ChangedPosition?.Invoke(this, args);
        }
        public override void Notify()
        {
            _subscriber?.Invoke(Position);
        }
        public override void Dispose()
        {
            isRunning = false;
            //this.Dispose();
            Debug.WriteLine("HEHE Dispose");
        }
    }

    [TestClass]
    public class BallManagerTest
    {
        [TestMethod]
        public void CheckCreateMethod()
        {
            //int i = 0;
            ////var TestBallRepository = Substitute.For<Data.IBallRepository>();
            //TestBallRepository.When(x => x.Add(Arg.Any<Data.IBall>())).Do(x => i++);
            //var TestBallManager = ILogicAPI.GetBallManager(TestBallRepository);
            //var balls = new List<ILogicBallEvent>();
            //for(int j = 0; j < 5; j++)
            //{
            //    balls.Add(ILogicAPI.GetLogicBallEventSubOnly());
            //}
            //TestBallManager.Create(5, 100, 100, balls);
            //Assert.AreEqual(5, i);
        }
    }
}