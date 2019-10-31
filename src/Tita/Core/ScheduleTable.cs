using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tita.Algorithm;

namespace Tita
{
    public class ScheduleTable
    {
        public int PreferenceSum { get; set; }


        /// <summary>
        /// 과목을 추가하는 리스트
        /// </summary>
        public List<ClassInfoPlus> ClassList { get; set; }
        

        public ScheduleTable()
        {
            ClassList = new List<ClassInfoPlus>();
        }

        /// <summary>
        /// 과목 배열에 과목을 추가하는 매소드
        /// </summary>
        /// <param name="target">타겟</param>
        public void ClassAddList(ClassInfoPlus target)
        {
            ClassList.Add(target); 
        }

    }
}
