using Logic;
using Data;
using System.Numerics;
using System.Diagnostics;

namespace LogicTest
{
    internal class TestDataAPI : IDataAPI
    {
        public int GetBallCalls = 0;
        public IBall GetBall(int r, int mass, int id, Vector2 pos, Vector2 sped)
        {
            GetBallCalls++;
            return new TestBall(r, mass, id, pos, sped);
        }
        public ITable GetTable(int width, int height)
        {
            return new TestTable(width, height);
        }
    }
    internal class TestTable : ITable
    {
        private readonly int _width;
        private readonly int _height;
        public TestTable(int width, int height)
        {
            _width = width;
            _height = height;
        }
        public override int GetRectangleWidth()
        {
            return _width;
        }
        public override int GetRectangleHeight()
        {
            return _height;
        }
    }
    internal class TestBall : IBall
    {
        private int R { get; }
        private int Mass { get; }
        private int Id { get; }
        private Vector2 Position { get; set; }
        private Vector2 Speed { get; set; }
        public override event EventHandler<EventArgs>? ChangedPosition;
        public TestBall(int r, int mass, int id, Vector2 pos, Vector2 sped)
        {
            R = r;
            Mass = mass;
            Id = id;
            Position = pos;
            Speed = sped;
        }
        public override Vector2 GetPosition()
        {
            return Position;
        }
        public override Vector2 GetVelocity()
        {
            return Speed;
        }
        public override int GetId()
        {
            return Id;
        }
        public override int GetR()
        {
            return R;
        }
        public override int GetM()
        {
            return Mass;
        }
        public override void SetVelocity(Vector2 sped)
        {
            Speed = sped;
        }
        public override void StartMoving()
        {
            return;
        }
        public override void Move()
        {
            return;
        }
        public override void CheckPosition()
        {
            return;
        }
        public override void Dispose()
        {
            this.Dispose();
        }
    }
    internal class TestLogicBallEvent : ILogicBallEvent
    {
        public override Vector2 Position { get; set; }
        public override Vector2 Speed { get; set; }
        private readonly Action<Vector2>? _subscriber;
        public TestLogicBallEvent(Vector2 pos, Action<Vector2>? subscriber)
        {
            Position = pos;
            _subscriber = subscriber;
        }
        public override void SetValues(Object s, EventArgs e)
        {
            IBall ball = (IBall)s;
            Position = ball.GetPosition();
            Speed = ball.GetVelocity();
            _subscriber?.Invoke(Position);
        }

        public override void Dispose()
        {
            Debug.WriteLine("HEHE logika here");
        }
    }
    //TESTS

    [TestClass]
    public class BallManagerTest
    {
        [TestMethod]
        public void CheckManagerCreatingGame()
        {
            var TestDataAPI = new TestDataAPI();
            var TestBallManager = ILogicAPI.GetBallManager(100, 200, TestDataAPI);
            List<ILogicBallEvent> logicBallEvents = new();
            for (int i = 0; i < 5; i++)
            {
                logicBallEvents.Add(new TestLogicBallEvent(new Vector2(1.0f, 1.0f), null));
            }
            TestBallManager.Create(5, 1, 2, logicBallEvents);
            Assert.AreEqual(TestDataAPI.GetBallCalls, 5);
        }
    }
}