using Prism.Mvvm;
using Prism.Events;
using Prism.Regions;
using Prism.Commands;
using System.Windows.Controls;
using Prism;
using System.Windows;

namespace TextEditorModule.ViewModels
{
    public class TextEditorViewModel : BindableBase, INavigationAware, IActiveAware
    {
        private string _title = string.Empty;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private string _fileContent;

        public string FileContent
        {
            get { return _fileContent; }
            set { SetProperty(ref _fileContent, value); }
        }
        IEventAggregator _eventAggregator;
        IRegionManager _regionManager;

        public event EventHandler IsActiveChanged;

        public TextEditorViewModel(IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            _eventAggregator = eventAggregator;
            _regionManager = regionManager;
            DeleteTab = new DelegateCommand<TabItem>(DeleteTabItem);
        }

        private void DeleteTabItem(TabItem item)
        {
            _regionManager.Regions["ContentRegion"].Remove(item.Content);
        }

        public DelegateCommand<TabItem> DeleteTab { get; set; }
        private bool _isActive;

        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                //IsActive = value;
                SetProperty(ref _isActive, value);
                if (value)
                {
                    MessageBox.Show(FileContent);
                }
            }
        }

        //public bool IsActive { get; set; }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            var param = navigationContext.Parameters["fileDetails"] as PrismApp.Core.Models.FileModel;
           
            return param != null && Title == param.FileName;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var param = navigationContext.Parameters["fileDetails"] as PrismApp.Core.Models.FileModel;
            if (param != null)
            {
                Title = param.FileName;
                FileContent = param.FileContent;
            }
        }
    }
}
