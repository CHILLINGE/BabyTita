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
        ColorPart[,] map = new ColorPart[6, 12];
        int[,] check = new int[6, 12];
        public TimeSelectControl()
        {

            InitializeComponent();

            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 11; j++)
                {
                    ColorPart colpart = new ColorPart();
                    Grid.SetColumn(colpart, i);
                    Grid.SetRow(colpart, j);
                    colpart.stC = i;
                    colpart.stR = j;
                    timetable.Children.Add(colpart);
                    map[i, j] = colpart;

                };
            }
        }

        public ClassTime GetClassTime()
        {
            List<ClassTimeItem> items = new List<ClassTimeItem>();



            Brush col = new SolidColorBrush( Color.FromArgb(0x50,0xA9,0xD0,0xF5));
            Brush rmcol = new SolidColorBrush(Color.FromArgb(0x32, 0xFF, 0xFF, 0xFF));
            int save_day = 0;
            int save_st = 0, save_ed = 0;
            for (int i = 1; i <= 5; i++) //요일
            {
                int f = 0;
                for (int j = 1; j <= 11; j++) //교시
                {
                    if (f == 0 && map[i, j].isSelected==true)
                    {
                        f = 1;
                        save_day = i;
                        save_st = j;
                    }
                    else if (f == 1 && map[i, j].isSelected==true)
                        continue;
                    else if (f == 1 && map[i, j].isSelected==false)
                    {
                        save_ed = j-1;

                        if (save_day == 1)
                            items.Add(new ClassTimeItem(DayOfWeek.Monday, save_st, save_ed));


                        else if (save_day == 2)
                            items.Add(new ClassTimeItem(DayOfWeek.Tuesday, save_st, save_ed));

                        else if (save_day == 3)
                            items.Add(new ClassTimeItem(DayOfWeek.Wednesday, save_st, save_ed));

                        else if (save_day == 4)
                            items.Add(new ClassTimeItem(DayOfWeek.Thursday, save_st, save_ed));


                        else if (save_day == 5)
                            items.Add(new ClassTimeItem(DayOfWeek.Friday, save_st, save_ed));
                        f = 0;

                    }
                }
            }


            return new ClassTime(items);
        }
        public class ColorPart : Border
        {
            static Brush col = new SolidColorBrush(Color.FromArgb(80, 0xa9, 0xd0, 0xf5));
            static Brush rmcol = new SolidColorBrush(Color.FromArgb(50, 0xFF, 0xFF, 0xFF));
            static Brush pre = new SolidColorBrush(Color.FromArgb(20, 0xa9, 0xd0, 0xf5));

            public int stC { get; set; }
            public int stR { get; set; }

            public bool isSelected;
         
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
                    isSelected = true;
                }
            }
            protected override void OnMouseRightButtonDown(MouseButtonEventArgs e)
            {
                base.OnMouseRightButtonDown(e);
                if (e.ButtonState == e.RightButton)
                {
                    this.Background = rmcol;
                    isSelected = false;

                }
            }
            protected override void OnMouseMove(MouseEventArgs e)
            {
                base.OnMouseMove(e);
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.Background = col;
                    isSelected = true;
                }
                else if (e.RightButton == MouseButtonState.Pressed) this.Background = rmcol;
            }





        }

    }
}
