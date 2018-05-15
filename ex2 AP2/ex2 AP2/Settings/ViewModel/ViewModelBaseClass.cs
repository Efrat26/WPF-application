using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ex2_AP2
{
    public abstract class ViewModelBaseClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(String propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        //public void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //  NotifyPropertyChanged(e.PropertyName);
        // }
    }
}
