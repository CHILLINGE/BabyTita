using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tita
{
    public class ClassData : IGroupable
    {
        /// <summary>
        /// 선호도
        /// </summary>
        public int Preference { get; set; }

        /// <summary>
        /// 해당하는 과목 정보
        /// </summary>
        public ClassInfo Info { get; set; }
    }
}
