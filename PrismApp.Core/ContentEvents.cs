using Prism.Events;
using PrismApp.Core.Models;

namespace PrismApp.Core
{
    public class ContentEvents:PubSubEvent<string>
    {
    }
    public class FileContentEvents : PubSubEvent<FileModel>
    {
    }
}
