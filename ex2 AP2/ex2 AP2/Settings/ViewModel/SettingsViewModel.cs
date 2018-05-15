using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ex2_AP2
{
    class SettingsViewModel : ViewModelBaseClass
    {
        private ISettingsModel model;
        private String selectedHandler;
        private bool canRemove;
        //public EventHandler OnSelectedItem;
        public SettingsViewModel()
        {
           this.canRemove = false;
            this.RemoveCommand = new DelegateCommand(this.OnRemove, this.CanRemove);
            model = new SettingsModel();
           // model.PropertyChanged += this.NotifyPropertyChanged;

        }
        public ICommand RemoveCommand
        {
            get;
             set;
        }
        public String OutputDirectory
        {
            get
            {
                return model.OutputDirectory;
            }
            set
            {
               model.OutputDirectory = value;
                NotifyPropertyChanged("OutputDirectory");
            }
        }
        public String SourceName
        {
            get
            {
                return model.SourceName;
            }
            set
            {
                model.SourceName = value;
                NotifyPropertyChanged("SourceName");
            }
        }
        public String LogName
        {
            get
            {
                return model.LogName;
            }
            set
            {
              model.LogName = value;
              NotifyPropertyChanged("LogName");
            }
        }
        public int ThumbnailSize
        {
            get
            {
                return model.ThumbnailSize;
            }
            set
            {
                int temp;
                try
                {
                    temp = Convert.ToInt32(value);
                    model.ThumbnailSize = temp;
                    NotifyPropertyChanged("ThumbnailSize");
                }
                catch
                {
                    Console.WriteLine("Problem in conversion to integer!");
                }

                
            }
        }
        public ObservableCollection<String> Handlers
        {
            get
            {
                return model.Handlers;
            }
            set
            {
                //model.Handlers = value;
                NotifyPropertyChanged("Handlers");
            }
        }
        public String SelectedItem
        {
            get
            {
                return this.selectedHandler;
            }
            set
            {
                this.selectedHandler = value;
                this.canRemove = true;
                var command = this.RemoveCommand as DelegateCommand;
                command.RaiseCanExecuteChanged();
               NotifyPropertyChanged("SelectedItem");
                //NotifyPropertyChanged("RemoveButton");
            }
        }
        public bool RemoveButton
        {
            get
            {
                return this.canRemove;
            }
            set
            {
                this.canRemove = value;
                NotifyPropertyChanged("RemoveButton");
            }
        }
        
        private void OnRemove()
        {
            bool result = this.model.RemoveHandler(this.selectedHandler);
            if (result)
            {
                this.Handlers.Remove(this.selectedHandler);
                this.canRemove = false;
                var command = this.RemoveCommand as DelegateCommand;
                command.RaiseCanExecuteChanged();
            }
        }

        private bool CanRemove()
        {
            return this.canRemove;
        }
    }
}
