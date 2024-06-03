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
    internal sealed class Logger
    {
        private readonly string _logFilePath;
        private readonly BlockingCollection<BallData> _ballsDataCollection;
        private readonly JArray _jLogArray = new JArray();
        private readonly int _queueSize = 25;
        private bool _queOverflow = false;

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
            _ballsDataCollection = new BlockingCollection<BallData>(_queueSize);

            using (FileStream LogFile = File.Create(_logFilePath))
            {
                LogFile.Close();
            }

            Task.Run(CollectData);
        }

        public void AddBallToQueue(BallData ball)
        {
            if (!_ballsDataCollection.TryAdd(ball))
            {
                _queOverflow = true;
            }
        }

        private void CollectData()
        {
            while (true)
            {
                if (!_ballsDataCollection.IsCompleted)
                {
                    while (_ballsDataCollection.TryTake(out BallData serilizedObject, Timeout.Infinite))
                    {
                        JObject jsonObject = JObject.FromObject(serilizedObject);
                        jsonObject["Position"] = serilizedObject.Position.ToString();
                        jsonObject["Speed"] = serilizedObject.Speed.ToString();
                        _jLogArray.Add(jsonObject);
                        if (_queOverflow)
                        {
                            JObject errorMessage = new JObject
                            {
                                ["Error"] = "Buffer size is too small skipped logging"
                            };
                            _jLogArray.Add(errorMessage);
                            _queOverflow = false;
                        }
                        if (_jLogArray.Count > _queueSize / 2)
                        {
                            SaveToFile();
                        }
                    }
                }
            }
        }
        private async void SaveToFile()
        {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(JsonConvert.SerializeObject(_jLogArray, Formatting.Indented));
                _jLogArray.Clear();
                await File.AppendAllTextAsync(_logFilePath, stringBuilder.ToString());
                stringBuilder.Clear();
        }   
    }
}
