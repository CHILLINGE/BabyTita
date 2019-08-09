using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tita
{
    public interface INavigable
    {
        event EventHandler<NavigateEventArgs> OnNavigate;

        void Navigated(string fromEndpoint, object data);
    }
}
