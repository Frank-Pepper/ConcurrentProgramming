using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Presentation.ViewModel.Command;

namespace Presentation.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            StartCommand = new StartCommand();
            BallNumber = 7;
        }
        public int BallNumber { get; set; }
        public ICommand StartCommand { get; set; }
    }
}
