﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel.Command
{
    internal class RelayCommand : ICommand
    {
        public RelayCommand(Action execute, Func<bool>? canExecute = null)
        {
            m_Execute = execute ?? throw new ArgumentNullException(nameof(execute));
            m_CanExecute = canExecute;
        }
        public bool CanExecute(object? parameter)
        {
            if (m_CanExecute == null)
                return true;
            if (parameter == null)
                return m_CanExecute();
            return m_CanExecute();
        }
        public virtual void Execute(object? parameter)
        {
            m_Execute();
        }
        public event EventHandler? CanExecuteChanged;
        internal void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        private readonly Action m_Execute;
        private readonly Func<bool>? m_CanExecute;
    }
}