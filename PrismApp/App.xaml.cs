using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismApp.Views;
using SidebarModule.Modules;
using System.Windows;
using TextEditorModule.Modules;
using ToolbarModule.Modules;

namespace PrismApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
          return ContainerLocator.Container.Resolve<MainView>();
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
           // throw new NotImplementedException();
        }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            var regionManger= ContainerLocator.Container.Resolve<IRegionManager>();
            //regionManger.RegisterViewWithRegion<ToolbarView>("ToolBarRegion");
            //regionManger.RegisterViewWithRegion<SideBarView>("SideBarRegion");
           // regionManger.RegisterViewWithRegion<ContentView>("ContentRegion");
        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<SidebarModules>();
            moduleCatalog.AddModule<ToolbarModules>();
            moduleCatalog.AddModule<TextEditorModules>();
        }
    }
}
