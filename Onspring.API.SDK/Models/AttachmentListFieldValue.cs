using System.Collections.Generic;

namespace Onspring.API.SDK.Models
{
    public class AttachmentListFieldValue : RecordFieldValue
    {
        public List<AttachmentFile> Value { get; set; } = new List<AttachmentFile>();

        public AttachmentListFieldValue()
        {
            Type = Enums.ResultValueType.AttachmentList;
        }

        public AttachmentListFieldValue(List<AttachmentFile> value) : this()
        {
            Value = value;
        }
    }
}
