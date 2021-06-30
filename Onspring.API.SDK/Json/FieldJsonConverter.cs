using Newtonsoft.Json.Linq;
using Onspring.API.SDK.Enums;
using Onspring.API.SDK.Models;
using System;

namespace Onspring.API.SDK.Json
{
    internal class FieldJsonConverter : JsonCreationConverter<Field>
    {
        protected override Field Create(Type objectType, JObject jObject)
        {
            var fieldTypeStr = jObject["type"]?.ToString() ?? jObject["Type"]?.ToString();
            var didParse = Enum.TryParse<FieldType>(fieldTypeStr, out var fieldType);
            if (didParse == false)
            {
                return new Field();
            }

            switch (fieldType)
            {
                case FieldType.List:
                    return new ListField();
                case FieldType.Reference:
                    return new ReferenceField();
                case FieldType.Formula:
                    return new FormulaField();
                default:
                    return new Field();
            }
        }
    }
}
