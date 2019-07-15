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
    /// ClassGroupControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ClassGroupControl : UserControl
    {
        public ClassGroupControl()
        {
            InitializeComponent();
        }

        public ClassGroup Group { get; set; }

        /// <summary>
        /// 새로운 그룹 추가
        /// </summary>
        /// <param name="group"></param>
        public ClassGroupControl(ClassGroup group) : this()
        {
            this.Group = group;
            BasketUpdate();
        }

        /// <summary>
        /// 그룹에 새롭게 과목을 추가,삭제할 때마다 부르는 클래스
        /// </summary>
        /// <param name="group"></param>
        public void BasketUpdate()
        {
            foreach (IGroupable item in Group.Children)
            {
                if (Group.IsitGroup(item)) { }
                else
                {
                    ClassInfoControl groupitem = new ClassInfoControl((ClassInfoPlus)item);
                    groupitem.Margin = new Thickness(0,0,0,10);
                    basketstack.Children.Add(groupitem);
                }
            }
        }
    }
}
