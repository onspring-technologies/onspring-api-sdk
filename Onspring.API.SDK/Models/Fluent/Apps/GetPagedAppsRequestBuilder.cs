using System.Threading.Tasks;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    public class GetPagedAppsRequestBuilder : IGetPagedAppsRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; } = 50;

        internal GetPagedAppsRequestBuilder(IOnspringClient client, int pageNumber)
        {
            _client = client;
            PageNumber = pageNumber;
        }

        public IGetPagedAppsRequestBuilder WithPageSize(int pageSize)
        {
            PageSize = pageSize;
            return this;
        }

        public async Task<ApiResponse<GetPagedAppsResponse>> SendAsync()
        {
            return await _client.GetAppsAsync(new PagingRequest(PageNumber, PageSize));
        }
    }
}