using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OpenWindow.Commands
{
    /// <summary>
    /// A command that executes the supplied action
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private readonly Action<string> _execute;
        private readonly Func<bool> _canExecute;

        /// <summary>
        /// Initialize an instance of RelayCommand
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public RelayCommand(Action<string> execute, Func<bool> canExecute)
        {
            if (execute == null)
                throw new NullReferenceException("The action to execute cannot be null");

            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Initialize an instance of RelayCommand
        /// </summary>
        /// <param name="execute"></param>
        public RelayCommand(Action<string> execute) : this(execute, null)
        {

        }

        /// <summary>
        /// Can the requested action execute?
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }

        /// <summary>
        /// Executes the requested action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _execute.Invoke(parameter.ToString());
        }
    }
}
