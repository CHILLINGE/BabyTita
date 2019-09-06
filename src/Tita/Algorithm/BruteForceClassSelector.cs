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
            int countTotal = 0;
            foreach (ClassGroup i in groupRoot.Children)
            {
                
            }

            var root = PreProcess(groupRoot);



            Func(root);

            return null;
        }

        private List<ScheduleTable> resultTable;

        private void Func(ClassGroup group)
        {
            
        }

        private void IsCollide()
        {

        }

        private ClassGroup PreProcess(ClassGroup ori)
        {
            ClassGroup subgroup = new ClassGroup();
            ClassGroup root = new ClassGroup();

            foreach (ClassGroup child in ori.Children)
            {
                child.Children.Sort((a, b) => {
                    return string.Compare((a as ClassInfoPlus).Info.Name, (b as ClassInfoPlus).Info.Name);
                });
            } 

            string namelast = "";
            int i = 0;
            foreach (ClassGroup group in ori.Children)
            {
                while (i < group.CountChildren())
                {
                    var cur = group.Children[i] as ClassInfoPlus;

                    if (cur.Info.Name != namelast)
                    {
                        if (subgroup.CountChildren() > 0)
                        {
                            root.AddGroup(subgroup);
                            subgroup = new ClassGroup();
                        }

                    }

                    subgroup.AddGroup(group.Children[i]);
                    namelast = cur.Info.Name;
                    i++;
                }

                if (subgroup.CountChildren() > 0)
                {
                    root.AddGroup(subgroup);
                }
            }

            return root;
            
            
        }
    }
}
