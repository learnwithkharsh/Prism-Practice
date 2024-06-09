using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismApp.Core.Interfaces
{
    public interface IFileModel
    {
        string FileName { get; set; }
        string FilePath { get; set; }
        string FileContent { get; set; }
    }
}
