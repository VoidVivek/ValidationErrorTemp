using System;
using System.Windows.Input;

namespace WpfApp3
{
    /// <summary>
    /// A BaseCommand that will be used for all the commands needed in the view.
    /// </summary>
    public class BaseCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Predicate<object> canExecute;

        /// <summary>
        /// Constructor.
        /// </summary>
        public BaseCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Check whether the command can be executed
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            bool canExec = true;

            if (canExecute != null)
            {
                canExec = canExecute(parameter);
            }

            return canExec;
        }

        /// <summary>
        /// Execute the command.
        /// </summary>
        public void Execute(object parameter)
        {
            execute(parameter);
        }

        /// <summary>
        /// Event that is triggered when the command changes status.
        /// </summary>
        public event EventHandler CanExecuteChanged;


        /// <summary>
        /// Raise the event if the command changes its state.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            EventHandler handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}