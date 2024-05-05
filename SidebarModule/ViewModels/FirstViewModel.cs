using Prism.Regions;
using System.Windows;

namespace SidebarModule.ViewModels
{
    public class FirstViewModel : INavigationAware
    {
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
           return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var param= navigationContext.Parameters["name"] as string;
            if (param != null) {
                MessageBox.Show($"parmeters is {param}");
            }
        }
    }
}
