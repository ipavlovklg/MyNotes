using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ivi.UI {
    class DelegateCommand : DelegateCommandBase<object> {
        public DelegateCommand(Action executeCallback, Func<bool> canExecuteCallback = null)
            : base(o => executeCallback(), o => canExecuteCallback == null ? true : canExecuteCallback.Invoke()) {
        }
    }
    class DelegateCommandBase<T> : ICommand {
        Action<T> execute;
        Func<T, bool> canExecute;
        public DelegateCommandBase(Action<T> executeCallback, Func<T, bool> canExecuteCallback = null) {
            execute = executeCallback;
            canExecute = canExecuteCallback;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) {
            return canExecute == null ? true : canExecute.Invoke((T)parameter);
        }
        public void Execute(object parameter) {
            execute?.Invoke((T)parameter);
        }
    }
}
