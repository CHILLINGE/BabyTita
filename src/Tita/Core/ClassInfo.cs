using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tita
{
    /// <summary>
    /// 과목 정보를 나타낸다
    /// </summary>
    public class ClassInfo
    {
        /// <summary>
        /// ClassInfo 객체의 총 개수
        /// </summary>
        static int instanceCount = 0;

        private int _id;
        public int ID { get { return _id; } }

        /// <summary>
        /// 과목명
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 분반
        /// </summary>
        public int Division { get; set; }

        /// <summary>
        /// 시간
        /// </summary>
        public ClassTime Time { get; set; }
        
        /// <summary>
        /// 이수학점
        /// </summary>
        public int Credit { get; set; }

        /// <summary>
        /// 교수
        /// </summary>
        public string Professor { get; set; }

        /// <summary>
        /// 전공
        /// </summary>
        public string Major { get; set; }


        public ClassInfo()
        {
            _id = instanceCount++;
            Time = new ClassTime();
            
        }

        public ClassInfo(string name, int division, ClassTime time) : this()
        {
            Name = name;
            Division = division;
            Time = time;
        }

        public ClassInfo(string name, int division, ClassTime time, string professor, int credit) : this(name, division, time)
        {
            Professor = professor;
            Credit = credit;
        }
    }
}
