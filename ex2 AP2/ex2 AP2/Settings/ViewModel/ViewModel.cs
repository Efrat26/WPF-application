using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ex2_AP2
{
    abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(String propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public abstract void OnSelectedItem(Object sender, RoutedEventArgs e);
        //public void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //  NotifyPropertyChanged(e.PropertyName);
        // }
    }
}
