using ProtoBuf;
using System.Collections.Generic;

namespace PrismApp.Models
{
   [ProtoContract]
    public class OpenFileModel
    {
        [ProtoMember(1)]
        public string Name { get; set; }
        [ProtoMember(2)]
        public string Path { get; set; }
        [ProtoMember(3)]
        public string Content { get; set; }
        [ProtoMember(4)]
        public bool IsSaved { get; set; }
    }
    [ProtoContract]
    public class OpenFileModelList
    {
        [ProtoMember(1)]
        public List<OpenFileModel> openFileModelList { get; set; }=new List<OpenFileModel>();
    }
}
