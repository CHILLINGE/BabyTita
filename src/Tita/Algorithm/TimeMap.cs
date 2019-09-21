using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tita.Algorithm
{
    public class TimeMap : ICloneable
    {
        private int[,] map { get; set; }

        public static bool IsOverlap(TimeMap a, TimeMap b)
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 1440 / ClassTimeItem.periodSpan; j++)
                {
                    if (a.map[i,j] > 0 && b.map[i,j] > 0)
                    {
                        return true;
                    }
                }
            }
            

            return false;
        }

        //public static TimeMap operator +(TimeMap a, TimeMap b)
        //{

        //}

        public TimeMap()
        {
            map = new int[7, 1440 / ClassTimeItem.periodSpan];
            
        }

        public bool IsOverlap(TimeMap target)
        {
            return IsOverlap(this, target);
        }

        public bool IsOverlap(ClassTime time)
        {
            var map = new TimeMap();
            map.Set(time);
            return IsOverlap(map);
        }

        public void Set(ClassTime target)
        {
            foreach (var time in target.Items)
            {
                int start = ClassTimeItem.TimeSpanToPeriod(time.Start);
                int end = ClassTimeItem.TimeSpanToPeriod(time.End);

                for (int i = start; i < end; i++)
                {
                    map[(int)time.Day, i] += 1;
                }
            }
        }

        public void Set(TimeMap timemap)
        {
            for (int w = 0; w < 7; w++)
            {
                for (int i = 0; i < 1440 / ClassTimeItem.periodSpan; i++)
                {

                    map[w, i] += timemap.map[w, i];
                }
            }
            
            
        }

        public void Unset(ClassTime target)
        {
            foreach (var time in target.Items)
            {
                int start = ClassTimeItem.TimeSpanToPeriod(time.Start);
                int end = ClassTimeItem.TimeSpanToPeriod(time.End);

                for (int i = start; i < end; i++)
                {
                    map[(int)time.Day, i] -= 1;
                }
            }
        }

        public object Clone()
        {
            var obj = new TimeMap();
            obj.map = map.Clone() as int[,];
            return obj;
        }
    }
}
