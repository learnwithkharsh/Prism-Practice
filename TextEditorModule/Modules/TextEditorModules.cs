using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismApp.Core.Interfaces;
using TextEditorModule.ViewModels;
using TextEditorModule.Views;


namespace TextEditorModule.Modules
{
    public class TextEditorModules : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //var regionManager = containerProvider.Resolve<IRegionManager>();
            //regionManager.RegisterViewWithRegion("ContentRegion", typeof(TextEditorView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<TextEditorView>();
            //containerRegistry.RegisterDialog<FileDialog, FileDialogViewModel>();
            containerRegistry.Register<IFileModel,TextEditorViewModel>();
        }
    }
}
