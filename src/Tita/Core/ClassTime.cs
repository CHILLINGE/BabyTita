using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tita
{
    public class ClassTime
    {
        public List<ClassTimeItem> Items { get; private set; }

        public ClassTime()
        {
            Items = new List<ClassTimeItem>();
        }

        public ClassTime(List<ClassTimeItem> timelist)
        {
            Items = timelist;
        }

        public ClassTime(params ClassTimeItem[] timeitems) : this()
        {
            foreach (var i in timeitems) 
            {
                Items.Add(i);
            }
        }

    }
}
