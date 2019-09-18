using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tita.Algorithm
{
    public class TimeMap
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
            map = new int[1440 / ClassTimeItem.periodSpan, 7];
            
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

        
    }
}
