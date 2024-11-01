﻿using Newtonsoft.Json;
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
        private readonly ConcurrentQueue<BallData> _ballsDataQueue;
        private readonly JArray _jLogArray = new JArray();
        private readonly int _queueSize = 25;
        private readonly Object lockObject = new Object();
        private CancellationTokenSource _queChange = new CancellationTokenSource();
        private bool _queOverflow = false;
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
            Task.Run(CollectData);
        }

        public void AddBallToQueue(BallData ball)
        {
            lock(lockObject)
            {
                if (_ballsDataQueue.Count < _queueSize)
                {
                    _ballsDataQueue.Enqueue(ball);
                    _queChange.Cancel();
                }
                else
                {
                    _queOverflow = true;
                }
            }
        }

        private async void CollectData()
        {
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
                        if (_queOverflow)
                        {
                            JObject errorMessage = new JObject
                            {
                                ["Error"] = "Buffer size is too small skipped logging"
                            };
                            _jLogArray.Add(errorMessage);
                            lock (lockObject)
                            {
                                _queOverflow = false;
                            }
                        }
                    }
                    if (_jLogArray.Count > _queueSize / 2)
                    {
                        SaveToFile();
                    }
                }
                await Task.Delay(Timeout.Infinite, _queChange.Token).ContinueWith(_ => { });

                if (_queChange.IsCancellationRequested)
                {
                    _queChange = new CancellationTokenSource();
                }
            }
        }
        private async void SaveToFile()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(JsonConvert.SerializeObject(_jLogArray, Formatting.Indented));
            _jLogArray.Clear();
            await File.AppendAllTextAsync(_logFilePath, stringBuilder.ToString(), Encoding.UTF8);
            stringBuilder.Clear();
        }
    }
}