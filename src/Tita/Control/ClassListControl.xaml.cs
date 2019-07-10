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
    /// ClassListControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ClassListControl : UserControl
    {
        private List<ClassInfo> ListBackup;
        private Dictionary<int, int> BackUpDictionary;
        public List<ClassInfo> ClassDatalist { get; set; }

        public void Update()
        {
            //같은 list 주소를 나타낼때
            if (ListBackup == ClassDatalist)
            {
                //삽입, 삭제된 과목이 없는지 확인. BackUpDictionary 이용
                int index;
                for (int i = 0; i < ClassDatalist.Count; i++)
                {
                    BackUpDictionary.TryGetValue(ClassDatalist[i].ID, out index);
                    if (index == 0) // 해당 과목을 삽입해야함
                    {
                        ClassInfoControl child = new ClassInfoControl();
                        child.Info = ClassDatalist[i];
                        child.VerticalAlignment = VerticalAlignment.Top;
                        child.HorizontalAlignment = HorizontalAlignment.Left;
                        MainScroll.Children.Insert(i, child);

                        BackUpDictionary.Add(ClassDatalist[i].ID, i);
                    }
                    else // 해당과목이 있음
                    {
                        if (index == i) continue; //기존 위치에 존재
                        else //위치가 변경됨
                        {
                            MainScroll.Children.Insert(i, MainScroll.Children[index]);
                            MainScroll.Children.RemoveAt(index);
                            BackUpDictionary[ClassDatalist[i].ID] = i;
                        }
                    }
                }
            }

            //list 주소가 다를 때
            else
            {
                MainScroll.Children.Clear();
                BackUpDictionary.Clear();
                for (int i = 0; i < ClassDatalist.Count; i++)
                {
                    //Dictionary에 과목id와 위치 저장
                    BackUpDictionary.Add(ClassDatalist[i].ID, i);

                    ClassInfoControl child = new ClassInfoControl();
                    child.Info = ClassDatalist[i];
                    child.VerticalAlignment = VerticalAlignment.Top;
                    child.HorizontalAlignment = HorizontalAlignment.Stretch;
                    child.Margin = new Thickness(5);

                    MainScroll.Children.Add(child);
                }
                ListBackup = ClassDatalist;

            }
        
        }


        public ClassListControl()
        {
            InitializeComponent();
            ListBackup = null;
            BackUpDictionary = new Dictionary<int, int>();


        }

    }
}
