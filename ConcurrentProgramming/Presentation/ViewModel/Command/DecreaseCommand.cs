using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.ViewModel.Command
{
    internal class DecreaseCommand : ICommand
    {
        private int _value;
        public DecreaseCommand(ref int value)
        {
            _value = value;
        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (_value > 0)
            {
                _value--;
            }
        }
    }
}
