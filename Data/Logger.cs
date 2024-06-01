using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Text;

namespace Data
{
    internal sealed class Logger : LoggerApi
    {
        private readonly string _logFilePath;
        private readonly ConcurrentQueue<BallData> _ballsDataQueue;
        private readonly JArray _jLogArray = new JArray();
        private readonly int _queueSize = 100;
        private CancellationTokenSource _queChange = new CancellationTokenSource();
        private bool _saveData;

        private static Logger? _instance = null;
        public static Logger GetInstance()
        {
            _instance ??= new Logger();
            return _instance;
        }
        private Logger()
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
            _logFilePath = Path.Combine(path, "BallsLog.json");
            _ballsDataQueue = new ConcurrentQueue<BallData>();

            using (FileStream LogFile = File.Create(_logFilePath))
            {
                LogFile.Close();
            }

            _saveData = true;
            Task.Run(WriteLogDataToFile);
        }

        public override void AddBallToQueue(BallData ball)
        {
            if (_ballsDataQueue.Count < _queueSize)
            {
                _ballsDataQueue.Enqueue(ball);
                _queChange.Cancel();
            }
        }

        private async void WriteLogDataToFile()
        {
            StringBuilder stringBuilder = new StringBuilder();
            while (_saveData)
            {
                if (!_ballsDataQueue.IsEmpty)
                {
                    while (_ballsDataQueue.TryDequeue(out BallData serilizedObject))
                    {
                        JObject jsonObject = JObject.FromObject(serilizedObject);
                        jsonObject["Position"] = serilizedObject.Position.ToString();
                        jsonObject["Speed"] = serilizedObject.Speed.ToString();
                        _jLogArray.Add(jsonObject);
                    }

                    stringBuilder.Append(JsonConvert.SerializeObject(_jLogArray, Formatting.Indented));
                    _jLogArray.Clear();
                    await File.AppendAllTextAsync(_logFilePath, stringBuilder.ToString());
                    stringBuilder.Clear();
                }
                await Task.Delay(Timeout.Infinite, _queChange.Token).ContinueWith(_ => { });

                if (_queChange.IsCancellationRequested)
                {
                    _queChange = new CancellationTokenSource();
                }
            }
        }
        public override void Dispose()
        {
            _saveData = false;
        }
    }
}
