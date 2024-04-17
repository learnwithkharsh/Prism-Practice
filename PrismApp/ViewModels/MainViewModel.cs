using Prism.Mvvm;

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

    }
}
