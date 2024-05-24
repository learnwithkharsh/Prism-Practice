using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Controls;

namespace PrismApp.ViewModels
{
    public class MainViewModel:BindableBase
    {
        private string _title="Welcome to Prism Apllication";

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
        public DelegateCommand<TabItem> DeleteTab { get; set; }
        public MainViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            DeleteTab = new DelegateCommand<TabItem>(DeleteTabItem);
        }
    }
}
