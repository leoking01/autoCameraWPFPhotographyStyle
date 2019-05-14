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
using System.Windows.Shapes;
// 下载于www.mycodes.net
namespace AutoCamera
{
    /// <summary>
    /// ShootWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ShootWindow : Window
    {
        private List<BitmapImage> m_imagelist;
        private BitmapImage m_curimage;

        public ShootWindow() {
            InitializeComponent();
            InitImageList();
            this.curimage.Source = m_curimage;
            SetLeftRightBtnStatus();
            SetIndexText();
        }

        public int ImageCount {
            get {
                return m_imagelist.Count;
            }
        }

        public int CurImageIndex {
            get {
                return m_imagelist.IndexOf(m_curimage);
            }
            set {
                if (value >= ImageCount || value<0) {
                    throw new Exception("超出范围");
                }
                m_curimage = m_imagelist[value];
            }
        }

        private void InitImageList(){
            m_imagelist = new List<BitmapImage>();
            m_imagelist.Add(new BitmapImage(new Uri("Scence/1.jpg", UriKind.Relative)));
            m_imagelist.Add(new BitmapImage(new Uri("Scence/2.jpg", UriKind.Relative)));
            m_imagelist.Add(new BitmapImage(new Uri("Scence/3.jpg", UriKind.Relative)));
            m_imagelist.Add(new BitmapImage(new Uri("Scence/4.jpg", UriKind.Relative)));
            m_imagelist.Add(new BitmapImage(new Uri("Scence/5.jpg", UriKind.Relative)));
            m_imagelist.Add(new BitmapImage(new Uri("Scence/6.jpg", UriKind.Relative)));

            m_curimage = m_imagelist[0];
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            this.DragMove();
        }

        private void btn_back2_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void btn_bg_Click(object sender, RoutedEventArgs e) {
            this.Pop_bg.IsOpen = true;
        }

        private void btn_jiaojia_Click(object sender, RoutedEventArgs e) {
            this.Pop_jiaojia.IsOpen = true;
        }

        private void btn_xiangji_Click(object sender, RoutedEventArgs e) {
            this.Pop_xiangji.IsOpen = true;        
        }

        private void btn_right_Click(object sender, RoutedEventArgs e) {
            if (CurImageIndex < ImageCount-1) {
                CurImageIndex++;
                this.curimage.Source = m_curimage;
                SetLeftRightBtnStatus();
                SetIndexText();
            }
        }

        private void btn_left_Click(object sender, RoutedEventArgs e) {
            if (CurImageIndex > 0) {
                CurImageIndex--;
                this.curimage.Source = m_curimage;
                SetLeftRightBtnStatus();
                SetIndexText();
            }
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e) {
            this.btn_left.Visibility = System.Windows.Visibility.Visible;
            this.btn_right.Visibility = System.Windows.Visibility.Visible;
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e) {
            this.btn_left.Visibility = System.Windows.Visibility.Hidden;
            this.btn_right.Visibility = System.Windows.Visibility.Hidden;
        }

        private void SetLeftRightBtnStatus() {
            if (CurImageIndex == 0) {
                this.btn_left.IsEnabled = false;
            } else {
                this.btn_left.IsEnabled = true;
            }
            if (CurImageIndex == ImageCount - 1) {
                this.btn_right.IsEnabled = false;
            } else {
                this.btn_right.IsEnabled = true;
            }
        }

        private void SetIndexText() {
            this.tb_curimageindex.Text = string.Format(@"{0}/{1}", CurImageIndex + 1, ImageCount);
        }
    }
}
