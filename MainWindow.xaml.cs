using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoCamera
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Package> m_packagelist;
        private List<Scence> m_scencelist;
        private List<UserControl> m_packagectllist;
        private List<UserControl> m_scencectllist;
        private Package m_selectedpackage;
        private Scence m_selectedscence;

        public MainWindow() {
            InitializeComponent();

            InitPackageCtlList();
            InitScenceCtlList();
            ShowPackages();
            m_packagelist[0].IsSelected = true;
            m_selectedpackage = m_packagelist[0];
            m_scencelist[0].IsSelected = true;
            m_selectedscence = m_scencelist[0];
        }
        // 下载于www.mycodes.net
        //初始化套系列表
        private void InitPackageList() {
            m_packagelist = new List<Package>();
            m_packagelist.Add(new Package("秋景1", "/Package/1.jpg"));
            m_packagelist.Add(new Package("秋景2", "/Package/2.jpg"));
            m_packagelist.Add(new Package("秋景3", "/Package/3.jpg"));
            m_packagelist.Add(new Package("秋景4", "/Package/4.jpg"));
            m_packagelist.Add(new Package("秋景5", "/Package/5.jpg"));
            m_packagelist.Add(new Package("秋景6", "/Package/6.jpg"));
            m_packagelist.Add(new Package("秋景7", "/Package/7.jpg"));
            m_packagelist.Add(new Package("秋景8", "/Package/8.jpg"));
            m_packagelist.Add(new Package("秋景9", "/Package/9.jpg"));
            m_packagelist.Add(new Package("秋景10", "/Package/10.jpg"));
            m_packagelist.Add(new Package("秋景11", "/Package/11.jpg"));
            m_packagelist.Add(new Package("秋景12", "/Package/12.jpg"));
            m_packagelist.Add(new Package("秋景13", "/Package/13.jpg"));
            m_packagelist.Add(new Package("秋景14", "/Package/14.jpg"));
            m_packagelist.Add(new Package("秋景15", "/Package/15.jpg"));
            m_packagelist.Add(new Package("秋景16", "/Package/16.jpg"));
            m_packagelist.Add(new Package("秋景17", "/Package/17.jpg"));
        }
        //初始化套系控件列表
        private void InitPackageCtlList() {
            InitPackageList();
            m_packagectllist = new List<UserControl>();
            foreach (Package temp in m_packagelist) {
                UserControl tempctl = new UserControl();
                tempctl.Margin = new Thickness(10, 10, 10, 10);
                tempctl.Content = temp;
                tempctl.ContentTemplate = (System.Windows.DataTemplate)FindResource("PackageTemplate");
                tempctl.MouseLeftButtonUp += new MouseButtonEventHandler(packagectl_MouseLeftButtonUp);
                tempctl.MouseDoubleClick += new MouseButtonEventHandler(packagectl_MouseDoubleClick);
                m_packagectllist.Add(tempctl);
            }
        }


        //初始化场景列表
        private void InitScenceList() {
            m_scencelist = new List<Scence>();
            m_scencelist.Add(new Scence("/Scence/1.jpg"));
            m_scencelist.Add(new Scence("/Scence/2.jpg"));
            m_scencelist.Add(new Scence("/Scence/3.jpg"));
            m_scencelist.Add(new Scence("/Scence/4.jpg"));
            m_scencelist.Add(new Scence("/Scence/5.jpg"));
            m_scencelist.Add(new Scence("/Scence/6.jpg"));
            m_scencelist.Add(new Scence("/Scence/7.jpg"));
            m_scencelist.Add(new Scence("/Scence/8.jpg"));
            m_scencelist.Add(new Scence("/Scence/9.jpg"));
            m_scencelist.Add(new Scence("/Scence/10.jpg"));
            m_scencelist.Add(new Scence("/Scence/11.jpg"));
            m_scencelist.Add(new Scence("/Scence/12.jpg"));
            m_scencelist.Add(new Scence("/Scence/13.jpg"));
            m_scencelist.Add(new Scence("/Scence/14.jpg"));
            m_scencelist.Add(new Scence("/Scence/15.jpg"));
            m_scencelist.Add(new Scence("/Scence/16.jpg"));
        }
        //初始化场景控件列表
        private void InitScenceCtlList() {
            InitScenceList();

            m_scencectllist = new List<UserControl>();
            foreach (Scence temp in m_scencelist) {
                UserControl tempctl = new UserControl();
                tempctl.Margin = new Thickness(15, 15, 15, 15);
                tempctl.Content = temp;
                tempctl.ContentTemplate = (System.Windows.DataTemplate)FindResource("ScenceTemplate");
                tempctl.MouseLeftButtonUp += new MouseButtonEventHandler(scencectl_MouseLeftButtonUp);
                tempctl.MouseDoubleClick += new MouseButtonEventHandler(scencectl_MouseDoubleClick);
                m_scencectllist.Add(tempctl);
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            this.DragMove();
        }

        private void btn_close_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void btn_min_Click(object sender, RoutedEventArgs e) {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void btn_quitsys_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        //显示套系列表
        private void ShowPackages() {
            this.btn_set.Visibility = System.Windows.Visibility.Visible;
            this.btn_intopackage.Visibility = System.Windows.Visibility.Visible;
            this.btn_intoscene.Visibility = System.Windows.Visibility.Hidden;
            this.btn_addpackage.Visibility = System.Windows.Visibility.Visible;
            this.btn_delpackage.Visibility = System.Windows.Visibility.Visible;
            this.btn_back1.IsEnabled = false;
            this.border_changjing.Visibility = System.Windows.Visibility.Hidden;
            this.tb_taoxi.Text = string.Format("套系列表({0}套)", this.m_packagelist.Count);

            this.ShowPanel.Children.Clear();
            foreach (UserControl temp in m_packagectllist) {
                this.ShowPanel.Children.Add(temp);
            }
        }

        //显示场景列表
        private void ShowScences() {
            this.btn_set.Visibility = System.Windows.Visibility.Hidden;
            this.btn_intopackage.Visibility = System.Windows.Visibility.Hidden;
            this.btn_intoscene.Visibility = System.Windows.Visibility.Visible;
            this.btn_addpackage.Visibility = System.Windows.Visibility.Hidden;
            this.btn_delpackage.Visibility = System.Windows.Visibility.Hidden;
            this.btn_back1.IsEnabled = true;
            this.border_changjing.Visibility = System.Windows.Visibility.Visible;
            this.tb_changjing.Text = m_selectedpackage.PackageName;

            this.ShowPanel.Children.Clear();
            foreach (UserControl temp in m_scencectllist) {
                this.ShowPanel.Children.Add(temp);
            }
        }

        //单击了单个套系
        void packagectl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            Package selectedpackage = (Package)((UserControl)sender).Content;
            m_selectedpackage.IsSelected = false;
            selectedpackage.IsSelected = true;
            m_selectedpackage = selectedpackage;
        }

        //单击了单个场景
        void scencectl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            Scence selectedscence = (Scence)((UserControl)sender).Content;
            m_selectedscence.IsSelected = false;
            selectedscence.IsSelected = true;
            m_selectedscence = selectedscence;
        }

        //双击了套系
        void packagectl_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            ShowScences();
        }

        //双击了场景
        void scencectl_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            ShootWindow win = new ShootWindow();
            win.ShowDialog();
        }

        private void btn_back1_Click(object sender, RoutedEventArgs e) {
            ShowPackages();
        }

        private void btn_intopackage_Click(object sender, RoutedEventArgs e) {
            ShowScences();
        }

        private void btn_intoscene_Click(object sender, RoutedEventArgs e) {
            ShootWindow win = new ShootWindow();
            win.ShowDialog();
        }

        private void btn_set_Click(object sender, RoutedEventArgs e) {
            this.menu.IsOpen = true;
        }
    }
}
