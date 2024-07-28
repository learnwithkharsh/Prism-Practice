using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using PrismApp.Core;
using PrismApp.Core.Interfaces;
using PrismApp.Core.Models;
using PrismApp.Models;
using ProtoBuf;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace PrismApp.ViewModels
{
    public class MainViewModel:BindableBase
    {
        private string _title="Main View";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private void DeleteTabItem(TabItem item)
        {
            _regionManager.Regions["ContentRegion"].Remove(item.Content);
        }
        IRegionManager _regionManager;
        private readonly IEventAggregator eventAggregator;

        public DelegateCommand<TabItem> DeleteTab { get; set; }
        public DelegateCommand LoadedCommand { get; set; }
        public DelegateCommand ClosingCommand { get; set; }
        public MainViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            DeleteTab = new DelegateCommand<TabItem>(DeleteTabItem);
            LoadedCommand = new DelegateCommand(OnLoad);
            ClosingCommand = new DelegateCommand(Closing);
            this.eventAggregator.GetEvent<ContentEvents>().Subscribe(x=>Title= x);
        }

        private void OnLoad()
        {
            if (File.Exists(fileName))
            {
                using (var file = File.OpenRead(fileName))
                {
                    var openFileList=Serializer.Deserialize<OpenFileModelList>(file);
                    OpenExistingOpenedFiles(openFileList);
                }

            }
        }

        private void OpenExistingOpenedFiles(OpenFileModelList openFileList)
        {
            foreach (var item in openFileList.openFileModelList)
            {
                var fileDetails = new FileModel
                {
                    FileContent = item.IsSaved?File.ReadAllText(item.Path): item.Content,
                    FileName = item.Name,
                    FilePath = item.Path,
                };
                var parmeter = new NavigationParameters();
                parmeter.Add("fileDetails",fileDetails);
                _regionManager.RequestNavigate("ContentRegion", "TextEditorView", parmeter);
            }
        }

        private const string fileName = "openFileList.bin";
        private void Closing()
        {
            var tabItems = _regionManager.Regions["ContentRegion"].Views;
            var openFileList = new OpenFileModelList();
            foreach (var tab in tabItems)
            {
                var tabContent = (tab as FrameworkElement).DataContext as IFileModel;
                var filedetail = new OpenFileModel
                {
                    Name = tabContent.FileName,
                    Path = tabContent.FilePath,
                    IsSaved = File.Exists(tabContent.FilePath)

                };
                filedetail.Content= filedetail.IsSaved?"": tabContent.FileContent;
                openFileList.openFileModelList.Add(filedetail);
            }
            using(var file=File.Create(fileName))
            {
                Serializer.Serialize(file, openFileList);
            }
        }
    }
}
