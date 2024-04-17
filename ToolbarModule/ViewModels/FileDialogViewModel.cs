using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolbarModule.ViewModels
{
    public class FileDialogViewModel:BindableBase,IDialogAware
    {
        public FileDialogViewModel()
        {
            OkCommand = new DelegateCommand<string>(Ok,(s)=>true);
            CancelCommand = new DelegateCommand<string>(Cancel, (s) => true);
        }
        private string _message;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public event Action<IDialogResult> RequestClose;

        private void Cancel(string param)
        {
            if (param == "Cancel")
            {
                var dialogResult = new DialogResult(ButtonResult.Cancel);
               
                RequestClose.Invoke(dialogResult);
            }
        }

        private void Ok(string param)
        {
            if (param == "ok")
            {
                var dialogResult = new DialogResult(ButtonResult.OK);
                dialogResult.Parameters.Add("dialogName", "FileDailog");
                RequestClose.Invoke(dialogResult);
            }
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
           
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Message = parameters.GetValue<string>("message");
        }

        public DelegateCommand<string> OkCommand { get; }
        public DelegateCommand<string> CancelCommand { get; }

        public string Title => "Dialog Service";
    }
}
