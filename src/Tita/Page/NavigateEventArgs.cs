using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tita
{
    public class NavigateEventArgs
    {
        public string TargetEndpoint { get; set; }
        public object Data { get; set; }

        public NavigateEventArgs()
        {
            TargetEndpoint = "";
            Data = null;
        }

        public NavigateEventArgs(string targetEndpoint)
        {
            TargetEndpoint = targetEndpoint;
        }
    }
}
