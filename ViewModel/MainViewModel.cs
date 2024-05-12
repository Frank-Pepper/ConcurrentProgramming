using System.Windows.Input;
using ViewModel.Command;
using Presentation.Model;
using System.Collections.ObjectModel;

namespace Presentation.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly AbstractModel _model;
        private readonly Random _random = new();
        public MainViewModel()
        {
            var model = AbstractModel.GetModel();
            _ballRadius = model.BallRadius;
            _rectHeigth = model.RectangleHeight;
            _rectWidth = model.RectangleWidth;
            _model = model;
            _number = 7;

            _coordinates = new ObservableCollection<IPoint>();

            //SetCommand = new RelayCommand(() => PrepareGame());
            StartCommand = new RelayCommand(() => StartGame());
            AddCommand = new RelayCommand(() => AddBalls());
            SubtractCommand = new RelayCommand(() => SubtractBalls());
            StopCommand = new RelayCommand(() => StopBalls());
            EndCommand = new RelayCommand(() => EndBalls());
        }

        public void PrepareGame()
        {
            if (Coordinates.Count != Number) {
                EndBalls();
            }
            float xPosition;
            float yPosition;
            float xRightLimit = _rectWidth - BallRadius;
            float yBottomLimit = _rectHeigth - BallRadius;
            
            while (_coordinates.Count < Number)
            {
                xPosition = (float)(xRightLimit * _random.NextDouble());
                yPosition = (float)(yBottomLimit * _random.NextDouble());
                _coordinates.Add(AbstractModel.CreatePoint(xPosition, yPosition));
            }
            _model.StartGame(_number, _coordinates);
        }
        public void StartGame()
        {
            PrepareGame();
            Coordinates = _coordinates;
        }
        private int _number;
        public int Number
        {
            get => _number;
            set
            {
                if (value == _number || value > 42) return;
                _number = value;
                RaisePropertyChanged();
            }
        }
        public int _ballRadius { get; }
        public int _rectWidth { get; }
        public int _rectHeigth { get; }
        public int BallRadius
        {
            get => _ballRadius;
        }
        private readonly ObservableCollection<IPoint> _coordinates;
        public ObservableCollection<IPoint> Coordinates
        {
            get => _coordinates;
            set
            {
                if (value == _coordinates) return;
                RaisePropertyChanged();
            }
        }
        public void AddBalls()
        {
            Number++;
        }
        public void SubtractBalls()
        {
            if (Number == 0) return;
            Number--;
        }
        public void StopBalls()
        {
            _model.StopGame();
        }
        public void EndBalls()
        {
            _model.EndGame();
            _coordinates.Clear();
            Coordinates.Clear();
        }

        //public ICommand SetCommand { get; set; }
        public ICommand StartCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand SubtractCommand { get; set; }
        public ICommand StopCommand { get; set; }
        public ICommand EndCommand { get; set; }
    }
}
