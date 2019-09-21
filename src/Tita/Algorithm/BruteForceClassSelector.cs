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
                countTotal += i.SelectCount;
            }
            groupRoot.SelectCount = countTotal;

            var root = PreProcess(groupRoot);



            var groups = CreateGroupClasses(root);
            

            return null;
        }

        private List<ScheduleTable> resultTable;

        private List<List<ScheduleMid>> CreateGroupClasses(ClassGroup groupRoot)
        {
            List<List<ScheduleMid>> r = new List<List<ScheduleMid>>();

            foreach (ClassGroup i in groupRoot.Children)
            {
                cur = new ScheduleMid();
                result = new List<ScheduleMid>();

                SelectClasses(i, i.SelectCount);
                r.Add(result);
            }

            return r;
        }

        private class ScheduleMid : ICloneable
        {
            public List<ClassInfoPlus> infos { get; set; }
            public TimeMap timemap { get; set; }

            public ScheduleMid()
            {
                infos = new List<ClassInfoPlus>();
                timemap = new TimeMap();
            }

            public object Clone()
            {
                ScheduleMid obj = new ScheduleMid();
                obj.infos.AddRange(infos);

                return obj;
            }
        }


        ScheduleMid cur;
        List<ScheduleMid> result;
        private void SelectClasses(ClassGroup group, int cnt , int p = 0)
        {
            if (cnt == 0)
            {
                result.Add(cur.Clone() as ScheduleMid);
                return;
            }
            if (p >= group.CountChildren())
            {
                return;
            }

            for (int i = p; i < group.CountChildren() - cnt + 1; i++)
            {
                foreach (ClassInfoPlus h in (group.Children[p] as ClassGroup).Children)
                {
                    if (!cur.timemap.IsOverlap(h.Info.Time))
                    {
                        cur.timemap.Set(h.Info.Time);
                        SelectClasses(group, cnt - 1, p + 1);
                        cur.timemap.Unset(h.Info.Time);
                        SelectClasses(group, cnt, p + 1);
                    }
                }
            }
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
