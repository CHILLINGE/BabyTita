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
            for (int i = 0; i <= 5; i++)
            {
                for (int j = 0; j <= 10; j++)
                {
                    ColorPart colpart = new ColorPart();
                    Grid.SetColumn(colpart, i);
                    Grid.SetRow(colpart,j);

                    colpart.MouseLeftButtonDown += Colpart_MouseLeftButtonDown;
                    colpart.MouseRightButtonDown += Colpart_MouseRightButtonDown;

                };
            }
        }

        private void Colpart_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            click(MouseButton.Left);   

        }
        private void Colpart_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            click(MouseButton.Right);
        }

        private void click(MouseButton btn)
        {
            if(btn == MouseButton.Left)
            {
                double x = Mouse.GetPosition(timetable).X;
                double y = Mouse.GetPosition(timetable).Y;

            }
            else
            {

            }
                    
        }
        private class ColorPart : Border
        {
            
        }

    }
}
