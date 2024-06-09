using PrismApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApp.Core.Interfaces
{
    public interface IFileService
    {
        FileModel Open();
        void Save(object activeView);
    }
}
