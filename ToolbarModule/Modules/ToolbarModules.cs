using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using ToolbarModule.ViewModels;
using ToolbarModule.Views;

namespace ToolbarModule.Modules
{
    public class ToolbarModules : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ToolBarRegion", typeof(ToolbarView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<FileDialog, FileDialogViewModel>();
        }
    }
}
