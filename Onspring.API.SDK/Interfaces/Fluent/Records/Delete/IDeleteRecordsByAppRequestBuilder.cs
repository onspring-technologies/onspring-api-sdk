using System.Collections;
using System.Collections.Generic;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IDeleteRecordsByAppRequestBuilder
    {
        int AppId { get; }
        IDeleteRecordByIdRequestBuilder WithId(int recordId);
        IDeleteRecordsByIdsRequestBuilder WithIds(IEnumerable<int> recordIds);
    }
}