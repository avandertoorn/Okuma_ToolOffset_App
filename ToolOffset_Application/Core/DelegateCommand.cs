using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ToolOffset_Application.Core
{
    public class DelegateCommand<T> : ICommand
    {
        public DelegateCommand(Action<T> execute) : this(execute, null) { }

        public DelegateCommand(Action<T> execute, Predicate<T> canExecute) : this(execute, canExecute, null) { }

        public DelegateCommand(Action<T> execute, Predicate<T> canExecute, string label)
        {
            _execute = execute;
            _canExecute = canExecute;

            Label = label;
        }

        readonly Action<T> _execute = null;
        readonly Predicate<T> _canExecute = null;

        public string Label { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
    }
}
