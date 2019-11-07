using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
    /// MainPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainPage : UserControl, INavigable
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = this;
            Datas = new ObservableCollection<DataFile>();
        }


        public ObservableCollection<DataFile> Datas { get; set; }
        public ClassInfoList classList { get; set; }

        public DataManager manager { get; set; }

        public event EventHandler<NavigateEventArgs> OnNavigate;

        public async void Navigated(string fromEndpoint, object data)
        {
            //DataFile file = new DataFile("subjects.xml");
            //classList = await file.LoadClassInfoAsync();

            string datapath = System.IO.Path.Combine(".", "Data");
            if (!System.IO.Directory.Exists(datapath))
            {
                System.IO.Directory.CreateDirectory(datapath);
            }

            manager = new DataManager(datapath);

            isContinuable.IsEnabled = false;

            Datas.Clear();
            foreach (var i in manager.GetFiles())
            {
                if (!i.IsValid)
                {
                    continue;
                }
                ClassInfoList infos = await i.LoadClassInfoAsync();
                //lst_databases.Items.Add(String.Format("{1} {2} ({0})", i.Info.Name, i.School, i.When));
                
                Datas.Add(i);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lst_databases.SelectedIndex != -1)
            {
                OnNavigate(this, new NavigateEventArgs("groupbuild", lst_databases.SelectedItem));
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Lst_databases_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            isContinuable.IsEnabled = true;
        }

        private void ImportData_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = "데이터 파일 가져오기";
            dialog.Filter = "데이터 파일 (*.xml)|*.xml";
            dialog.CheckFileExists = true;

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    string filepath = dialog.FileName;

                    if (!new DataFile(filepath).IsValid)
                    {
                        MessageBox.Show("올바른 데이터 파일이 아닙니다.");
                        return;
                    }

                    string targetfilename = System.IO.Path.GetFileName(filepath);
                    

                    while (System.IO.File.Exists(
                        System.IO.Path.Combine(manager.FolderPath, targetfilename)
                        ))
                    {
                        targetfilename = System.IO.Path.GetFileNameWithoutExtension(targetfilename) + "-copy" + ".xml";
                    }

                    string targetpath = System.IO.Path.Combine(manager.FolderPath, targetfilename);

                    System.IO.File.Copy(filepath, targetpath);

                    OnNavigate(this, new NavigateEventArgs("main"));

                }
                catch
                {
                    MessageBox.Show("파일을 가져오는 중 오류가 발생했습니다.", "데이터 가져오기", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void DeleteData_Click(object sender, RoutedEventArgs e)
        {
            if (lst_databases.SelectedIndex == -1)
            {
                return;
            }

            var result = MessageBox.Show("해당 데이터를 정말 삭제하시겠습니까?", "데이터 삭제", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                System.IO.File.Delete(((DataFile)lst_databases.SelectedItem).Info.FullName);
                OnNavigate(this, new NavigateEventArgs("main"));
            }
        }

        private void OpenFolder_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(manager.FolderPath);
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            OnNavigate(this, new NavigateEventArgs("main"));
        }
    }
}
