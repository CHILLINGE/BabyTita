using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tita
{
    /// <summary>
    /// 과목의 시간을 표현한다
    /// </summary>
    public class ClassTimeItem
    {
        /// <summary>
        /// 교시 단위의 시작 시간 (기본값 9:00 AM)
        /// </summary>
        public static TimeSpan periodBase = new TimeSpan(9, 0, 0);


        /// <summary>
        /// 교시 단위의 교시당 간격 (단위:분, 기본값 60분)
        /// </summary>
        public static int periodSpan = 60;


        /// <summary>
        /// 교시를 시간으로 변환
        /// </summary>
        /// <param name="period"></param>
        /// <returns></returns>
        public static TimeSpan PeriodToTimeSpan(int period)
        {
            return periodBase + new TimeSpan(0, periodSpan * (period - 1), 0);
        }

        /// <summary>
        /// 시간을 교시로 변환
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int TimeSpanToPeriod(TimeSpan time)
        {
            TimeSpan span = time - periodBase;
            int total = span.Minutes + span.Hours * 60;
            return total / periodSpan + 1;
        }


        /// <summary>
        /// 과목의 시작 시각
        /// </summary>
        public TimeSpan Start { get; set; }

        /// <summary>
        /// 과목의 종료 시각
        /// </summary>
        public TimeSpan End { get; set; }

        /// <summary>
        /// 과목의 요일
        /// </summary>
        public DayOfWeek Day { get; set; }

        /// <summary>
        /// 과목의 강의시간
        /// </summary>
        public TimeSpan Interval
        {
            get
            {
                return End - Start;
            }
        }


        /// <summary>
        /// 시간을 기반으로 시간 객체를 생성
        /// </summary>
        /// <param name="day">요일</param>
        /// <param name="start">시작 시간</param>
        /// <param name="end">종료 시간</param>
        public ClassTimeItem(DayOfWeek day, TimeSpan start, TimeSpan end)
        {
            if (start > end)
            {
                throw new ArgumentException("Start time is after the end time.");
            }

            Day = day;
            Start = start;
            End = end;

        }

        /// <summary>
        /// 교시를 기반으로 시간 객체를 생성
        /// </summary>
        /// <param name="day">요일</param>
        /// <param name="start">시작 교시</param>
        /// <param name="end">종료 교시</param>
        public ClassTimeItem(DayOfWeek day, int start, int end)
        {
            if (start > end)
            {
                throw new ArgumentException("Start time is after the end time.");
            }

            Day = day;
            Start = PeriodToTimeSpan(start);
            End = PeriodToTimeSpan(end+1);
        }


        /// <summary>
        /// 두 시간이 겹치는지 검사한다
        /// </summary>
        /// <param name="target">검사할 대상</param>
        /// <returns></returns>
        public bool IsOverlapping(ClassTimeItem target)
        {
            if (this.End <= target.Start || target.End <= this.Start)
            {
                return true;
            }
            return false;
        }


        public void FromPeriod(int start, int end)
        {
            Start = PeriodToTimeSpan(start);
            End = PeriodToTimeSpan(end);
            
        }



        private string ConvertDay(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Sunday:
                    return "일";
                case DayOfWeek.Monday:
                    return "월";
                case DayOfWeek.Tuesday:
                    return "화";
                case DayOfWeek.Wednesday:
                    return "수";
                case DayOfWeek.Thursday:
                    return "목";
                case DayOfWeek.Friday:
                    return "금";
                case DayOfWeek.Saturday:
                    return "토";
                default:
                    break;
            }
            return "???";
        }

    }
}
