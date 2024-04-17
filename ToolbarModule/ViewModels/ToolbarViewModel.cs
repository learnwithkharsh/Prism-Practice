using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Prism.Events;
using PrismApp.Core;

namespace ToolbarModule.ViewModels
{
    public class ToolbarViewModel : BindableBase
    {
        IDialogService _dialogService;
        IEventAggregator _eventAggregator;
        string content = string.Empty;
        public ToolbarViewModel(IDialogService dialogService,IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _dialogService = dialogService;
            // OpenCommand = new DelegateCommand(Exceute).ObservesCanExecute(()=>IsChecked);
            SaveCommand = new DelegateCommand(Save,()=>true);
            _eventAggregator.GetEvent<ContentEvents>().Subscribe(GetContent);
        }

        private void Save()
        {
            MessageBox.Show(content);
        }

        private void GetContent(string obj)
        {
            content = obj;
          
        }

        public DelegateCommand OpenCommand { get; }
        public DelegateCommand SaveCommand { get; }


        private void Exceute(bool? isChecked)
        {
            var msg = "this is dialogservice";
            _dialogService.ShowDialog("FileDialog",new DialogParameters($"message={msg}"),result=> {
                if (result.Result == ButtonResult.OK)
                {
                    var dialogName =result.Parameters.GetValue<string>("dialogName");
                    MessageBox.Show($"{dialogName}, Ok button is clicked");
                }
                if (result.Result == ButtonResult.Cancel)
                    MessageBox.Show("Cancel button is clicked");
            });
            //MessageBox.Show("OpenCommand is exceuted : "+isChecked);
        }
        private bool _isChecked;

        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                SetProperty(ref _isChecked, value);
            }
        }

    }
}
