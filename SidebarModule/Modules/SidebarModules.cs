using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SidebarModule.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidebarModule.Modules
{
    public class SidebarModules : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("SideBarRegion",typeof(SideBarView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<FirstView>();
            containerRegistry.RegisterForNavigation<SecondView>();
        }
    }
}
