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
    /// MiniScheduleList.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MiniScheduleListControl : UserControl
    {
        public List<ScheduleTable> Results { get; set; }
        public event EventHandler<ScheduleTable> ClickSchedule;
        public void Update()
        {
            //foreach(ClassInfo item in Scheduledata.ClassData)
            //{
            //    Scheduledata = new MiniSchedule();

            //    Scheduledata.UpDate();

            //    Scheduledata.VerticalAlignment = VerticalAlignment.Center;
            //    Scheduledata.HorizontalAlignment = HorizontalAlignment.Stretch;
            //    Scheduledata.MaxHeight = 300;
            //    Scheduledata.Margin = new Thickness(5);
            //    MiniScroll.Children.Add(Scheduledata);
            //}

            MiniScroll.Children.Clear();
            foreach (ScheduleTable schedule in Results)
            {
                var control = new MiniSchedule();

                var r = from c in schedule.ClassList
                        select c.Info;
                control.ClassData = new List<ClassInfo>(r);

                var btn = new Button();
                btn.Content = control;

                btn.Click += (sender, e) =>
                {
                    ClickSchedule?.Invoke(this, schedule);
                };

                MiniScroll.Children.Add(btn);

                control.UpDate();
            }
        }
  
        public MiniScheduleListControl()
        {
            InitializeComponent();
        }
    }
}
