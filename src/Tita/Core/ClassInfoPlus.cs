using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tita
{
    public class ClassInfoPlus : IGroupable
    {
        /// <summary>
        /// 선호도
        /// </summary>
        public int Preference { get; set; }

        /// <summary>
        /// 해당하는 과목 정보
        /// </summary>
        public ClassInfo Info { get; set; }
        /// <summary>
        /// 해당 과목이 속해있는 그룹의 부모주소
        /// </summary>
        public ClassGroup Parent { get; set; }

        public ClassInfoPlus(ClassInfo info)
        {
            this.Info = info;
        }

        public ClassInfoPlus(ClassGroup Parent)
        {
            this.Parent = Parent;
        }

        public ClassInfoPlus(ClassInfo info, ClassGroup Parent)
        {
            this.Info = info;
            this.Parent = Parent;
        }

        public bool IsLeapNode()
        {
            return true;
        }

    }
}
