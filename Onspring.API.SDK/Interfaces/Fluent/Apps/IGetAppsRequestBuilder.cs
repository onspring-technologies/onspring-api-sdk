using System.Collections.Generic;

namespace Onspring.API.SDK.Interfaces.Fluent
{
    public interface IGetAppsRequestBuilder
    {
        IGetPagedAppsRequestBuilder ForPage(int pageNumber);
        IGetAppsByIdsRequestBuilder WithIds(IEnumerable<int> appIds);
        IGetAppByIdRequestBuilder WithId(int appId);
    }
}