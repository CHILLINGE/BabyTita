using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tita.Algorithm
{
    public class BruteForceClassSelector : IClassSelector
    {
        public List<ScheduleTable> Calculate(ClassGroup groupRoot)
        {
            root = groupRoot;

            return null;
        }

        private ClassGroup root;
        private List<ScheduleTable> resultTable;

        private void Func(IGroupable group)
        {
            
        }

        private void IsCollide()
        {

        }

        private void PreProcess(ClassGroup ori)
        {
            ClassGroup subgroup = new ClassGroup();
            root = new ClassGroup();

            ori.Children.Sort();



            for (int i = 0; i < ori.Children.Count - 1; i++)
            {
                
                if ((ori.Children[i] as ClassInfoPlus)?.Info.Name 
                    == (ori.Children[i + 1] as ClassInfoPlus)?.Info.Name)
                {
                    if ((ori.Children[i] as ClassInfoPlus)?.Info.Division 
                        != (ori.Children[i + 1] as ClassInfoPlus)?.Info.Division)
                    {
                        subgroup.Children.Add(ori.Children[i]);
                        continue;
                    }
                }

                root.Children.Add(subgroup);
                subgroup = new ClassGroup();

            }
        }
    }
}
