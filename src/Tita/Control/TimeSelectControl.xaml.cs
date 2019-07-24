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
    /// TimeSelectControl.xaml에 대한 상호 작용 논리
    /// </summary>

    public partial class TimeSelectControl : UserControl
    {
        

        public TimeSelectControl()
        {
            InitializeComponent();


            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    ColorPart colpart = new ColorPart();
                    Grid.SetColumn(colpart, i);
                    Grid.SetRow(colpart, j);
                    colpart.stC = i;
                    colpart.stR = j;
                    timetable.Children.Add(colpart);

                };
            }
        }
        /*
        public ClassTime GetClassTime()
        {
            int start_c = colpart.stC;
            int start_r = colpart.stR;
            int end_r = colpart.endR;
            if (start_c == 1)
                return new ClassTime(new ClassTimeItem(DayOfWeek.Monday, start_r, end_r));
            
            else if (start_c == 2)
                return new ClassTime(new ClassTimeItem(DayOfWeek.Tuesday, start_r, end_r));

            else if (start_c == 3)
            
                return new ClassTime(new ClassTimeItem(DayOfWeek.Wednesday, start_r, end_r));
            
            else if (start_c == 4)
            
                return new ClassTime(new ClassTimeItem(DayOfWeek.Thursday, start_r, end_r));

            
            else if (start_c == 5)
            
                return new ClassTime(new ClassTimeItem(DayOfWeek.Friday, start_r, end_r));

            return null;
        }
        */

        public class ColorPart : Border
        {
            static Brush col = new SolidColorBrush(Color.FromArgb(80, 0xa9, 0xd0, 0xf5));
            static Brush rmcol = new SolidColorBrush(Color.FromArgb(50, 0xFF, 0xFF, 0xFF));
            static Brush pre = new SolidColorBrush(Color.FromArgb(20, 0xa9, 0xd0, 0xf5));

            public int stC { get; set; }
            public int stR { get; set; }
            public int endR { get; set; }
            public ColorPart() : base()
            {
                this.Background = new SolidColorBrush(Color.FromArgb(50, 0xFF, 0xFF, 0xFF));
            }

            protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
            {
                base.OnMouseLeftButtonDown(e);
                if (e.ButtonState == e.LeftButton)
                {
                    this.Background = col;

                    stC = Grid.GetColumn(this);
                    stR = Grid.GetRow(this);
                }
            }
            protected override void OnMouseRightButtonDown(MouseButtonEventArgs e)
            {
                base.OnMouseRightButtonDown(e);
                if (e.ButtonState == e.RightButton)
                {
                    this.Background = rmcol;

                }
            }
            protected override void OnMouseMove(MouseEventArgs e)
            {
                base.OnMouseMove(e);
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.Background = col;
                }
                
                else if (e.RightButton == MouseButtonState.Pressed) this.Background = rmcol;
            }

            //protected override void OnMouseEnter(MouseEventArgs e)
            //{
            //   Brush save = this.Background;
            //   base.OnMouseEnter(e);
            //   this.Background = pre;
            //}
            //protected override void OnMouseLeave(MouseEventArgs e)
            //{
            //   base.OnMouseLeave(e);
            //   this.Background = ;
            //}





        }

    }
}
