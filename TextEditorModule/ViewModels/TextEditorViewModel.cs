using Prism.Mvvm;
using Prism.Events;
using Prism.Regions;
using Prism.Commands;
using System.Windows.Controls;
using Prism;
using System.Windows;
using PrismApp.Core.Interfaces;
using PrismApp.Core;
using System.IO;

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

        private bool _isActive;

        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                SetProperty(ref _isActive, value);
                if (value)
                {
                    _eventAggregator.GetEvent<ContentEvents>().Publish(FilePath);
                    if (_fileChanged)
                        Notify();
                }
            }
        }

        private FileSystemWatcher fileSystemWatcher;
        private bool _fileChanged = false;
        IEventAggregator _eventAggregator;
        IRegionManager _regionManager;

        public DelegateCommand<TabItem> DeleteTab { get; set; }
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
                if (!string.IsNullOrEmpty(FilePath))
                {
                    fileSystemWatcher = new FileSystemWatcher(Path.GetDirectoryName(FilePath))
                    {
                        Filter = Path.GetFileName(FilePath),
                        NotifyFilter = NotifyFilters.LastWrite
                    };
                    fileSystemWatcher.Changed += OnFileChnaged;
                    fileSystemWatcher.EnableRaisingEvents = true;
                }
            }
        }

        private void OnFileChnaged(object sender, FileSystemEventArgs e)
        {
            if (IsActive)
                Notify();
            else
                _fileChanged = true;

        }

        private void Notify()
        {
            Application.Current.Dispatcher.BeginInvoke(() =>
            {
                var result = MessageBox.Show(Application.Current.MainWindow, "File has been modified from another application. do you want to reload it?", "Info", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {

                    FileContent = File.ReadAllText(FilePath);
                    _fileChanged = false;
                }

            });
        }
    }
}
