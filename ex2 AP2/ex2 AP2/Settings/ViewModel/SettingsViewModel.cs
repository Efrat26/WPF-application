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
    /// <summary>
    /// the view model of the settings tab
    /// </summary>
    /// <seealso cref="ex2_AP2.ViewModelBaseClass" />
    public class SettingsViewModel : ViewModelBaseClass
    {
        #region members
        /// <summary>
        /// The model
        /// </summary>
        private ISettingsModel model;
        /// <summary>
        /// The selected handler to remove
        /// </summary>
        private String selectedHandler;
        /// <summary>
        /// detemines if the remove button is avilable or not
        /// </summary>
        private bool canRemove;
        #endregion members
        #region properties
        /// <summary>
        /// Gets or sets the remove command.
        /// </summary>
        /// <value>
        /// The remove command.
        /// </value>
        public ICommand RemoveCommand
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the output directory.
        /// </summary>
        /// <value>
        /// The output directory.
        /// </value>
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
        /// <summary>
        /// Gets or sets the name of the source.
        /// </summary>
        /// <value>
        /// The name of the source.
        /// </value>
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
        /// <summary>
        /// Gets or sets the name of the log.
        /// </summary>
        /// <value>
        /// The name of the log.
        /// </value>
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
        /// <summary>
        /// Gets or sets the size of the thumbnail.
        /// </summary>
        /// <value>
        /// The size of the thumbnail.
        /// </value>
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
        /// <summary>
        /// Gets or sets the handlers.
        /// </summary>
        /// <value>
        /// The handlers.
        /// </value>
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
        /// <summary>
        /// Gets or sets the selected item.
        /// </summary>
        /// <value>
        /// The selected item.
        /// </value>
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
        /// <summary>
        /// Gets or sets a value indicating whether remove button is on or off.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [remove button]; otherwise, <c>false</c>.
        /// </value>
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
        #endregion properties    


        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsViewModel"/> class.
        /// </summary>
        public SettingsViewModel()
        {
           this.canRemove = false;
            this.RemoveCommand = new DelegateCommand(this.OnRemove, this.CanRemove);
            model = new SettingsModel();
            model.PropertyChanged += this.OnPropertyChanged;

        }
    
        /// <summary>
        /// calles the model to handle the remove.
        /// </summary>
        private void OnRemove()
        {
            this.model.RemoveHandler(this.selectedHandler);

        }
        /// <summary>
        /// Determines whether this instance can be removed.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance can remove; otherwise, <c>false</c>.
        /// </returns>
        private bool CanRemove()
        {
            return this.canRemove;
        }
        public void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName.Equals("handlers") || e.PropertyName.Equals("Handlers"))
            {
                this.Handlers.Remove(this.selectedHandler);
                this.canRemove = false;
                var command = this.RemoveCommand as DelegateCommand;
                command.RaiseCanExecuteChanged();
            }
            else
            {
               this.NotifyPropertyChanged(e.PropertyName);
            }
        }
    }
}
