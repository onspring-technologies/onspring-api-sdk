using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    public class FileListFieldValue : RecordFieldValue
    {
        public List<int> Value { get; set; } = new List<int>();

        public FileListFieldValue()
        {
            Type = Enums.ResultValueType.FileList;
        }

        public FileListFieldValue(List<int> value) : this()
        {
            Value = value;
        }
    }
}
