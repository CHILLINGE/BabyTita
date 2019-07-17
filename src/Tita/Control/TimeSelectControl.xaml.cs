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
                    timetable.Children.Add(colpart);
                };
            }
        }
        public class ColorPart : Border
        {
            static Brush col = new SolidColorBrush(Color.FromRgb(0xF5, 0xDA, 0x81));
            static Brush rmcol = new SolidColorBrush(Color.FromArgb(50, 0xFF, 0xFF, 0xFF));

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
                   
                }
            }
            protected override void OnMouseRightButtonDown(MouseButtonEventArgs e)
            {
                base.OnMouseRightButtonDown(e);
                if (e.ButtonState == e.RightButton) {
                    this.Background = rmcol;
                  
                }
            }
            //protected override void OnMouseEnter(MouseEventArgs e)
            //{
            //    base.OnMouseEnter(e);
            //    if (MouseButtonState ==  e.LeftButton) this.Background = col;
            //}





        }

    }
}
