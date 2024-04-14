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
            Number = 7;
            AddButton = new IncreaseCommand(ref Number);
            MinusButton = new DecreaseCommand(ref Number);
        }
        public static int Number;
        public int BallNumber { get
            {
                return Number;
            }
         }
        public ICommand AddButton { get; set; }
        public ICommand MinusButton { get; set; }
        public ICommand StartCommand { get; set; }
    }
}
