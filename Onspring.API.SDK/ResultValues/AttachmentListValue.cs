using System.Collections.Generic;
using Onspring.API.SDK.Enums;

namespace Onspring.API.SDK.ResultValues
{
    public class AttachmentListValue: ResultValue
    {
        public AttachmentListValue(IReadOnlyList<AttachmentFile> value)
        {
            Value = value;
        }

        public override ResultValueType Type => ResultValueType.AttachmentList;

        public IReadOnlyList<AttachmentFile> Value { get; private set; }

    }

}