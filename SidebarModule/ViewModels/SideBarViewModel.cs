using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidebarModule.ViewModels
{
    public class SideBarViewModel
    {
        public DelegateCommand<string> NavigateCommand { get; private set; }
        private IRegionManager _regionManager;
        public SideBarViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(Navegate, (s) => true);
        }

        private void Navegate(string viewName)
        {
            if (!string.IsNullOrEmpty(viewName))
            {
                _regionManager.RequestNavigate("ContentRegion", viewName);
            }
        }
    }
}
