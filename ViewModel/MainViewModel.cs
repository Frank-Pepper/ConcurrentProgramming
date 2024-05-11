using System.Windows.Input;
using ViewModel.Command;
using Presentation.Model;
using System.Collections.ObjectModel;

namespace Presentation.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private AbstractModel _model;
        public MainViewModel()
        {
            var model = AbstractModel.GetModel();
            _ballRadius = model.BallRadius;
            _rectHeigth = model.RectangleHeigth;
            _rectWidth = model.RectangleWidth;
            _model = model;
            _number = 7;

            _coordinates = new ObservableCollection<IPoint>();

            //SetCommand = new RelayCommand(() => PrepareGame());
            StartCommand = new RelayCommand(() => Background());
            AddCommand = new RelayCommand(() => AddBalls());
            SubtractCommand = new RelayCommand(() => SubtractBalls());
            StopCommand = new RelayCommand(() => StopBalls());
            EndCommand = new RelayCommand(() => EndBalls());
        }

        public void PrepareGame()
        {
            EndBalls();
            for (int i = 0; i < _number; i++)
            {
                _coordinates.Add(AbstractModel.CreatePoint(0, 0));
            }
            _model.StartGame(_number, _coordinates);
        }
        public void Background()
        {
            if (Coordinates.Count == 0)
            {
                PrepareGame();
            }
            //_model.Move();
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
        private ObservableCollection<IPoint> _coordinates;
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
