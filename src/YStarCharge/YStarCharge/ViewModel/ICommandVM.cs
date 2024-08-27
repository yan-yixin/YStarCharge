using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace YStarCharge.ViewModel
{
    public interface ICommandVM
    {
        ICommand Add { get; }

        ICommand Edit { get; }

        ICommand Delete { get; }

        ICommand Export { get; }

        ICommand Query { get; }

        ICommand Refresh { get; }
    }
}
