using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System.Windows;
using Prism.Events;
using Prism.Regions;
using PrismApp.Core.Models;

namespace ToolbarModule.ViewModels
{
    public class ToolbarViewModel : BindableBase
    {     
        IDialogService _dialogService;
        IEventAggregator _eventAggregator;
        string content = string.Empty;
        IRegionManager _regionManager;
        public ToolbarViewModel(IDialogService dialogService,IEventAggregator eventAggregator,IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _dialogService = dialogService;
            // OpenCommand = new DelegateCommand(Exceute).ObservesCanExecute(()=>IsChecked);
            SaveCommand = new DelegateCommand(Save,()=>true);
            NewCommand = new DelegateCommand(New, () => true);
            _eventAggregator.GetEvent<PrismApp.Core.ContentEvents>().Subscribe(GetContent);
        }
        static int count = 0;
        private void New()
        {
            var param = new NavigationParameters();
            FileModel file = new FileModel
            {
                FileName = $"new{++count}",
                FileContent= $"this is file content{count}"
            };
            param.Add("fileDetails", file);
            _regionManager.RequestNavigate("ContentRegion", "TextEditorView", param);
        }

        private void Save()
        {
            MessageBox.Show(content);
        }

        private void GetContent(string obj)
        {
            content = obj;
          
        }

        public DelegateCommand NewCommand { get; }
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
