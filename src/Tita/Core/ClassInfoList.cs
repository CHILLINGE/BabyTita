using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tita
{
    public class ClassInfoList
    {

        public Dictionary<string, List<ClassInfo>> Groups { get; set; }

        public ClassInfoList()
        {
            Groups = new Dictionary<string, List<ClassInfo>>();
        }

        public List<ClassInfo> AllList()
        {
            List<ClassInfo> result = new List<ClassInfo>();
            foreach (var i in Groups)
            {
                result.AddRange(i.Value);
            }
            return result;
        }


    }
}
