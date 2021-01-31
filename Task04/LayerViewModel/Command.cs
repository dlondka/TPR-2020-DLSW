using System;
using System.Windows.Input;

namespace LayerViewModel
{
    public class Command : ICommand
    {
        private Action Action;

        public event EventHandler CanExecuteChanged;

        public Command(Action action)
        {
            Action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Action();
        }
    }
}
