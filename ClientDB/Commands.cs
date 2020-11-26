using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientDB
{
    public class Commands : ICommand
    {
        public delegate void Method();
        Method method;

        public Commands(Method method)
        {
            this.method = method;
        }

        public delegate void Method2(object p);
        Method2 method2;

        public Commands(Method2 method2)
        {
            this.method2 = method2;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter == null && method == null)
                return;
            else if (parameter == null)
                method();
            else
                method2(parameter);
        }
    }
}
