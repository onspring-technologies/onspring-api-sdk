using System.Threading.Tasks;
using Onspring.API.SDK.Interfaces.Fluent;

namespace Onspring.API.SDK.Models.Fluent
{
    /// <summary>
    /// Represents a builder for constructing requests to retrieve apps that are paginated.
    /// </summary>
    /// <inheritdoc/>
    public class GetPagedAppsRequestBuilder : IGetPagedAppsRequestBuilder
    {
        private readonly IOnspringClient _client;
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; } = 50;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPagedAppsRequestBuilder"/> class.
        /// </summary>
        /// <param name="client">The <see cref="IOnspringClient"/> to use for the request.</param>
        /// <param name="pageNumber">The page number of the apps to retrieve.</param>
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