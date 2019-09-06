using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tita
{
    public class ClassGroup : IGroupable
    {
        public List<IGroupable> Children { get; }
        public int SelectCount { get; set; }

        public ClassGroup()
        {
            Children = new List<IGroupable>();
            SelectCount = 1;

        }

        /// <summary>
        /// 부모의 리스트에 자식 참조변수 값을 넣어준다.
        /// </summary>
        /// <param name="data"></param>
        public void AddGroup(IGroupable data)
        { 
            Children.Add(data);
        }

        /// <summary>
        /// 자식노드가 group인지 data인지 판단
        /// </summary>
        public bool IsitGroup(IGroupable what)
        {
            if (what is ClassGroup) return true;
            else return false;
        }

        public bool IsLeafNode()
        {
            if (this.CountChildren() == 0) return true;
            else return false;
        }

        public int CountChildren()
        {
            return Children.Count;
        }
    }
}
