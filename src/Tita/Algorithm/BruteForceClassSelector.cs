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


            getCombinationCurrent = new List<ScheduleMid>();
            getCombinationResult = new List<List<ScheduleMid>>();
            GetCombinations(groups);

            List<ScheduleTable> ret = new List<ScheduleTable>();
            foreach (var i in getCombinationResult)
            {
                var tmp = new ScheduleTable();
                foreach (var j in i)
                {
                    foreach (var k in j.infos)
                    {
                        tmp.ClassAddList(k);
                    }
                }
                ret.Add(tmp);
            }

            return ret;
        }

        List<ScheduleMid> getCombinationCurrent;
        List<List<ScheduleMid>> getCombinationResult;
        private void GetCombinations(List<List<ScheduleMid>> groups, int p = 0)
        {
            if (p == groups.Count)
            {

                getCombinationResult.Add(new List<ScheduleMid>(getCombinationCurrent));
                return ;
            }
            
            for (int i = 0; i < groups[p].Count; i++)
            {
                // 여기에 조건
                bool isPossible = true;
                foreach (var mid in getCombinationCurrent)
                {
                    if (mid.timemap.IsOverlap(groups[p][i].timemap))
                    {
                        isPossible = false;
                        break;
                    }
                }

                if (isPossible)
                {
                    getCombinationCurrent.Add(groups[p][i]);
                    GetCombinations(groups, p + 1);
                    getCombinationCurrent.RemoveAt(getCombinationCurrent.Count - 1);
                }
                
            }
            
            return;
        }
        
        /// <summary>
        /// 각 그룹별로 가능한 후보 리스트를 뽑는 함수
        /// </summary>
        /// <param name="groupRoot"></param>
        /// <returns></returns>
        private List<List<ScheduleMid>> CreateGroupClasses(ClassGroup groupRoot)
        {
            List<List<ScheduleMid>> r = new List<List<ScheduleMid>>();

            foreach (ClassGroup i in groupRoot.Children)
            {
                selectClassesCurrent = new ScheduleMid();
                selectClassesResult = new List<ScheduleMid>();

                SelectClasses(i, i.SelectCount);
                r.Add(selectClassesResult);
            }

            return r;
        }

        /// <summary>
        /// ClassInfoPlus의 리스트 + 시간 데이터가 저장된 TimeMap
        /// </summary>
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


        ScheduleMid selectClassesCurrent;
        List<ScheduleMid> selectClassesResult;

        /// <summary>
        /// 하나의 그룹에서 과목들의 가능한 조합들을 구하는 재귀함수
        /// </summary>
        /// <param name="group">구할 그룹</param>
        /// <param name="cnt">남은 개수</param>
        /// <param name="p">현재 위치</param>
        private void SelectClasses(ClassGroup group, int cnt , int p = 0)
        {
            if (cnt == 0)
            {
                selectClassesResult.Add(selectClassesCurrent.Clone() as ScheduleMid);
                return;
            }
            if (p >= group.CountChildren())
            {
                return;
            }

            //for (int i = p; i < group.CountChildren() - cnt + 1; i++)
            //{
                foreach (ClassInfoPlus h in ((ClassGroup)group.Children[p]).Children)
                {
                    if (!selectClassesCurrent.timemap.IsOverlap(h.Info.Time))
                    {
                        selectClassesCurrent.timemap.Set(h.Info.Time);
                        selectClassesCurrent.infos.Add(h);
                        SelectClasses(group, cnt - 1, p + 1);
                        selectClassesCurrent.timemap.Unset(h.Info.Time);
                        selectClassesCurrent.infos.RemoveAt(selectClassesCurrent.infos.Count - 1);
                        SelectClasses(group, cnt, p + 1);
                    }
                }
            //}
        }

        private ClassGroup PreProcess(ClassGroup ori)
        {
            ClassGroup subgroup = new ClassGroup();
            ClassGroup root = new ClassGroup();
            ClassGroup tmp;

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
                tmp = new ClassGroup();
                while (i < group.CountChildren())
                {
                    var cur = group.Children[i] as ClassInfoPlus;

                    if (cur.Info.Name != namelast)
                    {
                        if (subgroup.CountChildren() > 0)
                        {
                            tmp.AddGroup(subgroup);
                            subgroup = new ClassGroup();
                        }

                    }

                    subgroup.AddGroup(group.Children[i]);
                    namelast = cur.Info.Name;
                    i++;
                }

                if (subgroup.CountChildren() > 0)
                {
                    tmp.AddGroup(subgroup);
                }
                root.AddGroup(tmp);
            }

            return root;
            
            
        }
    }
}
