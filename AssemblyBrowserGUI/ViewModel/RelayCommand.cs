using System;
using System.Windows.Input;

namespace AssemblyBrowserGUI.ViewModel
{
    /// <summary>
    /// A generic implementation of RelayCommand
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class RelayCommand<T> : ICommand
    {
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _action;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<T> action, Predicate<T> canExecute = null)
        {
            _canExecute = canExecute;
            _action = action ?? throw new ArgumentNullException("execute");
        }

        public bool CanExecute(object parameter)
        {
            return (_canExecute == null || _canExecute((T)parameter));
        }

        public void Execute(object parameter)
        {
            _action((T)parameter);
        }
    }
}
