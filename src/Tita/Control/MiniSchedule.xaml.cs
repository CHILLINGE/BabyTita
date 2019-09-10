using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tita
{
    /// <summary>
    /// MiniSchedule.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MiniSchedule : UserControl
    {
        public List<ClassInfo> ClassData { get; set; }
        private List<ScheduleBlockControl> ScheduleBlockControls { get; set; }
        public void UpDate()
        {
            for (int i = 0; i < ClassData.Count; i++)
            {
                foreach (var item in ClassData[i].Time.Items)
                {

                    ScheduleBlockControl classblock = new ScheduleBlockControl();
                    classblock.BorderBrush=Brushes.White;

                    Grid.SetRow(classblock, item.Start.Hours - 8 - 1);
                    Grid.SetRowSpan(classblock, item.Interval.Hours);

                    switch (item.Day)
                    {
                        case DayOfWeek.Monday:
                            Grid.SetColumn(classblock, 0);
                            break;
                        case DayOfWeek.Tuesday:
                            Grid.SetColumn(classblock, 1);
                            break;
                        case DayOfWeek.Wednesday:
                            Grid.SetColumn(classblock, 2);
                            break;
                        case DayOfWeek.Thursday:
                            Grid.SetColumn(classblock, 3);
                            break;
                        case DayOfWeek.Friday:
                            Grid.SetColumn(classblock, 4);
                            break;
                    }
                    //classblock.Background = Brushes.Aqua;
                    MainGrid.Children.Add(classblock);
                    ScheduleBlockControls.Add(classblock);
                }
            }
        }
        public void Remove()
        {
            ClassData.Clear();
            foreach (ScheduleBlockControl i in ScheduleBlockControls)
            {
                MainGrid.Children.Remove(i);
            }
        }



        public MiniSchedule()
        {
            InitializeComponent();
            ClassData = new List<ClassInfo>();
            ScheduleBlockControls = new List<ScheduleBlockControl>();
        }
    }
}
