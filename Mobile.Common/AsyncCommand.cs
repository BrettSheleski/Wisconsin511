using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mobile.Common
{
    public class AsyncCommand : Command
    {
        public AsyncCommand(Func<Task> asyncFunc) : base(async () => await asyncFunc())
        {

        }

        public AsyncCommand(Func<Task> asyncFunc, Func<bool> canExecute) : base(async () => await asyncFunc(), canExecute)
        {

        }

    }

    public class AsyncCommand<T> : Command
    {
        public AsyncCommand(Func<T, Task> asyncFunc) : this(asyncFunc, x => true)
        {

        }

        public AsyncCommand(Func<T, Task> asyncFunc, Func<T, bool> canExecuteFunc)
            : base(async x => await asyncFunc((T)x), x => canExecuteFunc((T)x))
        {

        }
    }
}
