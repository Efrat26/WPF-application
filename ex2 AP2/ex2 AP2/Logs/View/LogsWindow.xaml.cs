using ex2_AP2.Logs.ViewModel;
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

namespace ex2_AP2.Logs.View
{
    /// <summary>
    /// Interaction logic for LogsTab.xaml
    /// </summary>
    public partial class LogsWindow : UserControl
    {
        private ViewModelBaseClass logs_vm;
        public LogsWindow()
        {

            InitializeComponent();
            this.logs_vm = new LogsViewModel();
            this.DataContext = logs_vm;
        }
    }
}
