using System.Windows.Input;
using ViewModel.Command;
using Model;
using System.Collections.ObjectModel;
using Logic;

namespace ViewModel
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


            SetCommand = new RelayCommand(() => PrepareGame());
            StartCommand = new RelayCommand(() => Background());
            AddCommand = new RelayCommand(() => AddBalls());
            SubtractCommand = new RelayCommand(() => SubtractBalls());

            //_coordinates.Add(new Point(0, 0));
            //_coordinates.Add(new Point(10, 10));
            //_coordinates.Add(new Point(110, 110));
        }

        public void PrepareGame()
        {
            _coordinates.Clear();
            for (int i = 0; i < _number; i++)
            {
                _coordinates.Add(_model.CreatePoint(10*i, 10*i));
            }
            _model.startGame(_number, _coordinates);
        }
        public void Background()
        {
            Thread.Sleep(50);
            for (int j = 0; j < 10; j++)
            {
                _model.move();
            }
            Coordinates = _coordinates;
        }
        private int _number;
        public int Number
        {
            get => _number;
            set
            {
                if (value == _number) return;
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
                //if (value == _coordinates) return;
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



        public ICommand SetCommand { get; set; }
        public ICommand StartCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand SubtractCommand { get; set; }
    }
}
