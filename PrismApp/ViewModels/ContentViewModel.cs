using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;
using PrismApp.Core;

namespace PrismApp.ViewModels
{
    public class ContentViewModel : BindableBase
    {
        IEventAggregator _eventAggregator;
        public ContentViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }
        private string _content;

        public string Content
        {
            get { return _content; }
            set
            {
                SetProperty(ref _content, value);
                _eventAggregator.GetEvent<ContentEvents>().Publish(_content);
            }
        }

    }
}
