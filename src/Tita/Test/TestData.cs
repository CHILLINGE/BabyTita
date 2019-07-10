using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tita
{
    public static class TestData
    {
        public static List<ClassInfo> GetClassInfos()
        {
            return new List<ClassInfo>() {
                new ClassInfo("창의소프트웨어설계", 0, new ClassTime(new ClassTimeItem(DayOfWeek.Monday, 1, 3)), "오재원", 3),
                new ClassInfo("웹프로그래밍", 0, new ClassTime(new ClassTimeItem(DayOfWeek.Wednesday, 1, 2), new ClassTimeItem(DayOfWeek.Tuesday, 1, 1)), "김의찬", 3),
                new ClassInfo("이산수학", 0, new ClassTime(new ClassTimeItem(DayOfWeek.Tuesday, 4, 5)), "황병연", 3)
            };
        }
    }
}
