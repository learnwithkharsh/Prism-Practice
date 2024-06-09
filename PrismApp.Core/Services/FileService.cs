using Microsoft.Win32;
using Prism.Events;
using PrismApp.Core.Interfaces;
using PrismApp.Core.Models;
using System.IO;
using System.Windows;

namespace PrismApp.Core.Services
{
    public class FileService : IFileService
    {
        ContentEvents contentEvents;
        public FileService(IEventAggregator eventAggregator)
        {
            contentEvents=eventAggregator.GetEvent<ContentEvents>();
        }
        public FileModel Open()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Text files|*.txt|All files|*.*",
                Title = "Open"
            };
            var dialogResult= openFileDialog.ShowDialog();
            if(dialogResult.HasValue &&  dialogResult.Value)
            {
                var file = new FileModel
                {
                    FileName = openFileDialog.SafeFileName,
                    FileContent = File.ReadAllText(openFileDialog.FileName),
                    FilePath = openFileDialog.FileName
                    
                };
                contentEvents.Publish(file.FilePath);
                return file;
            }
            return null;
        }

        public void Save(object activeView)
        {
            var dataContext= (activeView as FrameworkElement).DataContext as IFileModel;
            var filContent= dataContext.FileContent;
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Text files|*.txt|All files|*.*",
                Title = "Save",
                DefaultExt = ".txt"
            };
            var dialogResult = saveFileDialog.ShowDialog();
            if( dialogResult.HasValue && dialogResult.Value ) {
                dataContext.FileContent = filContent;
                dataContext.FilePath = saveFileDialog.FileName;
                dataContext.FileName= saveFileDialog.SafeFileName;
                File.WriteAllText(dataContext.FilePath,filContent);
                contentEvents.Publish(dataContext.FilePath);
            }
        }
    }
}
