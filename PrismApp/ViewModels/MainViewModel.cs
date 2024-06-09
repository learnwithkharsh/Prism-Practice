using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using PrismApp.Core;
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
        public MainViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _regionManager = regionManager;
            this.eventAggregator = eventAggregator;
            DeleteTab = new DelegateCommand<TabItem>(DeleteTabItem);
            this.eventAggregator.GetEvent<ContentEvents>().Subscribe(x=>Title= x);
        }
    }
}
