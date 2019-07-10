using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tita
{
    public class ValueException : Exception
    {
        public ValueException(string msg) : base(msg)
        {

        }
    }
}
