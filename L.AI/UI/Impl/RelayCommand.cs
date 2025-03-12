using System;
using System.Windows.Input;

namespace L_AI.UI.Impl
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly Action _command;

        public RelayCommand(Action command)
        {
            _command = command;
        }

        public void Execute(object parameter)
        {
            _command?.Invoke();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
