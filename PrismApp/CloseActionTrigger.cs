using Microsoft.Xaml.Behaviors;
using Prism.Regions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PrismApp
{
    public class CloseActionTrigger : TriggerAction<Button>
    {
        protected override void Invoke(object parameter)
        {
            var param = parameter as RoutedEventArgs;
            if(param != null)
            {
                var tabItem=FindControl<TabItem>(param.OriginalSource as DependencyObject);
                if(tabItem !=null)
                {
                    var tabControl = FindControl<TabControl>(tabItem);
                    if(tabControl !=null)
                    {
                        //tabControl.Items.Remove(tabItem.Content);
                        var region = RegionManager.GetObservableRegion(tabControl).Value;
                        if(region!=null && region.Views.Contains(tabItem.Content))
                        {
                            region.Remove(tabItem.Content);
                        }
                    }
                }
            }
        }

        private T FindControl<T>(DependencyObject child) where T:DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(child);
            if(parent !=null)
            {
                var p = parent as T;
                if (p != null)
                    return p;
               return FindControl<T>(parent);
            }
            return null;
        }
    }
}
