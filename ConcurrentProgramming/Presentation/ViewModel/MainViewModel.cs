using System.Windows.Input;
using Presentation.ViewModel.Command;
using Presentation.Model;
using System.Collections.ObjectModel;
using Logic;

namespace Presentation.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        private AbstractModel _model;
        public MainViewModel()
        {
            var model = AbstractModel.GetModel();
            _ballRadius = model.BallRadius;
            _rectHeigth = model.RectangleHeigth;
            _rectWidth = model.RectangleWidth;
            _model = model;

            var manager = IAbstractLogicAPI.GetBallManager();
            _coordinates = new ObservableCollection<Point>();


            SetCommand = new RelayCommand(() => PrepareGame());
            StartCommand = new RelayCommand(() => Background());

            //_coordinates.Add(new Point(0, 0));
            //_coordinates.Add(new Point(10, 10));
            //_coordinates.Add(new Point(110, 110));
        }

        public void PrepareGame()
        {
            _coordinates.Clear();
            _coordinates = [];
            for (int i = 0; i < _number; i++)
            {
                _coordinates.Add(new Point(10*i, 10*i));
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
        private ObservableCollection<Point> _coordinates;
        public ObservableCollection<Point> Coordinates
        {
            get => _coordinates;
            set
            {
                //if (value == _coordinates) return;
                RaisePropertyChanged();
            }
        }



        public ICommand SetCommand { get; set; }
        public ICommand StartCommand { get; set; }
    }
}
