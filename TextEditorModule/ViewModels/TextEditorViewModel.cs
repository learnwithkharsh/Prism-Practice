using Prism.Mvvm;
using Prism.Events;
using Prism.Regions;
using Prism.Commands;
using System.Windows.Controls;
using Prism;
using System.Windows;
using PrismApp.Core.Interfaces;
using PrismApp.Core;

namespace TextEditorModule.ViewModels
{
    public class TextEditorViewModel : BindableBase, INavigationAware, IActiveAware, IFileModel
    {
        private string _FileName = string.Empty;

        public string FileName
        {
            get { return _FileName; }
            set { SetProperty(ref _FileName, value); }
        }
        private string _fileContent;

        public string FileContent
        {
            get { return _fileContent; }
            set { SetProperty(ref _fileContent, value); }
        }
        private string _filePath;

        public string FilePath
        {
            get { return _filePath; }
            set { SetProperty(ref _filePath, value); }
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
                    _eventAggregator.GetEvent<ContentEvents>().Publish(FilePath);
                    //MessageBox.Show(FileContent);
                }
            }
        }

       
      

        //public bool IsActive { get; set; }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            var param = navigationContext.Parameters["fileDetails"] as PrismApp.Core.Models.FileModel;
           
            return param != null && FileName == param.FileName;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var param = navigationContext.Parameters["fileDetails"] as PrismApp.Core.Models.FileModel;
            if (param != null)
            {
                FileName = param.FileName;
                FileContent = param.FileContent;
                FilePath = param.FilePath;
                _eventAggregator.GetEvent<ContentEvents>().Publish(FilePath);
            }
        }
    }
}
