using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Prism.Events;
using TextEditorModule.Models;
using Prism.Regions;


namespace TextEditorModule.ViewModels
{
    public class TextEditorViewModel : BindableBase,INavigationAware
    {
        private string _title = string.Empty;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private string _fileContent;

        public string FileContent
        {
            get { return _fileContent; }
            set { SetProperty(ref _fileContent, value); }
        }
        IEventAggregator _eventAggregator;
        public TextEditorViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator= eventAggregator;
        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
           return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var param = navigationContext.Parameters["fileDetails"] as PrismApp.Core.Models.FileModel;
            if (param != null)
            {
                Title = param.FileName;
                FileContent = param.FileContent;
            }
        }
    }
}
