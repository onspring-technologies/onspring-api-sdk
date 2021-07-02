using Newtonsoft.Json.Linq;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Models;
using System;

namespace Onspring.API.SDK.Json
{
    internal class RecordFieldValueJsonConverter : JsonCreationConverter<RecordFieldValue>
    {
        protected override RecordFieldValue Create(Type objectType, JObject jObject)
        {
            var valueTypeStr = jObject["type"]?.ToString() ?? jObject["Type"]?.ToString();
            var didParse = Enum.TryParse<ResultValueType>(valueTypeStr, out var valueType);
            if (didParse == false)
            {
                return new RecordFieldValue();
            }

            switch (valueType)
            {
                case ResultValueType.String:
                default:
                    return new StringFieldValue();
                case ResultValueType.Integer:
                    return new IntegerFieldValue();
                case ResultValueType.Decimal:
                    return new DecimalFieldValue();
                case ResultValueType.Date:
                    return new DateFieldValue();
                case ResultValueType.TimeSpan:
                    return new TimeSpanFieldValue();
                case ResultValueType.Guid:
                    return new GuidFieldValue();
                case ResultValueType.StringList:
                    return new StringListFieldValue();
                case ResultValueType.IntegerList:
                    return new IntegerListFieldValue();
                case ResultValueType.GuidList:
                    return new GuidListFieldValue();
                case ResultValueType.AttachmentList:
                    return new AttachmentListFieldValue();
                case ResultValueType.ScoringGroupList:
                    return new ScoringGroupListFieldValue();
                case ResultValueType.FileList:
                    return new FileListFieldValue();
            }
        }
    }
}
