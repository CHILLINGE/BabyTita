using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tita
{
    class ClassGroup : IGroupable
    {
        public List<IGroupable> Children { get; }

        public ClassGroup()
        {
            Children = new List<IGroupable>();
            
        }

    }
}
