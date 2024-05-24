using Prism.Mvvm;
using Prism.Events;
using Prism.Regions;
using Prism.Commands;
using System.Windows.Controls;

namespace TextEditorModule.ViewModels
{
    public class TextEditorViewModel : BindableBase,INavigationAware
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
        public TextEditorViewModel(IEventAggregator eventAggregator,IRegionManager regionManager)
        {
            _eventAggregator= eventAggregator;
            _regionManager = regionManager;
            DeleteTab = new DelegateCommand<TabItem>(DeleteTabItem);
        }

        private void DeleteTabItem(TabItem item)
        {
            _regionManager.Regions["ContentRegion"].Remove(item.Content);
        }

        public DelegateCommand<TabItem> DeleteTab { get; set; }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
           return false;
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
