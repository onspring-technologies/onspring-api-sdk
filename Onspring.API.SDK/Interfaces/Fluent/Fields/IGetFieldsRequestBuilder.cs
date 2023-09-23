using System.Collections.Generic;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IGetFieldsRequestBuilder
    {
        IGetFieldByIdRequestBuilder WithId(int fieldId);
        IGetFieldsByAppRequestBuilder FromApp(int appId);
        IGetFieldsByIdsRequestBuilder WithIds(IEnumerable<int> fieldIds);
    }
}