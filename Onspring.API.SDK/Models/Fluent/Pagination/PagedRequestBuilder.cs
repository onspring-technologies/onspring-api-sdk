using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    public class PagedRequestBuilder : IPagedRequestBuilder
    {
        private readonly IOnspringClient _client;

        internal PagedRequestBuilder(IOnspringClient client)
        {
            _client = client;
        }

        public IGetPagedAppsRequestBuilder OfApps()
        {
            return new GetPagedAppsRequestBuilder(_client, 1);
        }
    }
}