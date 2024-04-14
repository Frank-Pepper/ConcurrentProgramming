using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.ViewModel.Command
{
    internal class IncreaseCommand : ICommand
    {
        private int _value;
        public IncreaseCommand(ref int value)
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
            _value++;
        }
    }
}
