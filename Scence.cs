using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;

namespace AutoCamera
{
    public class Scence : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool m_isselected;

        public string ImagePath {
            get;
            set;
        }

        public bool IsSelected {
            get {
                return m_isselected;
            }
            set {
                m_isselected = value;
                if (this.PropertyChanged != null) {
                    this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("IsSelected"));
                }
            }
        }

        public Scence(string imagepath) {
            ImagePath = imagepath;
            IsSelected = false;
        }
    }

    public class ScenceSelectStatusToBgPathConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            if ((bool)value) {
                return @"/Images/场景背景selected.png";
            } else {
                return @"/Images/场景背景.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
