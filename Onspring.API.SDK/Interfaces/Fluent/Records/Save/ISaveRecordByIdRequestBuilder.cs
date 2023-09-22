using System;
using System.Collections.Generic;
using Onspring.API.SDK.Models;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface ISaveRecordByIdRequestBuilder
    {
        int AppId { get; }
        int? RecordId { get; }
        ISaveRecordByIdWithValuesRequestBuilder WithValues(IEnumerable<RecordFieldValue> values);
    }
}